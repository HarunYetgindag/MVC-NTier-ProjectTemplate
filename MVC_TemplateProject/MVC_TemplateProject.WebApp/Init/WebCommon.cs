using MVC_TemplateProject.Common;
using MVC_TemplateProject.Entities;
using MVC_TemplateProject.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_TemplateProject.WebApp.Init
{
    public class WebCommon : ICommon
    {
        public string GetCurrentUsername()
        {
            User user = CurrentSession.User;

            if (user != null)
                return user.Username;

            else
                return "system";
        }
    }
}