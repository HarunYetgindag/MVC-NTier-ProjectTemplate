using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_TemplateProject.BusinessLayer
{
    public class Test
    {
        //private Repository<EvernoteUser> repouser = new Repository<EvernoteUser>();
        //private Repository<Category> repo = new Repository<Category>();
        //private Repository<Comment> repo_comment = new Repository<Comment>();
        //private Repository<Note> repo_note = new Repository<Note>();

        //public Test()
        //{
        //    List<Category> cat = repo.List();
        //    List<Category> cat_filter = repo.List(x => x.Id > 5);
        //}

        //public void InsertTest()
        //{

        //    int result = repouser.Insert(new EvernoteUser()
        //    {
        //        Name = "aaa",
        //        Surname = "bbb",
        //        Email = "aaa@gmail.com",
        //        ActivateGuid = Guid.NewGuid(),
        //        IsActive = true,
        //        IsAdmin = false,
        //        Username = "aabb",
        //        Password = "111",
        //        CreatedOn = DateTime.Now,
        //        ModifiedOn = DateTime.Now.AddMinutes(5),
        //        ModifiedUsername = "aabb"
        //    });
        //}

        //public void UpdateTest()
        //{
        //    EvernoteUser user = repouser.Find(x => x.Username == "aabb");

        //    if (user != null)
        //    {
        //        user.Username = "xxx";
        //        int result = repouser.Update(user);
        //    }
        //}

        //public void DeleteTest()
        //{
        //    EvernoteUser user = repouser.Find(x => x.Username == "xxx");

        //    if (user != null)
        //    {
        //        int result = repouser.Delete(user);

        //    }
        //}

        //public void CommentTest()
        //{
        //    EvernoteUser user = repouser.Find(x => x.Id == 1); // User buldum
        //    Note note = repo_note.Find(x => x.Id == 3); // Note buldum

        //    Comment comment = new Comment()
        //    {
        //        Text = "Bu bir test commentdir",
        //        CreatedOn = DateTime.Now,
        //        ModifiedOn = DateTime.Now,
        //        ModifiedUsername = "harun",
        //        Note = note, // bu nota 
        //        Owner = user // bu user la comment ekledim.
        //    };

        //    repo_comment.Insert(comment);
        //}
    }
}
