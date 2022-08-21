using LcpPulse.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace LcpPulse.Persistence;

public interface IApplicationDbContext
{
    DbSet<Client> Clients { get; set; }
}