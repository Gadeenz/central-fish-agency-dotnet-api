

namespace central_fish_agency_dotnet.Boats
{
    public class BoatsService : IBoats
    {
        private static List<BoatsModel> boats = new List<BoatsModel>{
            new BoatsModel(),
            new BoatsModel {Id =1,BoatName = "Boat number 2" }
        };
        private readonly IMapper _mapper;

        public BoatsService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetBoatsResponseDto>>> AddBoat(AddBoatRequestDto newBoat)
        {
            var servicesResponse = new ServiceResponse<List<GetBoatsResponseDto>>();
            var boat = _mapper.Map<BoatsModel>((newBoat));
            boat.Id = boats.Max(c => c.Id) + 1;
            boats.Add(boat);
            servicesResponse.Data = boats.Select(c => _mapper.Map<GetBoatsResponseDto>(c)).ToList();
            return servicesResponse;
        }

        public async Task<ServiceResponse<List<GetBoatsResponseDto>>> DeleteBoats(int id)
        {
            var servicesResponse = new ServiceResponse<List<GetBoatsResponseDto>>();
            var boat = boats.FirstOrDefault(c => c.Id == id);

            if (boat is null)
            {
                throw new Exception($"boat with Id '{id}' not found.");
            }

            boats.Remove(boat);
            servicesResponse.Data = boats.Select(c => _mapper.Map<GetBoatsResponseDto>(c)).ToList();

            return servicesResponse;
        }

        public async Task<ServiceResponse<List<GetBoatsResponseDto>>> GetAllBoats()
        {
            var servicesResponse = new ServiceResponse<List<GetBoatsResponseDto>>();
            servicesResponse.Data = boats.Select(c => _mapper.Map<GetBoatsResponseDto>(c)).ToList();
            return servicesResponse;
        }

        public async Task<ServiceResponse<GetBoatsResponseDto>> GetBoatById(int id)
        {
            var servicesResponse = new ServiceResponse<GetBoatsResponseDto>();
            var boat = boats.FirstOrDefault(c => c.Id == id);
            if (boat is null)
            {
                throw new Exception($"boat with Id '{id}' not found");
            }
            servicesResponse.Data = _mapper.Map<GetBoatsResponseDto>((boat));
            return servicesResponse;
        }

        public async Task<ServiceResponse<GetBoatsResponseDto>> UpdateBoat(UpdateBoatDto updateBoat)
        {
            var servicesResponse = new ServiceResponse<GetBoatsResponseDto>();
            var boat = boats.FirstOrDefault(c => c.Id == updateBoat.Id);

            if (boat is null)
            {
                throw new Exception($"boat with Id '{updateBoat.Id}' not found.");
            }

            boat.BoatName = updateBoat.BoatName;
            boat.BoatNumber = updateBoat.BoatNumber;

            servicesResponse.Data = _mapper.Map<GetBoatsResponseDto>((boat));
            return servicesResponse;
        }
    }
}