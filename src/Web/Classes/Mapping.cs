using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models.Entities;
using Web.ViewModels;

namespace Web.Classes
{
    public static class Mapping
    {
        public static void Initialize()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<BillType, BillTypeListVM>()
                .ForMember(dest => dest.BillCount, map => map.MapFrom(src => src.Bills.Count()));
                
            });
        }
    }
}
