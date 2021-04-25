using MVC_TemplateProject.DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_TemplateProject.DataAccessLayer.MySql
{
    public class RepositoryBase
    {
        protected static DatabaseContext context;
        private static object _lockSync = new object(); // static for singleton

        protected RepositoryBase() // protected ctor - can't instance
        {
            CreateContext();
        }


        private static void CreateContext() // Singleton
        {
            if (context == null)
            {
                lock (_lockSync)
                {
                    if (context == null)
                    {
                        context = new DatabaseContext();
                    }
                }
            }

        }
    }
}
