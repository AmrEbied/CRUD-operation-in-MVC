using System.ComponentModel.DataAnnotations;

namespace TaxiBooking.Models.DTO.UserDto
{
    public class LogInDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}