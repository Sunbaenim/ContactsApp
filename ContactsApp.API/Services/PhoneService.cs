using ContactsApp.API.DTO.Phone;
using ContactsApp.DAL;
using ContactsApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolBox.AutoMapper.Mappers;

namespace ContactsApp.API.Services
{
    public class PhoneService
    {
        private readonly ContactDbContext dc;

        public PhoneService(ContactDbContext dc)
        {
            this.dc = dc;
        }

        public void Create(PhoneAddDTO dto)
        {
            dc.Phones.Add(dto.MapTo<Phone>());
            dc.SaveChanges();
        }

        public IEnumerable<PhoneIndexDTO> Read(int id)
        {
            return dc.Phones
                .Where(p => p.ContactId == id)
                .MapToList<PhoneIndexDTO>();
        }


        public void Update(int id, PhoneUpdateDTO dto)
        {
            Console.WriteLine("ALLLLOOOOOOOOOOO");
            Phone phone = dc.Phones.Where(p => p.ContactId == id).FirstOrDefault();
            dto.MapToInstance<Phone>(phone);
            dc.SaveChanges();
        }

        public void Delete(int id)
        {
            dc.Phones.Remove(
                dc.Phones
                .Where(p => p.Id == id)
                .FirstOrDefault()
                );
            dc.SaveChanges();
        }
    }
}
