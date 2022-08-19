using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_Registiration.Models
{
    public class Publisher
    {
        [Key]
        public int Publisher_id { get; set; }

        [Required(ErrorMessage = "Please enter publisher name")]
        public string Publisher_name { get; set; }

        [Required(ErrorMessage = "Please enter information about publisher")]
        public string Publisher_About { get; set; }

        [Required(ErrorMessage ="Please Enter E-mail")]
        public string Publisher_Mail { get; set; }
        public string Publisher_resim_yol { get; set; }
        [NotMapped]
        public IFormFile publisher_Resim { get; set; }

    }
}
