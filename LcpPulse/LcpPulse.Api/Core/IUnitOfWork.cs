using LcpPulse.Core.Repositories;
using LcpPulse.Persistence.Repositories;

namespace LcpPulse.Core;

public interface IUnitOfWork
{
    IClientRepository Clients { get; }
    Task Complete();
}