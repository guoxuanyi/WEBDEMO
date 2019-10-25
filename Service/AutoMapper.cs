using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Api_Demo.Models.DTO;
using Web_Api_Demo.Repositories.DB;

namespace Web_Api_Demo.Service
{
    public static class AutoMapper
    {
        public static void Register(IMapperConfigurationExpression cfg)
        {
            cfg.AddProfile<AutoMapperProfile>();
        }

        public static void Register()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
        }
    }
}