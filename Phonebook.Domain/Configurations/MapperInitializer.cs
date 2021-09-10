using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Phonebook.Domain.DTO;
using Phonebook.Domain.Models;

namespace Phonebook.Domain.Configurations
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<Contact, ContactDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
