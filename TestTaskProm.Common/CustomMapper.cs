using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TestTaskProm.Domain.Entities;
using TestTaskProm.Dto.Models.V1;

namespace TestTaskProm.Common
{
    public class CustomMapper: Profile
    {
        public CustomMapper()
        {
            CreateMap<Province, ProvinceDto>();
            CreateMap<ProvinceDto, Province>();

            CreateMap<Country, CountryDto>();
            CreateMap<CountryDto, Country>();
        }
    }
}
