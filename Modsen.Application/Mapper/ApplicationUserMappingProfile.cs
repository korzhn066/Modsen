using AutoMapper;
using Modsen.Domain.Entities;
using Modsen.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modsen.Application.Mapper
{
    public class ApplicationUserMappingProfile : Profile
    {
        public ApplicationUserMappingProfile() 
        {
            CreateMap<Authentication, ApplicationUser>();
        }
    }
}
