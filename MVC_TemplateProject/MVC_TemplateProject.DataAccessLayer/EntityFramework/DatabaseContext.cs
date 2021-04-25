using MVC_TemplateProject.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_TemplateProject.DataAccessLayer.EntityFramework
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
            Database.SetInitializer(new CustomInitializer());
        }

        public DbSet<User> Users { get; set; }
    }
}
