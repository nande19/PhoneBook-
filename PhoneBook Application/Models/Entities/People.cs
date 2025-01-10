using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace PhoneBook_Application.Models.Entities
{
    public class People
    {

        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(1000000000, 9999999999, ErrorMessage = "Enter a valid phone number.")]
        public int PhoneNumber {  get; set; }

        [EmailAddress(ErrorMessage = "Enter a valid email address.")]
        public string? Email { get; set; }
        
    }
}
