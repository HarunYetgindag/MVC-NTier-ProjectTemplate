using MVC_TemplateProject.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_TemplateProject.WebApp.Filters
{
    public class AuthAdmin : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (CurrentSession.User != null && CurrentSession.User.IsAdmin == false) // Admin değilse AccessDenied Sayfası
            {
                filterContext.Result = new RedirectResult("/Home/AccessDenied");
            }
        }
    }
}