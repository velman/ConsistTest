using AutoMapper;
using ConsistTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsistTest
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Person, PersonDto>().ReverseMap();
        }
    }
}
