using DBServer.Models;
using Microsoft.EntityFrameworkCore;

namespace DBServer.Data
{
    public class OnlineNodesContext : DbContext
    {
        public OnlineNodesContext(DbContextOptions<OnlineNodesContext> options) : base(options) { }

        public DbSet<OnlineNodes> OnlineNodes { get; set; }

    }
}
