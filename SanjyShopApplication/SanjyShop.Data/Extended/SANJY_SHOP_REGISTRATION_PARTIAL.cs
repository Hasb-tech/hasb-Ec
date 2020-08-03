using SanjyShops.Business_Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanjyShop.Data
{
    [MetadataType(typeof(SANJY_SHOP_REGISTRATION))]
    public partial class SANJY_SHOP_REGISTRATION
    {
        public string Confirm_Password { get; set; }
     

    }

    
}
