using ContactsApp.API.DTO.Phone;
using ContactsApp.API.Validators;
using System;
using System.ComponentModel.DataAnnotations;

namespace ContactsApp.API.DTO.Contact
{
    public class ContactAddDTO
    {
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(255)]
        public string Email { get; set; }

        [BirthDateValidator]
        public DateTime? BirthDate { get; set; }
        public PhoneAddDTO Phone { get; set; }
    }
}
