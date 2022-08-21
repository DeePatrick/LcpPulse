using FluentAssertions;
using LcpPulse.Core.Models;
using LcpPulse.Persistence;
using LcpPulse.Persistence.Repositories;
using LcpPulse.Tests.Extensions;
using Microsoft.EntityFrameworkCore;
using Moq;


namespace LcpPulse.Tests.Persistence.Repositories
{
    public class ClientRepositoryTests
    {
        private readonly ClientRepository _clientRepository;
        private readonly Mock<DbSet<Client>> _mockClient;

        
        public ClientRepositoryTests()
        {
            _mockClient = new Mock<DbSet<Client>>();
            var mockContext = new Mock<IApplicationDbContext>();
            mockContext.Setup(c => c.Clients).Returns(_mockClient.Object);
            _clientRepository = new ClientRepository(mockContext.Object);
        }

        

    }
}
