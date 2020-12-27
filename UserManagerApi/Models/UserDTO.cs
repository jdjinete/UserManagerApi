using System;

namespace UserManagerApi.Models
{
    public class UserDTO
    {
            public int IdUser { get; set; }
            public string Name { get; set; }
            public Byte[] Password { get; set; }
            public string FullName { get; set; }

            public string Address { get; set; }

            public Decimal Phone { get; set; }

            public string Email { get; set; }

            public Decimal Age { get; set; }

            public int IdRole { get; set; }

            public string Description { get; set; }
    }
}
