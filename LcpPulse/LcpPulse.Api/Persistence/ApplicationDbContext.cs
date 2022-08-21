using Microsoft.EntityFrameworkCore;
using Client = LcpPulse.Core.Models.Client;

namespace LcpPulse.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Client> Clients { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}