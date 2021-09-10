using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Domain.DTO
{
    public class UserDto
    {
        public string FirstName {  get; set; }  
        public string LastName {  get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email {  get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Your password is limited to {2} to {1} characters")]
        public string Password { get; set; }
        public ICollection<string> Roles { get; set; }
    }
}
