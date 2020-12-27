using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagerApi.Models
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "binary(64)")]
        public Byte[] Password { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string FullName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Address { get; set; }

        [Column(TypeName = "numeric(18,0)")]
        public long Phone { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; }

        [Column(TypeName = "numeric(3,0)")]
        public long Age { get; set; }

        [Required]
        public int IdRole { get; set; }
    }
}
