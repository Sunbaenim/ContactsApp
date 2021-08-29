using System;
using System.Collections.Generic;

namespace ContactsApp.DAL.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public List<Phone> Phones { get; set; }
    }
}
