using LcpPulse.Core;
using Microsoft.AspNetCore.Mvc;
using Client = LcpPulse.Core.Models.Client;

namespace LcpPulse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClientsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Clients
        [HttpGet]
        public async Task<IEnumerable<Client>> GetClients()
        {
            return await _unitOfWork.Clients.GetAllClientInfoAsync();
        }


        // GET: api/Clients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            var client = await _unitOfWork.Clients.GetClientAsync(id);

            if (client != null) return client;
            return NotFound();

        }

        // PUT: api/Clients/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(int id, Client client)
        {
            if (id != client.ClientId)
            {
                return BadRequest();
            }
            var existingClient = await _unitOfWork.Clients.GetClientAsync(id);

            if (existingClient != null)
            {
                existingClient.FirstName = client.FirstName;
                existingClient.LastName = client.LastName;
                existingClient.DOB = client.DOB;
                existingClient.Email = client.Email;
                existingClient.Phone = client.Phone;
                existingClient.Address = client.Address;

                await _unitOfWork.Complete();
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }

        // POST: api/Clients

        [HttpPost]
        public async Task<ActionResult<Client>> PostClient(Client client)
        {
            _unitOfWork.Clients.Add(client);
            await _unitOfWork.Complete();

            return CreatedAtAction("GetClient", new { id = client.ClientId }, client);
        }

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var client = await _unitOfWork.Clients.GetClientAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            _unitOfWork.Clients.Remove(client);
            await _unitOfWork.Complete();

            return Ok();
        }
    }
}
