using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanjyShops.Business_Models.ViewModels
{
    public class AgentDetailsViewModel :BaseModel
    {
        public long Agent_Id { get; set; }
        public string Agent_Name { get; set; }
        public string Country_Name { get; set; }
        public string State_Name { get; set; }
        public string City_Name { get; set; }
        public string Location_Name { get; set; }
        public string Agency_Name { get; set; }
        public string Licence_Number { get; set; }
        public string Address { get; set; }
        public string Pincode { get; set; }
        public string Phonenumber { get; set; }
        public string Password { get; set; }
    }
}
