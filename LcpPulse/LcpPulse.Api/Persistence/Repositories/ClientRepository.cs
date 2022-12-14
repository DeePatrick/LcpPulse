using LcpPulse.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Client = LcpPulse.Core.Models.Client;

namespace LcpPulse.Persistence.Repositories
{
    public class ClientRepository: IClientRepository
    {
        private readonly IApplicationDbContext _context;

        public ClientRepository(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Client>> GetAllClientInfoAsync()
        {
            return await _context.Clients
                .Include(a => a.Address)
                .ToListAsync();
        }

        public async Task<Client?> GetClientAsync(int id)
        {
            return await _context.Clients.FindAsync(id);
        }

        public void Add(Client client)
        {
            _context.Clients.Add(client);
        }

        public void Remove(Client client)
        {
            _context.Clients.Remove(client);
        }


    }
}
