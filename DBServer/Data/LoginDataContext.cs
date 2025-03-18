using DBServer.Models;
using Microsoft.EntityFrameworkCore;

namespace DBServer.Data
{
    public class LoginDataContext : DbContext
    {
        public LoginDataContext(DbContextOptions<LoginDataContext> options) : base(options) { }

        public DbSet<LoginInfo> LoginInfo { get; set; }

    }
}
