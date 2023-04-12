using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace central_fish_agency_dotnet.Boats.Dtos
{
    public class GetBoatsResponseDto
    {
        public int Id { get; set; }
        public string BoatName { get; set; } = "Boats Number 1";

        public string BoatNumber { get; set; } = "BAT0001-42023";
    }
}