using Newtonsoft.Json.Linq;
using SanjyShop.Business.Common;
using SanjyShop.Business.Interfaces;
using SanjyShop.UI.Helper;
using SanjyShops.Business_Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;
using System.Web.Security;

namespace SanjyShop.UI.Controllers
{
    public class UserController : Controller
    {
        private IShopRegistrationService ShopRegistrationService;
        private ILoginService LoginService;
        public UserController(IShopRegistrationService objShopRegistrationService, ILoginService objLoginService)
        {
            this.ShopRegistrationService = objShopRegistrationService;
            this.LoginService = objLoginService;
        }
        // GET: User
        [HttpGet]
        public ActionResult Registration()
        {
            SanjyShopRegistrationViewModel model = new SanjyShopRegistrationViewModel();
            ShopRegistrationService.FillShopeTypes(model);
            ShopRegistrationService.FillIdProofTypes(model);
            ShopRegistrationService.FillPhoneNumberCodes(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Registration(SanjyShopRegistrationViewModel model)
        {
            // model.FSSAI = System.IO.Path.GetFileName(Request.Files[0].FileName);
            //model.Id_Proof = System.IO.Path.GetFileName(Request.Files[1].FileName);
            //model.PAN_Card = System.IO.Path.GetFileName(Request.Files[2].FileName);
            //model.Passbook_Bank_Statement = System.IO.Path.GetFileName(Request.Files[3].FileName);
            //var count = Request.Files.Count;
            //if (Request.Files[0].ContentLength > 0)
            //{
            //    if (!System.IO.Directory.Exists(Server.MapPath("~/UploadedFiles/Shop")))
            //    {
            //        System.IO.Directory.CreateDirectory(Server.MapPath("~/UploadedFiles/Shop"));
            //    }

            //    Request.Files[0].SaveAs(Server.MapPath("~/UploadedFiles/Shop/" + model.FSSAI));
            //}
         
            //foreach (HttpPostedFileBase fileUpload in fileUploadMulti)   
            //{
            //    if (fileUpload != null)
            //    {
            //        string folderPath = Server.MapPath("~/Upload/");
            //        fileUpload.SaveAs(folderPath + "," + fileUpload.FileName);
            //    }


            //////Document Save Part/////

                model.Password = CryptographicHelper.Encrypt(model.Password);

            model.FSSAI = System.IO.Path.GetFileName(Request.Files[0].FileName);
            model.Id_Proof_Front = System.IO.Path.GetFileName(Request.Files[1].FileName);
            model.Id_Proof_Back = System.IO.Path.GetFileName(Request.Files[2].FileName);
            model.Passbook_Bank_Statement = System.IO.Path.GetFileName(Request.Files[3].FileName);
            model.PAN_Card = System.IO.Path.GetFileName(Request.Files[4].FileName);
            if (Request.Files[0].ContentLength > 0)
            {
                if (!System.IO.Directory.Exists(Server.MapPath("~/UploadedFiles/Shop/"+ model.Shop_Name))) { System.IO.Directory.CreateDirectory(Server.MapPath("~/UploadedFiles/Shop/" + model.Shop_Name )); }

                Request.Files[0].SaveAs(Server.MapPath("~/UploadedFiles/Shop/" + model.Shop_Name + "/" + model.FSSAI));
            }

            

            if (Request.Files[1].ContentLength > 0)
            {
                if (!System.IO.Directory.Exists(Server.MapPath("~/UploadedFiles/Shop" + model.Shop_Name ))) { System.IO.Directory.CreateDirectory(Server.MapPath("~/UploadedFiles/Shop/" + model.Shop_Name )); }

                Request.Files[1].SaveAs(Server.MapPath("~/UploadedFiles/Shop/" + model.Shop_Name + "/" + model.Id_Proof_Front));
            }

           

            if (Request.Files[2].ContentLength > 0)
            {
                if (!System.IO.Directory.Exists(Server.MapPath("~/UploadedFiles/Shop" + model.Shop_Name))) { System.IO.Directory.CreateDirectory(Server.MapPath("~/UploadedFiles/Shop/" + model.Shop_Name)); }

                Request.Files[2].SaveAs(Server.MapPath("~/UploadedFiles/Shop/" + model.Shop_Name + "/" + model.Id_Proof_Back));
            }



           

            if (Request.Files[3].ContentLength > 0)
            {
                if (!System.IO.Directory.Exists(Server.MapPath("~/UploadedFiles/Shop" + model.Shop_Name))) { System.IO.Directory.CreateDirectory(Server.MapPath("~/UploadedFiles/Shop/" + model.Shop_Name )); }

                Request.Files[3].SaveAs(Server.MapPath("~/UploadedFiles/Shop/" + model.Shop_Name + "/" + model.Passbook_Bank_Statement));
            }

          

            if (Request.Files[4].ContentLength > 0)
            {
                if (!System.IO.Directory.Exists(Server.MapPath("~/UploadedFiles/Shop" + model.Shop_Name))) { System.IO.Directory.CreateDirectory(Server.MapPath("~/UploadedFiles/Shop/"+ model.Shop_Name)); }

                Request.Files[4].SaveAs(Server.MapPath("~/UploadedFiles/Shop/" + model.PAN_Card));
            }
            model = ShopRegistrationService.CreateShop(model);
            return View(model);
        }



        [HttpGet]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        public ActionResult Login()
        {
           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string ReturnUrl="")
        {


            string status = "";
            var loginModel = model;

            if (!String.IsNullOrEmpty(model.LoginPhoneNumber) && !String.IsNullOrEmpty(model.LoginPassword))
            {
                loginModel = LoginService.AttemptLogin(model);

                if (loginModel.LoginSuccess)
                {
                    int timeout = model.RememberMe ? 525600 : 20;
                    var ticket = new FormsAuthenticationTicket(model.LoginPhoneNumber, model.RememberMe, timeout);
                    string encrypted = FormsAuthentication.Encrypt(ticket);
                    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                    cookie.Expires = DateTime.Now.AddMinutes(timeout);
                    cookie.HttpOnly = true;
                    Response.Cookies.Add(cookie);
                    if (Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                      
                    }

                }
                else
                {

                    ModelState.AddModelError("InvalidCredentials", "Invalid login Credentials !");
                    return View(model);
                }



            

            }

            return View(model);

        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login","User");
        }

        [NonAction]
        public bool IsEmailExist(string email)
        {

            return ShopRegistrationService.IsEmailExist(email);
        }

        //[HttpPost]
        //public ActionResult Registration(SanjyShopRegistrationViewModel model)
        //{ 
        //    if (ModelState.IsValid)
        //    {
        //        if (model.Shop_Id == 0)
        //        {
        //            model = ShopRegistrationService.CreateShop(model);

        //        }


        //        if (model.Message != AppConstants.Common.SUCCESS)
        //        {
        //            ModelState.AddModelError("error_msg", model.Message);
        //        }
        //        else
        //        {
        //         return  RedirectToAction("Login");
        //        }

        //        model.Message = "";
        //        return View(model);
        //    }



        //    model.Message = SanjyAppResourceManager.GetApplicationString(AppConstants.Common.FAILED);

        //    return View(model);
        //}





    }
}