using FluentAssertions;
using LcpPulse.Controllers;
using LcpPulse.Core;
using LcpPulse.Core.Models;
using LcpPulse.Core.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace LcpPulse.Tests.Controllers.Api
{

    public class ClientsControllerTests
    {
        private readonly ClientsController _controller;
        private readonly Mock<IClientRepository> _mockRepository;

        public ClientsControllerTests()
        {
            _mockRepository = new Mock<IClientRepository>();
            var mockUoW = new Mock<IUnitOfWork>();
            mockUoW.SetupGet(u => u.Clients).Returns(_mockRepository.Object);
            _controller = new ClientsController(mockUoW.Object);


        }

        [Fact]
        public async Task DeleteClient_NoClientIdExists_ShouldReturnNotFound()
        {
            //Arrange

            //Act
            var result  = await _controller.DeleteClient(1);
            //Assert
            result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task DeleteClient_ValidRequest_ShouldReturnOK()
        {
            //Arrange
            var client = new Client()
            {
                ClientId = 1,
                FirstName = "James",
                LastName = "Bond",
                Email = "jbond@gmail.com"
            };
            _mockRepository.Setup(r => r.GetClientAsync(client.ClientId)).ReturnsAsync(client);

            //Act
            var result = await _controller.DeleteClient(client.ClientId);
            //Assert
            result.Should().BeOfType<OkResult>();

        }
    }
}
