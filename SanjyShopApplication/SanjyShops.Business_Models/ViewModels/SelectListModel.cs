using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanjyShops.Business_Models.ViewModels
{
    public class SelectListModel:BaseModel
    {
        public SelectListModel()
        {

        }

        public long? RowKey { get; set; }
        public string Text { get; set; }
        public bool Selected { get; set; }
        public int IntValue { get; set; }
    }
}
