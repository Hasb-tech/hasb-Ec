using SanjyShops.Business_Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanjyShop.Business.Interfaces
{
    public interface IShopRegistrationService
    {
        SanjyShopRegistrationViewModel CreateShop(SanjyShopRegistrationViewModel model);
        bool IsEmailExist(string email);
        void FillShopeTypes(SanjyShopRegistrationViewModel model);
        void FillIdProofTypes(SanjyShopRegistrationViewModel model);
        void FillPhoneNumberCodes(SanjyShopRegistrationViewModel model);

       // SanjyShopRegistrationViewModel FileUpload(SanjyShopRegistrationViewModel model);


    }
}
