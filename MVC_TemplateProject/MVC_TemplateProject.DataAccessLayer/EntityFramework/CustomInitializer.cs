using MVC_TemplateProject.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_TemplateProject.DataAccessLayer.EntityFramework
{
    public class CustomInitializer : CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            //  init datas
            User standartuser = new User()
            {
                Name = "TestName",
                Surname = "TestSurname",
                Email = "test@mail.com",
                ActivateGuid = Guid.NewGuid(),
                IsActive = true,
                IsAdmin = false,
                Username = "Test",
                Password = "123123",
                ProfileImageFilename = "user.png",
                CreatedOn = DateTime.Now.AddHours(1),
                ModifiedOn = DateTime.Now.AddMinutes(65),
                ModifiedUsername = "system"
            };

            context.Users.Add(standartuser);
            context.SaveChanges();
        }
    }
}
