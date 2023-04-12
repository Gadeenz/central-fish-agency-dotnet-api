using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace central_fish_agency_dotnet.Common.Middleware
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BoatsModel, GetBoatsResponseDto>();
            CreateMap<AddBoatRequestDto, BoatsModel>();
        }

    }
}