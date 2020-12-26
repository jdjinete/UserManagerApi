using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagerApi.Models
{
    public class AuthtenticationDTO
    {
        public string Name { get; set; }
        public Byte[] Password { get; set; }
    }
}
