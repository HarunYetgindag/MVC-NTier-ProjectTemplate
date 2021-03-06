using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_TemplateProject.Entities
{
    [Table("Users")]
    public class User : EntityBase
    {
        [DisplayName("İsim"), StringLength(25, ErrorMessage = "{0} alanı max {1} karakter olmalıdır.")]
        public string Name { get; set; }

        [DisplayName("Soyad"), StringLength(25, ErrorMessage = "{0} alanı max {1} karakter olmalıdır.")]
        public string Surname { get; set; }

        [DisplayName("Kullanıcı Adı"), Required(ErrorMessage = "{0} Alanı gereklidir"), StringLength(25, ErrorMessage = "{0} alanı max {1} karakter olmalıdır.")]
        public string Username { get; set; }

        [DisplayName("E-Posta"), Required(ErrorMessage = "{0} Alanı gereklidir"), StringLength(70, ErrorMessage = "{0} alanı max {1} karakter olmalıdır.")]
        public string Email { get; set; }

        [DisplayName("Şifre"), Required(ErrorMessage = "{0} Alanı gereklidir"), StringLength(150, ErrorMessage = "{0} alanı max {1} karakter olmalıdır.")]
        public string Password { get; set; }

        [StringLength(30), ScaffoldColumn(false)]
        public string ProfileImageFilename { get; set; }

        [DisplayName("Is Active")]
        public bool IsActive { get; set; }

        [Required, ScaffoldColumn(false)]
        public Guid ActivateGuid { get; set; }

        [DisplayName("Is Admin")]
        public bool IsAdmin { get; set; }
    }
}
