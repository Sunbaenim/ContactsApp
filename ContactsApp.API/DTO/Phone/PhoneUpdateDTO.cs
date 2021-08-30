using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsApp.API.DTO.Phone
{
    public class PhoneUpdateDTO
    {
        [Required]
        [MaxLength(25)]
        public string Type { get; set; }
        [Required]
        [Phone]
        [MaxLength(25)]
        public string Number { get; set; }
    }
}
