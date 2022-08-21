using System.ComponentModel.DataAnnotations;

namespace LcpPulse.Core.Models
{
    public class Client
    {
        [Required]
        public int ClientId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public DateTime? DOB { get; set; }

        [Required]
        public string Email { get; set; }
        public string Phone { get; set; }
        public Address Address { get; set; }
    }
}
