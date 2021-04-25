using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_TemplateProject.Common.Helpers
{
    public class ConfigHelper
    {
        public static T Get<T>(string key) // webconfig deki bilgileri alıp mailhelper a aktarmak için kullanıyoruz.
        {
            return (T)Convert.ChangeType(ConfigurationManager.AppSettings[key], typeof(T));
        }
    }
}
