using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WebAppManagerContent.Helpers;

namespace WebAppManagerContent.Models
{
    public class AccountModel
    {

        public int IdUser { get; set; }
        [Required]
        [Display(Name = "Nombre de Usuario")]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [JsonIgnore]
        public string SPassword { get; set; }

        public byte[] Password { get; set; }

        [Required]
        [Display(Name = "Nombre completo")]
        public string FullName { get; set; }
        
        [Display(Name = "Dirección")]
        public string Address { get; set; }
        
        [Display(Name = "Celular")]
        public long Phone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Edad")]
        public int Age { get; set; }

        [Required]
        public int IdRole { get; set; }

        [Display(Name = "Rol")]
        public string nameRole { get; set; }


    }
}
