using SanjyShops.Business_Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanjyShop.Business.Interfaces
{
    public interface ILoginService_old
    {
   
            LoginModel_old AttemptLogin(string userName, string password);

            void Logout();

            //LoginModel ChangePassword(LoginModel model, int AppUserKey);

            //LoginModel CheckPasswordExists(string Password, int AppUserKey);
        
    }
}
