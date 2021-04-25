using MVC_TemplateProject.DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_TemplateProject.Entities;

namespace MVC_TemplateProject.BusinessLayer
{
    public class Test
    {
        private Repository<User> repouser = new Repository<User>();


        public Test()
        {

        }

        public void InsertTest()
        {

            int result = repouser.Insert(new User()
            {
                Name = "aaa",
                Surname = "bbb",
                Email = "aaa@gmail.com",
                ActivateGuid = Guid.NewGuid(),
                IsActive = true,
                IsAdmin = false,
                Username = "aabb",
                Password = "111",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now.AddMinutes(5),
                ModifiedUsername = "aabb"
            });
        }

        public void UpdateTest()
        {
            User user = repouser.Find(x => x.Username == "aabb");

            if (user != null)
            {
                user.Username = "xxx";
                int result = repouser.Update(user);
            }
        }

        public void DeleteTest()
        {
            User user = repouser.Find(x => x.Username == "xxx");

            if (user != null)
            {
                int result = repouser.Delete(user);

            }
        }


    }
}
