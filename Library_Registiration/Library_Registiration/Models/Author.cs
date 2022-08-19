using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_Registiration.Models
{
    public class Author
    {
        [Key]
        public int Author_id { get; set; }

        [Required(ErrorMessage = "Please enter author name")]
        public string Author_name { get; set; }

        [Required(ErrorMessage ="please Enter Age")]
        public string Author_age { get; set; }

        [Required(ErrorMessage = "Please enter information about author")]
        public string Author_about { get; set; }
        public string Author_resim_yol { get; set; }
        [NotMapped]
        public IFormFile Author_resim { get; set; }
    }
}
