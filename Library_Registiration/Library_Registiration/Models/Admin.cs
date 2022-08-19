using System.ComponentModel.DataAnnotations;

namespace Library_Registiration.Models
{
    public class Admin
    {
        [Key]
        public int Admin_id { get; set; }

        [Required(ErrorMessage ="Please Enter username")]
        public string Admin_username { get; set; }

        [Required(ErrorMessage = "Please Enter password")]
        public string Admin_password { get; set; }
    }
}
