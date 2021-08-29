using ContactsApp.API.DTO.Phone;
using System;
using System.Collections.Generic;

namespace ContactsApp.API.DTO.Contact
{
    public class ContactDetailsDTO
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public List<PhoneIndexDTO> Phones { get; set; }
    }
}
