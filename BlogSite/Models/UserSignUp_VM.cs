using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlogSite.Models
{
    public class UserSignUp_VM
    {
        [Display(Name ="Ad Soyad")]
        [Required(ErrorMessage ="Lutfen ad soyad giriniz")]
        public string NameSurname { get; set; }

        [Display(Name = "Sifre")]
        [Required(ErrorMessage = "Lutfen sifre giriniz")]
        public string Password { get; set; }

        [Display(Name = "Sifre Tekrar")]
        [Compare("Password",ErrorMessage ="Sifreler uyusmuyor")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Mail Adresi")]
        [Required(ErrorMessage = "Lutfen mail giriniz")]
        public string Mail { get; set; }

        [Display(Name = "Kullanici Adi")]
        [Required(ErrorMessage = "Lutfen kullanici adini giriniz")]
        public string UserName { get; set; }

    }
}
