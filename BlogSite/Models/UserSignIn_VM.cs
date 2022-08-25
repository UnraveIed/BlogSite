using System.ComponentModel.DataAnnotations;

namespace BlogSite.Models
{
    public class UserSignIn_VM
    {
        //[Required(ErrorMessage ="Lutfen kullanici adini giriniz")]
        public string UserName { get; set; }
        //[Required(ErrorMessage = "Lutfen sifrenizi giriniz")]
        public string Password { get; set; }
    }
}
