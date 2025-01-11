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
        [RegularExpression(@"^\+27\d{9}$", ErrorMessage = "Phone number must start with +27 and be followed by 9 digits.")]
        public string PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Enter a valid email address.")]
        public string? Email { get; set; }
        
    }
}
