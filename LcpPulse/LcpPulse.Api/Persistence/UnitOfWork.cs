using LcpPulse.Core;
using LcpPulse.Core.Repositories;
using LcpPulse.Data;
using LcpPulse.Persistence.Repositories;

namespace LcpPulse.Persistence
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IClientRepository Clients { get; private set; }
        public UnitOfWork(ApplicationDbContext context,  IClientRepository clients)
        {
            _context = context;
            Clients = clients;
        }

        public async Task Complete()
        {
            await _context.SaveChangesAsync();
        }
    }
}