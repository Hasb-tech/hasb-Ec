using SanjyShops.Business_Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanjyShop.Business.Interfaces
{
    public interface ILoginService
    {

        LoginModel AttemptLogin(LoginModel model);

            //void Logout();

    }
}
