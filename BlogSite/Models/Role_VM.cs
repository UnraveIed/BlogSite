

using System.ComponentModel.DataAnnotations;

namespace BlogSite.Models
{
    public class Role_VM
    {
        [Required(ErrorMessage ="Lütfen rol adı giriniz")]
        public string Name { get; set; }
    }
}
