using ContactsApp.API.DTO.Contact;
using ContactsApp.API.DTO.Phone;
using ContactsApp.DAL;
using ContactsApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolBox.AutoMapper.Mappers;

namespace ContactsApp.API.Services
{
    public class ContactService
    {
        private readonly ContactDbContext dc;

        public ContactService(ContactDbContext dc)
        {
            this.dc = dc;
        }

        public void Create(ContactAddDTO dto)
        {
            Contact saved = dc.Contacts.Add(dto.MapTo<Contact>()).Entity;
            dc.SaveChanges();
        }

        public IEnumerable<ContactIndexDTO> Read(ContactFilterDTO filter)
        {
            //if (filter.LastName is null) return dc.Contacts.MapToList<ContactIndexDTO>();
            return dc.Contacts
                //.Where()
                .Where(c => filter.LastName == null || c.LastName == filter.LastName)
                .OrderBy(c => c.LastName)
                .ThenBy(c => c.FirstName)
                .MapToList<ContactIndexDTO>();
        }

        public ContactDetailsDTO GetByID(int id)
        {
            Contact contact = dc.Contacts
                .Include(c => c.Phones)
                .FirstOrDefault(c => c.Id == id);
            return contact?.MapTo<ContactDetailsDTO>(c => c.Phones = contact.Phones.MapToList<PhoneIndexDTO>().ToList());
        }

        public void Update(int id, ContactUpdateDTO form)
        {
            Contact contact = dc.Contacts.Find(id);
            form.MapToInstance<Contact>(contact);
            dc.SaveChanges();
        }

        public void Delete(int id)
        {
            dc.Contacts.Remove(
                dc.Contacts
                .Where(c => c.Id == id)
                .FirstOrDefault()
                );
            dc.SaveChanges();
        }
    }
}
