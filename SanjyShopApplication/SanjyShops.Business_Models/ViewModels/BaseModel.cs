using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanjyShops.Business_Models.ViewModels
{
    public abstract class BaseModel : ICloneable
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
        public string ExceptionMessage { get; set; }
        // public byte UpdateType { get; set; }
        public BaseModel()
        {

        }
        public object Clone()
        {
            return base.MemberwiseClone();
        }


    }
}
