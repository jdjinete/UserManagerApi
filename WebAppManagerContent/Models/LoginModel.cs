using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebAppManagerContent.Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "Nombre de Usuario")]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [JsonIgnore]
        public string SPassword { get; set; }

        public byte[] Password { get; set; }
    }
}
