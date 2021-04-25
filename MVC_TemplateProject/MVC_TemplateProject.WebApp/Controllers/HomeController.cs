using MVC_TemplateProject.BusinessLayer;
using MVC_TemplateProject.BusinessLayer.Result;
using MVC_TemplateProject.Entities;
using MVC_TemplateProject.Entities.WebLayerViewModels;
using MVC_TemplateProject.WebApp.Filters;
using MVC_TemplateProject.WebApp.Models;
using MVC_TemplateProject.WebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_TemplateProject.WebApp.Controllers
{
    [ExceptionFilter] // Exception Filter --
    public class HomeController : Controller
    {

        private UserManager userManager = new UserManager();


        public ActionResult Index()
        {
            return View();
        }

        #region Login

        // GET: Home
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                BusinessLayerResult<User> res = userManager.LoginUser(model);

                if (res.Errors.Count > 0)
                {
                    res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                    return View(model);
                }

                CurrentSession.Set<User>("login", res.Result);

                return RedirectToAction("Index");
            }

            return View(model);
        }


        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
        #endregion

        #region Register


        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {

                BusinessLayerResult<User> res = userManager.RegisterUser(model);

                if (res.Errors.Count > 0)
                {

                    res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                    return View(model);
                }


                OkViewModel ok_model = new OkViewModel()
                {
                    Title = "Success",
                    RedirectingUrl = "/Home/Login",

                };

                ok_model.Items.Add("Please click the activation link we sent to your e-mail address to activate your account.");

                return View("Ok", ok_model);
            }

            return View(model);
        }
        #endregion

    }
}