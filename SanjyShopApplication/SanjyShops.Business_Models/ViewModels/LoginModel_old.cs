using SanjyShops.Business_Models.Resources;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace SanjyShops.Business_Models.ViewModels
{
    public class LoginModel_old :BaseModel
    {
        public LoginModel_old()
        {

        }

        public bool LoginSuccess { get; set; }

        public bool NeedsPasswordChange { get; set; }

       // public CITSPrintSWPrincipalData UserPrincipalData { get; set; }

        public SanjyShopRegistrationViewModel User { get; set; }

        public bool FailedLogin { get; set; }

        public string TopContent { get; set; }

        public string BottomContent { get; set; }

        public bool DisplayMobileLinks { get; set; }

        [Required(ErrorMessageResourceType = typeof(ModelResources), ErrorMessageResourceName = "Password_Required")]
        [StringLength(200, ErrorMessageResourceType = typeof(ModelResources), ErrorMessageResourceName = "Password_Length")]
        [Display(Name = "Password")]
        public string LoginPassword { get; set; }

        [Required(ErrorMessageResourceType = typeof(ModelResources), ErrorMessageResourceName = "Username_Required")]
        [StringLength(255, ErrorMessageResourceType = typeof(ModelResources), ErrorMessageResourceName = "Username_Length")]
        [Display(Name = "Username")]
        public string LoginUsername { get; set; }

        public string ReturnUrl { get; set; }
        
        public string TimeZoneTime { get; set; }

        //Change password
        [Required(ErrorMessageResourceType = typeof(ModelResources), ErrorMessageResourceName = "OldPassword_Required")]
        [StringLength(200, ErrorMessageResourceType = typeof(ModelResources), ErrorMessageResourceName = "Password_Length")]
        [Display(Name = "Password")]
        [System.Web.Mvc.Remote("CheckPasswordExists", "Login", ErrorMessageResourceType = typeof(ModelResources), ErrorMessageResourceName = "CheckPasswordExistsErrorMessage")]
        public string OldPassword { get; set; }
        [Required(ErrorMessageResourceType = typeof(ModelResources), ErrorMessageResourceName = "NewPassword_Required")]
        [StringLength(200, ErrorMessageResourceType = typeof(ModelResources), ErrorMessageResourceName = "Password_Length")]
        public string NewPassword { get; set; }
        [Required(ErrorMessageResourceType = typeof(ModelResources), ErrorMessageResourceName = "ConfirmPassword_Required")]
        [StringLength(200, ErrorMessageResourceType = typeof(ModelResources), ErrorMessageResourceName = "Password_Length")]
        [CompareAttribute("NewPassword", ErrorMessage = "Password doesn't match.")]
        public string ConfirmPassword { get; set; }
    }
}
