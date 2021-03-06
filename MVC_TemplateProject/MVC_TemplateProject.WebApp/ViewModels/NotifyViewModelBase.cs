using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_TemplateProject.WebApp.ViewModels
{
    public class NotifyViewModelBase<T>
    {
        public NotifyViewModelBase()
        {
            Header = "Yönlendiriliyorsunuz";
            Title = "Geçersiz işlem";
            IsRedirecting = true;
            RedirectingUrl = "/Home/Index";
            RedirectingTimeout = 1000;
            Items = new List<T>();
        }
        public List<T> Items { get; set; }
        public string Header { get; set; }
        public string Title { get; set; }
        public bool IsRedirecting { get; set; }
        public string RedirectingUrl { get; set; }
        public int RedirectingTimeout { get; set; }
    }
}