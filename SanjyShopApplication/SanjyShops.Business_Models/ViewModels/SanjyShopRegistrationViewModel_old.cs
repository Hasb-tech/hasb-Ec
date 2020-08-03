using SanjyShops.Business_Models.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SanjyShops.Business_Models.ViewModels
{
    public class SanjyShopRegistrationViewModel : BaseModel
    {
        public SanjyShopRegistrationViewModel()
        {
           
           ShopeTypes = new List<SelectListModel>();
           IdProofTypes = new List<SelectListModel>();

        }


       // [Required(AllowEmptyStrings = false)]
        public long Shop_Id { get; set; }
        public bool Is_Refferal { get; set; }
        public long Agent_Id { get; set; }

       
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(ModelResources), ErrorMessageResourceName = "ShopName_Required")]
        public string Shop_Name { get; set; }



        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(ModelResources), ErrorMessageResourceName = "OwnerName_Required")]
        public string Owner_Name { get; set; }


    
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(ModelResources), ErrorMessageResourceName = "Phonenumber_Required")]
        //[RegularExpression("[^0-9]{10}", ErrorMessageResourceType = typeof(ModelResources), ErrorMessageResourceName = "PhoneNumber_Regular")]
        public string Phone_Number { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(ModelResources), ErrorMessageResourceName = "Phonenumber_Verification")]
        public bool Is_Phone_Number_Verified { get; set; }



       // [RegularExpression("/^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?.[a-zA-Z0-9-]+)*$/", ErrorMessageResourceType = typeof(ModelResources), ErrorMessageResourceName = "Email_Regular")]
        public string Email { get; set; }



        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(ModelResources), ErrorMessageResourceName = "Password_Required")]
       // [RegularExpression("^.*(?=.{7,})(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$", ErrorMessageResourceType = typeof(ModelResources), ErrorMessageResourceName = "Password_Required")]
        //
        public string Password { get; set; }
         


        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(ModelResources), ErrorMessageResourceName = "ConfirmPassword_Required")]
        [Display(Name = "Confirm Password")]
       // [RegularExpression("^.*(?=.{7,})(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$", ErrorMessageResourceType = typeof(ModelResources), ErrorMessageResourceName = "ConfirmPassword_Required")]
        [Compare("Password", ErrorMessageResourceType = typeof(ModelResources), ErrorMessageResourceName = "ConfirmPassword_Required")]
        public string Confirm_Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(ModelResources), ErrorMessageResourceName = "GSTNumber_Required")]
        public string GST_Number { get; set; }



        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(ModelResources), ErrorMessageResourceName = "FSSAI_Required")]
        public string FSSAI_Number { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(ModelResources), ErrorMessageResourceName = "Address_Required")]
        public string Address { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(ModelResources), ErrorMessageResourceName = "Pincode_Required")]
        public string pincode { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(ModelResources), ErrorMessageResourceName = "ShopType_Required")]
        public int Shop_Type_Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(ModelResources), ErrorMessageResourceName = "AccountNumber_Required")]
        public string Bank_Account_Number { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(ModelResources), ErrorMessageResourceName = "IFSCCode_Required")]
        public string IFSC_Code { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(ModelResources), ErrorMessageResourceName = "BankName_Required")]
        public string Bank_Name { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(ModelResources), ErrorMessageResourceName = "PANNumber_Required")]
        public string PAN_Number { get; set; }
        [Required( ErrorMessageResourceType = typeof(ModelResources), ErrorMessageResourceName = "FSSAICard_Required")]
        public string FSSAI { get; set; }

        [Required(ErrorMessageResourceType = typeof(ModelResources), ErrorMessageResourceName = "ID_Type_Required")]
        public int Id_Proof_Type_Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(ModelResources), ErrorMessageResourceName = "ID_Required")]
        public string Id_Proof { get; set; }
        [Required( ErrorMessageResourceType = typeof(ModelResources), ErrorMessageResourceName = "PAN_Required")]
        //public HttpPostedFileBase Id_Proof_File { get; set; }
     
        public string PAN_Card { get; set; }
        //public HttpPostedFileBase PAN_Card_File { get; set; }
        [Required(ErrorMessageResourceType = typeof(ModelResources), ErrorMessageResourceName = "Passbook_Required")]
        public string Passbook_Bank_Statement { get; set; }
        //public HttpPostedFileBase Bank_Statement_File { get; set; }
        
        //public HttpPostedFileWrapper ImageFile { get; set; }
        //public string ImagePath { get; set; }
        public string OTP { get; set; }
        public List<SelectListModel> ShopeTypes { get; set; }
        public List<SelectListModel> IdProofTypes { get; set; }


    }
}
