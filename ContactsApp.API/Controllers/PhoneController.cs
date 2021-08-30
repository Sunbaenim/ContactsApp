using ContactsApp.API.DTO.Phone;
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
    public class PhoneController : ControllerBase
    {
        private PhoneService pService;

        public PhoneController(PhoneService pService)
        {
            this.pService = pService;
        }

        [HttpGet("{id}")]
        public IActionResult GetPhones(int id)
        {
            return Ok(pService.Read(id));
        }

        [HttpPost]
        public IActionResult AddPhone(PhoneAddDTO dto)
        {
            pService.Create(dto);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePhone(int id, PhoneUpdateDTO dto)
        {
            pService.Update(id, dto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeletePhone(int id)
        {
            pService.Delete(id);
            return NoContent();
        }
    }
}
