

namespace central_fish_agency_dotnet.Boats
{
    public class BoatsService : IBoats
    {
        private static List<BoatsModel> boats = new List<BoatsModel>{
            new BoatsModel(),
            new BoatsModel {Id =1,BoatName = "Boat number 2" }
        };
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public BoatsService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetBoatsResponseDto>>> AddBoat(AddBoatRequestDto newBoat)
        {
            var servicesResponse = new ServiceResponse<List<GetBoatsResponseDto>>();
            var boat = _mapper.Map<BoatsModel>((newBoat));
            _context.Boats.Add(boat);
            await _context.SaveChangesAsync();
            servicesResponse.Message = $"boat with name '{newBoat.BoatName}' number '{newBoat.BoatNumber}' created successfully";
            return servicesResponse;
        }

        public async Task<ServiceResponse<List<GetBoatsResponseDto>>> DeleteBoats(int id)
        {
            var servicesResponse = new ServiceResponse<List<GetBoatsResponseDto>>();
            var boat = boats.FirstOrDefault(c => c.Id == id);

            if (boat is null)
            {
                throw new KeyNotFoundException($"boat with Id '{id}' not found.");
            }

            boats.Remove(boat);
            servicesResponse.Data = boats.Select(c => _mapper.Map<GetBoatsResponseDto>(c)).ToList();

            return servicesResponse;
        }

        public async Task<ServiceResponse<List<GetBoatsResponseDto>>> GetAllBoats()
        {
            var servicesResponse = new ServiceResponse<List<GetBoatsResponseDto>>();
            var dbBoats = await _context.Boats.ToListAsync();
            servicesResponse.Data = dbBoats.Select(c => _mapper.Map<GetBoatsResponseDto>(c)).ToList();
            return servicesResponse;
        }

        public async Task<ServiceResponse<GetBoatsResponseDto>> GetBoatById(int id)
        {
            var servicesResponse = new ServiceResponse<GetBoatsResponseDto>();
            var dbBoats = await _context.Boats.FirstOrDefaultAsync(c => c.Id == id);
            servicesResponse.Data = _mapper.Map<GetBoatsResponseDto>(dbBoats);
            if (servicesResponse.Data is null)
            {
                throw new KeyNotFoundException($"boat with Id '{id}' not found");
            }
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