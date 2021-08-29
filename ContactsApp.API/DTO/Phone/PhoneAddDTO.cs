using System.ComponentModel.DataAnnotations;

namespace ContactsApp.API.DTO.Phone
{
    public class PhoneAddDTO
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
