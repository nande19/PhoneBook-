using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace PhoneBook_Application.Models.Entities
{
    public class People
    {
        //--------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// This maps to the database table to store the contact details.
        /// </summary>
        /// 

        //primary key used for unique identification
        public Guid Id { get; set; }

        //the rest are variables for storing what the user enters

        [Required]
        public string Name { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^\+27\d{9}$", ErrorMessage = "Phone number must start with +27 and be followed by 9 digits.")]
        public string PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Enter a valid email address.")]
        public string? Email { get; set; }
        
    }
}
        //---------------------------------------- END OF FILE -------------------------------------------------------//
