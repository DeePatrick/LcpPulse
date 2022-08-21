using Client = LcpPulse.Core.Models.Client;

namespace LcpPulse.Core.Repositories;

public interface IClientRepository
{
    Task<IEnumerable<Client>> GetAllClientInfoAsync();
    Task<Client?> GetClientAsync(int id);
    void Add(Client client);
    void Remove(Client client);
}