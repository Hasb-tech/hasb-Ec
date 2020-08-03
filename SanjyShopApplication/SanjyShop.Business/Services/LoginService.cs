using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SanjyShop.Business.Common;
using SanjyShop.Business.Interfaces;
using SanjyShop.Data;
using SanjyShops.Business_Models.Common;
using SanjyShops.Business_Models.ViewModels;
using System.Web.Security;
using System.Web;


namespace SanjyShop.Business.Services
{
    public class LoginService : ILoginService
    {
        private SanjyShopDatabase dbContext;
        public LoginService(SanjyShopDatabase objDB)
        {
            this.dbContext=objDB;
        }


        //public LoginModel AttemptLogin(string userName, string password)
        //{
        //    var loginModel = new LoginModel();

        //    loginModel = ValidateUser(userName, password, loginModel);

        //    return loginModel;
        //}




        public LoginModel AttemptLogin(LoginModel model)
        {
            var loginModel = model;
            var binPassword = SecurityManagement.Encrypt(model.LoginPassword);


            var checkUser = dbContext.SANJY_SHOP_REGISTRATION.Where(s => s.Phone_Number == model.LoginPhoneNumber).FirstOrDefault();
            if (checkUser != null)
            {
               // string clearPass = Convert.ToBase64String(binPassword);
                if (string.Compare(binPassword, checkUser.Password) == 0)
                {
                    

                     

                    loginModel.LoginSuccess = true;
                    loginModel.IsSuccessful = true;

                    return loginModel;
                    //int timeout = model.RememberMe ? 525600 : 20;
                    //var ticket = new FormsAuthenticationTicket(model.LoginPhoneNumber, model.RememberMe, timeout);
                    //string encrypted = FormsAuthentication.Encrypt(ticket);
                    //var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                    //cookie.Expires = DateTime.Now.AddMinutes(timeout);
                    //cookie.HttpOnly = true;
                    //Response.Cookies.Add(cookie);
                }
                else
                {
                    loginModel.FailedLogin =true;
                    loginModel.Message = "invalid Credentials";
                    return loginModel;
                }

            }
            
                loginModel.Message = "invalid Credentials";
                return loginModel;
            
           

        }



        private LoginModel ValidateUser(string userName, string password, LoginModel loginModel)
        {
            var binPassword = SecurityManagement.Encrypt(password);
          

            

            try
            {
                var checkUser = dbContext.SANJY_SHOP_REGISTRATION.Where(s => s.Phone_Number == userName).FirstOrDefault();

                if (string.Compare(binPassword, checkUser.Password) == 0)
                {
                    

                   

                    loginModel.LoginSuccess = true;
                    loginModel.IsSuccessful = true;

                    return loginModel;
                    //int timeout = model.RememberMe ? 525600 : 20;
                    //var ticket = new FormsAuthenticationTicket(model.LoginPhoneNumber, model.RememberMe, timeout);
                    //string encrypted = FormsAuthentication.Encrypt(ticket);
                    //var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                    //cookie.Expires = DateTime.Now.AddMinutes(timeout);
                    //cookie.HttpOnly = true;
                    //Response.Cookies.Add(cookie);
                }
                else
                {
                    loginModel.FailedLogin =false;
                    loginModel.Message = "invalid Credentials";
                }
               
              

            }
            catch (Exception e)
            {
                

               // loginModel = LoadUser(user, loginModel, false);
                loginModel.Message = ApplicationResources.LoginFailed;
                loginModel.ExceptionMessage = e.Message;
               
                return loginModel;
            }

          

          
         



          

            return loginModel;
        }




    }
}
