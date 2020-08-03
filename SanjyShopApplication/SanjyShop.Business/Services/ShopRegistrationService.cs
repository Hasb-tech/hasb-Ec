using SanjyShop.Business.Common;
using SanjyShop.Business.Interfaces;
using SanjyShop.Data;
using SanjyShops.Business_Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanjyShop.Business.Services
{
    public class ShopRegistrationService :IShopRegistrationService
    {
        private SanjyShopDatabase dbContext;
        public ShopRegistrationService(SanjyShopDatabase objDB)
        {
            this.dbContext = objDB;
        }

        public SanjyShopRegistrationViewModel CreateShop(SanjyShopRegistrationViewModel model)
        {
            var ShopCheck = dbContext.SANJY_SHOP_REGISTRATION.Where(row => row.Phone_Number.ToLower() == model.Phone_Number.ToLower()).ToList();
            SANJY_SHOP_REGISTRATION SanjyShopModel = new SANJY_SHOP_REGISTRATION();

            FillShopeTypes(model);
            FillIdProofTypes(model);
            FillPhoneNumberCodes(model);
            if (ShopCheck.Count != 0)
            {
                model.Message = ApplicationResources.ErrorShopExists;
                model.IsSuccessful = false;
                return model;
            }

            using (var transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    long MaxKey = dbContext.SANJY_SHOP_REGISTRATION.Select(p => p.Shop_Id).DefaultIfEmpty().Max();
                    SanjyShopModel.Is_Phone_Number_Verified = false;


                    SanjyShopModel.Shop_Id = Convert.ToInt64(MaxKey + 1);
                    SanjyShopModel.Shop_Name = model.Shop_Name;
                    SanjyShopModel.Owner_Name = model.Owner_Name;
                    
                    SanjyShopModel.Address = model.Address;
                    SanjyShopModel.pincode = model.pincode;
                    SanjyShopModel.Shop_Type_Id = model.Shop_Type_Id;

                    SanjyShopModel.GST_Number = model.GST_Number;
                    SanjyShopModel.FSSAI_Number = model.FSSAI_Number;
                    SanjyShopModel.FSSAI = model.FSSAI;


                    SanjyShopModel.Email = model.Email;
                    SanjyShopModel.Phone_Number = model.Phone_Number;
                    SanjyShopModel.Phone_Number = model.Phone_Number;

                    SanjyShopModel.Phone_Number_Country_Code_Id = model.Phone_Number_Country_Code_Id;

                    SanjyShopModel.Password = model.Password;

                    SanjyShopModel.Id_Proof_Type_Id = model.Id_Proof_Type_Id;
                    SanjyShopModel.Id_Proof_Front = model.Id_Proof_Front;
                    SanjyShopModel.Id_Proof_Back = model.Id_Proof_Back;


                    SanjyShopModel.Bank_Account_Number = model.Bank_Account_Number;

                    SanjyShopModel.IFSC_Code = model.IFSC_Code;
                    SanjyShopModel.Bank_Name = model.Bank_Name;
                    SanjyShopModel.Passbook_Bank_Statement = model.Passbook_Bank_Statement;



                    SanjyShopModel.PAN_Number = model.PAN_Number;
                    SanjyShopModel.PAN_Card = model.PAN_Card;


                   




                    dbContext.SANJY_SHOP_REGISTRATION.Add(SanjyShopModel);
                    dbContext.SaveChanges();
                    transaction.Commit();
                    model.Shop_Id = SanjyShopModel.Shop_Id;
                  //  model.Message = ApplicationResources.Success;
                    model.IsSuccessful = true;

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    model.ExceptionMessage = ex.GetBaseException().Message;
                //    model.Message = ApplicationResources.FailedToSaveShop;
                    model.IsSuccessful = false;
                }
            }

            return model;
        }
        public void FillShopeTypes(SanjyShopRegistrationViewModel model)
        {
            model.ShopeTypes = dbContext.SHOP_TYPES.Select(row => new SelectListModel
            {
                RowKey = row.Shop_Type_Id,
                Text = row.Shop_Type
            }).ToList();
        }


        public void FillIdProofTypes(SanjyShopRegistrationViewModel model)
        {
            model.IdProofTypes = dbContext.ID_PROOF_TYPES.Select(row => new SelectListModel
            {
                RowKey = row.Id_proof_Id,
                Text = row.Id_proof_Type
            }).ToList();
        }
        public void FillPhoneNumberCodes(SanjyShopRegistrationViewModel model)
        {
            model.CountryCodes = dbContext.COUNTRY_CODES.Select(row => new SelectListModel
            {
                RowKey = row.Id,
                Text = row.Country_Code
            }).ToList();
        }

        public bool IsEmailExist(string email)
        {
            //using (SanjyShopDatabase dbContext= new SanjyShopDatabase())
            //{

            //}
            var ShopCheck = dbContext.SANJY_SHOP_REGISTRATION.Where(r => r.Email == email).FirstOrDefault();
            return ShopCheck != null;
        }


    }
}
