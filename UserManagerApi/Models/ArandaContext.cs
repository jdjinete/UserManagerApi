using Microsoft.EntityFrameworkCore;
using UserManagerApi.Models;

namespace UserManagerApi.Models
{
    public class ArandaContext : DbContext
    {
        public ArandaContext(DbContextOptions<ArandaContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }

        public DbSet<Role> Role { get; set; }
    }
}
