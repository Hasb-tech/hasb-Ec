using SanjyShop.Business.Common;
using SanjyShop.Business.Interfaces;
using SanjyShop.Data;
using SanjyShops.Business_Models.Common;
using SanjyShops.Business_Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanjyShop.Business.Services
{
     public class LoginService_old : ILoginService_old
    {
        private SanjyShopDatabase dbContext;
        public virtual SanjyShopRegistrationViewModel CurrentUser { get; set; }

        public LoginService_old(SanjyShopDatabase objDB)
        {
            this.dbContext = objDB;          
        }

        /// <summary>
        /// Attempts the login.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public LoginModel_old AttemptLogin(string userName, string password)
        {
            var loginModel = new LoginModel_old();

            loginModel = ValidateUser(userName, password, loginModel);

            return loginModel;
        }

        /// <summary>
        /// Logs the User out of the system
        /// </summary>
        public void Logout()
        {
            //this.UserIdentityProvider.logout();
        }

        /// <summary>
        /// Validates the user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <param name="loginModel">The login model.</param>
        /// <returns></returns>
        private LoginModel_old ValidateUser(string userName, string password, LoginModel_old loginModel)
        {
          //  var binPassword = SecurityManagement.Encrypt(password);
           // var isLockedOut = false;

            SanjyShopRegistrationViewModel user = new SanjyShopRegistrationViewModel();

            //// Check to see if user is locked out add code here later
            //var failedLogin = _dataUnit.FailedLoginRepository.Get().OrderByDescending(row => row.DateAdded).FirstOrDefault(row => row.AppUserName.Equals(userName, StringComparison.OrdinalIgnoreCase));
            //var lockedTimeMinutes = _configProvider.GetConfigurationInt(AppConstants.ConfigSetting.PASSWORD_LOCKED_TIME);

            // Tries to find a User that has the same username and password combo as what was given
            try
            {
                // Login Blocked based on date
                System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
                //Get your key from config file to open the lock!
                // string lockedDate = (string)settingsReader.GetValue("ActivaKey", typeof(String));

                // string dateLocked = SecurityManagement.Encrypt1("10/10/2018"); // dd-MM-yyyy
                //DateTime DecryptLockedDate = Convert.ToDateTime(SecurityManagement.Decrypt1(lockedDate));

                //  DateTime currentDate = DateTimeUTC.Now.Date;

                // if (currentDate < DecryptLockedDate)
                // {

                //////user = dbContext.Users.SingleOrDefault(row => row.RowKey == 1);
                //////user.Password = binPassword;

                //////using (var transaction = dbContext.Database.BeginTransaction())
                //////{
                //////    try
                //////    {
                //////        user = dbContext.Users.SingleOrDefault(row => row.RowKey == 1);
                //////        user.Password = binPassword;

                //////        dbContext.SaveChanges();
                //////        transaction.Commit(); 
                //////    }
                //////    catch (Exception ex)
                //////    {
                //////        transaction.Rollback();
                //////    }
                //////}
                //

                user = dbContext.SANJY_SHOP_REGISTRATION.Where(u => u.Password.Equals(password) && (u.EmailAddress.Equals(userName, StringComparison.OrdinalIgnoreCase) || u.AppUserName.Equals(userName, StringComparison.OrdinalIgnoreCase)) && u.StatusKey == DbConstants.StatusKey.Active).Select(row => new AppUserViewModel
                {
                    RowKey = row.RowKey,
                    AppUserName = row.AppUserName,
                    FirstName = row.FirstName + " " + (row.MiddleName ?? "") + " " + row.LastName,
                    EmailAddress = row.EmailAddress,
                    Phone1 = row.Phone1,
                    Phone2 = row.Phone2,
                    RoleKey = row.RoleKey,
                    Image = row.Image,

                }).SingleOrDefault();
                // }

                //else
                //{
                //    loginModel = LoadUser(user, loginModel, false);
                //    //loginModel.Message = ApplicationResources.OutDate;
                //    loginModel.Message = ApplicationResources.FailedToLoginPleaseContactAdmin;
                //    return loginModel;
                //}

            }
            catch (Exception e)
            {
                //this.UpdateLoginAttempts(userName, true);
                //this.OnProviderError(e);

                loginModel = LoadUser(user, loginModel, false);
                loginModel.Message = ApplicationResources.LoginFailed;
                loginModel.ExceptionMessage = e.Message;
                //if (IsUserLockedOut(userName))
                //{
                //    var lockedoutTime = failedLogin.AppUserLockDate.Value.AddMinutes(lockedTimeMinutes);
                //    loginModel.Message = String.Concat(SkillBaseResourceManager.GetApplicationString(AppConstants.ErrorResourceName.LOCKED_OUT), lockedoutTime);
                //    isLockedOut = true;
                //}
                return loginModel;
            }

            loginModel.User = user;

            //this.UpdateLoginAttempts(userName, user == null);


            //Lavish
            //if (user == null)
            //{
            //    loginModel = LoadUser(user, loginModel, false);

            //    //// check if user is locked out
            //    //if (IsUserLockedOut(userName))
            //    //{
            //    //    var lockedoutTime = failedLogin.AppUserLockDate.Value.AddMinutes(lockedTimeMinutes);

            //    //    loginModel.Message = String.Concat(SkillBaseResourceManager.GetApplicationString(AppConstants.ErrorResourceName.LOCKED_OUT), lockedoutTime);
            //    //    isLockedOut = true;
            //    //}

            //    //if (!isLockedOut)
            //    //    loginModel.Message = SkillBaseResourceManager.GetApplicationString(AppConstants.ErrorResourceName.INVALID_LOGIN);

            //    loginModel.Message = ApplicationResources.InvalidLogin;
            //    return loginModel;
            //}

            //else if (user.StatusKey == DbConstants.StatusKey.Deactive)
            //{
            //    loginModel = LoadUser(user, loginModel, false);
            //    loginModel.Message = ApplicationResources.ErrorUserNotActive;
            //    return loginModel;
            //}


            //!Lavish

            //DateTime lockTime = DateTime.UtcNow;

            //if (failedLogin != null && failedLogin.AppUserLockDate.HasValue && failedLogin.AppUserLockDate.Value.AddMinutes(lockedTimeMinutes) > lockTime)
            //{
            //    loginModel = LoadUser(user, loginModel, false);
            //    var lockedoutTime = failedLogin.AppUserLockDate.Value.AddMinutes(lockedTimeMinutes);
            //    loginModel.Message = String.Concat(SkillBaseResourceManager.GetApplicationString(AppConstants.ErrorResourceName.LOCKED_OUT), lockedoutTime);
            //    return loginModel;
            //}

            // Check If User has Role of Audit Log Viewer
            //loginModel =  IsAuditLogViewerRole(loginModel, user);

            //// check for password change
            //NeedsPasswordChange(loginModel, user);

            //// login was successfull delete the failed login entry 
            //if (failedLogin != null)
            //{
            //    var failedLoginList = this.DataUnit.FailedLoginRepository.Get().Where(row => row.AppUserName.Equals(userName, StringComparison.OrdinalIgnoreCase)).ToList();
            //    foreach (var failed in failedLoginList)
            //        this.DataUnit.FailedLoginRepository.Delete(failed);
            //}

            loginModel = LoadUser(user, loginModel, true);

            if (loginModel.User != null)
            {
                dbContext.SaveChanges();

                // Use the UserIdentityProvider from BasePresenter to load the user
                //this.UserIdentityProvider.LoadUser(loginModel.User.EmailAddress);

                // Update the LoginModel with the User information
                //loginModel.UserPrincipalData = dbContext.AppUsers.Where(row => row.RowKey == loginModel.User.RowKey).Select(row => new CITSPrintSWPrincipalData
                //{
                //    //BranchKey = row.BranchKey,
                //    //CompanyKey = row.Branch.CompanyKey,
                //    //CompanyName = row.Branch.Company.CompayName

                //}).FirstOrDefault();


                //Lavish
                //if (loginModel.UserPrincipalData == null)
                //{
                //    loginModel.UserPrincipalData = new CITSPrintSWPrincipalData();
                //}
                //loginModel.UserPrincipalData.Name = loginModel.User.FirstName;
                //loginModel.UserPrincipalData.UserKey = loginModel.User.RowKey;

                //loginModel.UserPrincipalData.RoleKey = loginModel.User.RoleKey ?? 0;

                //loginModel.LoginSuccess = true;
                //loginModel.IsSuccessful = true;
                //Lavish
            }

            return loginModel;
        }

        /// <summary>
        /// Loads the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="model">The model.</param>
        /// <param name="loginSuccess">if set to <c>true</c> [login success].</param>
        /// <returns></returns>
        private LoginModel_old LoadUser(SanjyShopRegistrationViewModel user, LoginModel_old model, bool loginSuccess)
        {
            model.User = user;
            //if (user != null)
            //{
            //    model.LoginUsername = user.EmailAddress;
            //}

            model.LoginSuccess = loginSuccess;
            model.FailedLogin = !loginSuccess;

            return model;
        }

        private void LoadUser(string username)
        {
            CurrentUser = dbContext.SANJY_SHOP_REGISTRATION.Where(u => u.Email.Equals(username, StringComparison.OrdinalIgnoreCase)).Select(row => new SanjyShopRegistrationViewModel
            {
                RowKey = row.RowKey,
                AppUserName = row.AppUserName,
                FirstName = row.FirstName + " " + (row.MiddleName ?? "") + " " + row.LastName,
                Email = row.Email,
                Phone1 = row.Phone1,
                Phone2 = row.Phone2,
                RoleKey = row.RoleKey,
                Image = row.Image,

            }).SingleOrDefault();
            //if (CurrentUser != null) // Harshal TO DO -- Do we need this if statement
            //    UserRoleModel = new RoleModel(CurrentUser.Role.RoleName);
        }


        //public LoginModel ChangePassword(LoginModel model, int AppUserKey)
        //{
        //    var binPassword = SecurityManagement.Encrypt(model.OldPassword);
        //    try
        //    {
        //        int userCount = dbContext.AppUsers.Where(u => u.Password.Equals(binPassword) && u.StatusKey == DbConstants.StatusKey.Active).Count();
        //        if (userCount > 0)
        //        {
        //            AppUser appUserModel = new AppUser();

        //            using (var transaction = dbContext.Database.BeginTransaction())
        //            {
        //                try
        //                {
        //                    appUserModel = dbContext.AppUsers.SingleOrDefault(row => row.RowKey == AppUserKey);

        //                    appUserModel.Password = SecurityManagement.Encrypt(model.NewPassword);

        //                    dbContext.SaveChanges();
        //                    transaction.Commit();
        //                    model.Message = ApplicationResources.Success;
        //                    model.IsSuccessful = true;
        //                }
        //                catch (Exception ex)
        //                {
        //                    transaction.Rollback();
        //                    model.ExceptionMessage = ex.GetBaseException().Message;
        //                    model.Message = ApplicationResources.FailedToChangePassword;
        //                    model.IsSuccessful = false;
        //                }
        //            }
        //            return model;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        model = new LoginModel();
        //        model.ExceptionMessage = ex.GetBaseException().Message;
        //        return model;
        //    }
        //    throw new NotImplementedException();
        //}

        //public LoginModel CheckPasswordExists(string Password, int AppUserKey)
        //{
        //    LoginModel model = new LoginModel();
        //    var binPassword = SecurityManagement.Encrypt(Password);

        //    if (dbContext.AppUsers.Where(u => u.Password.Equals(binPassword) && u.RowKey == AppUserKey).Any())
        //    {
        //        model.Message = ApplicationResources.Success;
        //        model.IsSuccessful = true;
        //    }
        //    else
        //    {
        //        model.Message = ApplicationResources.NotExists;
        //        model.IsSuccessful = false;
        //    }
        //    return model;
        //}
    }
}
