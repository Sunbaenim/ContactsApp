using ContactsApp.API.DTO.Contact;
using ContactsApp.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private ContactService cService;

        public ContactController(ContactService cService)
        {
            this.cService = cService;
        }

        [HttpGet]
        public IActionResult GetContacts([FromQuery] ContactFilterDTO filter)
        {
            return Ok(cService.Read(filter));
        }

        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            ContactDetailsDTO dto = cService.GetByID(id);
            if (dto == null) return NotFound();
            return Ok(dto);
        }

        [HttpPost]
        public IActionResult AddContact(ContactAddDTO form)
        {
            cService.Create(form);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateContact(int id, ContactAddDTO form)
        {
            cService.Update(id, form);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            cService.Delete(id);
            return Ok(id);
        }
    }
}
