using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Api_Demo.Models.DTO;
using Web_Api_Demo.Repositories.DB;

namespace Web_Api_Demo.Service
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            base.CreateMap<OpportunityDTO, Opportunity>();
        }
    }
}