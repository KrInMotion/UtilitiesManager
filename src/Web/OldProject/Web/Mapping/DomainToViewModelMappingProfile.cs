using AutoMapper;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models;

namespace Web.Mapping
{
    public class DomainToViewModelMappingProfile: Profile
    {
        public override string ProfileName
        {
            get
            {
                return "DomainToViewModelMapping";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<BillType, BillTypeViewModel>()
                .ForMember(dest => dest.BillCount,  map => map.MapFrom(src => src.Bills.Count()));
            Mapper.CreateMap<BillType, BillTypeFormModel>();
        }
    }
}