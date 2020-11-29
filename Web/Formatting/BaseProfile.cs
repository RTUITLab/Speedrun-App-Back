using AutoMapper;
using Models;
using PublicApi.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Formatting
{
    public class BaseProfile : Profile
    {
        public BaseProfile()
        {
            CreateMap<Stream, Tournament>();
            CreateMap<PulseMessage, PulseMessageResponse>();
        }
    }
}
