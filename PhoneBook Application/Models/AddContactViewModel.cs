using System.ComponentModel.DataAnnotations;

namespace PhoneBook_Application.Models
{
    public class AddContactViewModel
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Enter a valid email address.")]
        public string? Email { get; set; }
    }
}
