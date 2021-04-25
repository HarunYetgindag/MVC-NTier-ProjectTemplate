using MVC_TemplateProject.BusinessLayer.Abstract;
using MVC_TemplateProject.BusinessLayer.Result;
using MVC_TemplateProject.Common.Helpers;
using MVC_TemplateProject.Entities;
using MVC_TemplateProject.Entities.Messages;
using MVC_TemplateProject.Entities.WebLayerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace MVC_TemplateProject.BusinessLayer
{
    public class UserManager : ManagerBase<User>
    {
        public BusinessLayerResult<User> RegisterUser(RegisterViewModel data)
        {

            User user = Find(x => x.Username == data.Username || x.Email == data.Email);
            BusinessLayerResult<User> res = new BusinessLayerResult<User>();

            if (user != null)
            {
                if (user.Username == data.Username)
                {
                    res.AddError(ErrorMessageCodes.UsernameAlreadyExists, "username already exist");
                }
                if (user.Email == data.Email)
                {
                    res.AddError(ErrorMessageCodes.EmailAlreadyExists, "E-mail already exist");
                }
            }
            else
            {
                int dbResult = base.Insert(new User()
                {
                    Username = data.Username,
                    Email = data.Email,
                    Password = Crypto.HashPassword(data.Password), // Hashed Pass
                    ActivateGuid = Guid.NewGuid(),
                    ProfileImageFilename = "user.png",
                    IsActive = false,
                    IsAdmin = false
                });

                if (dbResult > 0)
                {
                    res.Result = Find(x => x.Username == data.Username && x.Email == data.Email);

                    string siteUri = ConfigHelper.Get<string>("SiteRootUri");

                    string activateUri = $"{siteUri}/Home/UserActivate/{res.Result.ActivateGuid}";

                    string body = $"Hey, {res.Result.Username};<br><br>For Activate the Account: <a href='{activateUri}' target='_blank'>Click.</a>";

                    MailHelper.SendMail(body, res.Result.Email, "Activate Account");
                }
            }

            return res;
        }

        public BusinessLayerResult<User> GetUserById(int id)
        {
            BusinessLayerResult<User> res = new BusinessLayerResult<User>();
            res.Result = Find(x => x.Id == id);

            if (res.Result == null)
            {
                res.AddError(ErrorMessageCodes.UserNotFound, "User not found");
            }

            return res;
        }

        public BusinessLayerResult<User> UpdateProfile(User data)
        {
            User db_user = Find(x => x.Id != data.Id && (x.Username == data.Username || x.Email == data.Email));
            BusinessLayerResult<User> res = new BusinessLayerResult<User>();

            if (db_user != null)
            {
                if (db_user.Username == data.Username)
                {
                    res.AddError(ErrorMessageCodes.UsernameAlreadyExists, "username already exist");
                }

                if (db_user.Email == data.Email)
                {
                    res.AddError(ErrorMessageCodes.EmailAlreadyExists, "E-mail already exist");
                }

                return res;
            }

            res.Result = Find(x => x.Id == data.Id);
            res.Result.Email = data.Email;
            res.Result.Name = data.Name;
            res.Result.Surname = data.Surname;
            res.Result.Password = data.Password;
            res.Result.Username = data.Username;

            if (string.IsNullOrEmpty(data.ProfileImageFilename) == false)
            {
                res.Result.ProfileImageFilename = data.ProfileImageFilename;
            }

            if (base.Update(res.Result) == 0)
            {
                res.AddError(ErrorMessageCodes.UserCouldNotUpdated, "Failed Update the Profile");
            }

            return res;
        }


        public BusinessLayerResult<User> LoginUser(LoginViewModel data)
        {

            BusinessLayerResult<User> res = new BusinessLayerResult<User>();
            //res.Result = Find(x => x.Username == data.Username && x.Password == data.Password);

            res.Result = Find(x => x.Username == data.Username);


            if (res.Result != null)
            {
                var control = Crypto.VerifyHashedPassword(res.Result.Password, data.Password);
                if (control == true)
                {
                    if (!res.Result.IsActive)
                    {
                        res.AddError(ErrorMessageCodes.UserIsNotActive, "User is not active");
                        res.AddError(ErrorMessageCodes.CheckYourEmail, "Please check your e-mail");
                    }
                }
                else
                {
                    res.AddError(ErrorMessageCodes.UsernameOrPassWrong, "Username or Password incorrect");
                }
            }
            else
            {
                res.AddError(ErrorMessageCodes.UsernameOrPassWrong, "Username or Password incorrect");
            }

            return res;
        }

        public BusinessLayerResult<User> RemoveUserById(int id)
        {
            BusinessLayerResult<User> res = new BusinessLayerResult<User>();

            User user = Find(x => x.Id == id);

            if (user != null)
            {
                if (Delete(user) == 0)
                {
                    res.AddError(ErrorMessageCodes.UserCouldNotRemove, "User could not be deleted");
                    return res;
                }
            }
            else
            {
                res.AddError(ErrorMessageCodes.UserCouldFind, "User not found");

            }
            return res;
        }

        public BusinessLayerResult<User> ActivateUser(Guid activateId)
        {
            BusinessLayerResult<User> res = new BusinessLayerResult<User>();

            res.Result = Find(x => x.ActivateGuid == activateId);

            if (res.Result != null)
            {
                if (res.Result.IsActive)
                {
                    res.AddError(ErrorMessageCodes.UserAlreadyActive, "User Already Active.");
                    return res;
                }
                res.Result.IsActive = true;
                Update(res.Result);

            }
            else
            {
                res.AddError(ErrorMessageCodes.ActivateIdDoesNotExists, "User not found for Activate process");
            }
            return res;
        }

        // Method hidding.
        public new BusinessLayerResult<User> Insert(User data)
        {

            User user = Find(x => x.Username == data.Username || x.Email == data.Email);
            BusinessLayerResult<User> res = new BusinessLayerResult<User>();

            res.Result = data;

            if (user != null)
            {
                if (user.Username == data.Username)
                {
                    res.AddError(ErrorMessageCodes.UsernameAlreadyExists, "Username already exist");
                }
                if (user.Email == data.Email)
                {
                    res.AddError(ErrorMessageCodes.EmailAlreadyExists, "E-mail already exist");
                }
            }
            else
            {
                res.Result.ProfileImageFilename = "user_boy.png";
                res.Result.ActivateGuid = Guid.NewGuid();

                if (base.Insert(res.Result) == 0)
                {
                    res.AddError(ErrorMessageCodes.UserCouldNotInserted, "User could not be added");
                }

            }

            return res;

        }

        public new BusinessLayerResult<User> Update(User data)
        {
            User db_user = Find(x => x.Id != data.Id && (x.Username == data.Username || x.Email == data.Email));
            BusinessLayerResult<User> res = new BusinessLayerResult<User>();

            res.Result = data;

            if (db_user != null)
            {
                if (db_user.Username == data.Username)
                {
                    res.AddError(ErrorMessageCodes.UsernameAlreadyExists, "Username already exist");
                }

                if (db_user.Email == data.Email)
                {
                    res.AddError(ErrorMessageCodes.EmailAlreadyExists, "Email already exist");
                }

                return res;
            }

            res.Result = Find(x => x.Id == data.Id);
            res.Result.Email = data.Email;
            res.Result.Name = data.Name;
            res.Result.Surname = data.Surname;
            res.Result.Password = data.Password;
            res.Result.Username = data.Username;
            res.Result.IsActive = data.IsActive;
            res.Result.IsAdmin = data.IsAdmin;


            if (base.Update(res.Result) == 0)
            {
                res.AddError(ErrorMessageCodes.UserCouldNotUpdated, "User could not be update");
            }

            return res;
        }
    }
}
