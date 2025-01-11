using System.ComponentModel.DataAnnotations;

namespace PhoneBook_Application.Models
{
    //--------------------------------------------------------------------------------------------------------//

    /// <summary>
    /// Represents the data structure used to add a new contact in the phone book application.
    /// This model is typically used for form submissions when creating new contacts.
    /// </summary>
    public class AddContactViewModel
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Enter a valid email address.")]
        public string? Email { get; set; }
    }
}
        //---------------------------------------- END OF FILE -------------------------------------------------------//
