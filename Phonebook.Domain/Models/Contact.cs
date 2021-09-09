using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Domain.Models
{
    public class Contact
    {
        [Key]
        public string Id {  get; set; } 
        public string FirstName {  get; set; }
        public string LastName {  get; set; }
        public string Email {  get; set; }  
        public string Phone {  get; set; }
        public string ImageUrl { get; set; }
        public Contact()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
