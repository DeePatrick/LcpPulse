using System.ComponentModel.DataAnnotations;

namespace LcpPulse.Library.Models
{
    public class Client
    {
        [Required]
        public int ClientId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime? DOB { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }

        public Address Address { get; set; }
    }
}
