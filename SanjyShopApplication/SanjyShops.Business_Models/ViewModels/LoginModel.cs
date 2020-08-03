using SanjyShops.Business_Models.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SanjyShops.Business_Models.ViewModels
{
    public class LoginModel : BaseModel
    {
        
        [Required(ErrorMessageResourceType = typeof(ModelResources), ErrorMessageResourceName = "Email_Required")]
        public string LoginPhoneNumber { get; set; }

        [Required(AllowEmptyStrings =false, ErrorMessageResourceType = typeof(ModelResources), ErrorMessageResourceName = "Password_Required")]
        public string  LoginPassword { get; set; }

        public SanjyShopRegistrationViewModel User { get; set; }

        [Display(Name ="Remember Me")]
        public bool RememberMe { get; set; }

        public bool FailedLogin { get; set; }

        public bool LoginSuccess { get; set; }

        //[HiddenInput]
        //public string ReturnUrl { get; set; }

    }
}
