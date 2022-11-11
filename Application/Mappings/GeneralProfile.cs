using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Gatherings.GetGatheringById;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            this.CreateMap<Gathering, GetGatheringByIdItemResponse>();
            this.CreateMap<Member, MembersItemResponse>();
        }
    }
}
