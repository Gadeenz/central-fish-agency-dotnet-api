

namespace central_fish_agency_dotnet.Boats.interfaces
{
    public interface IBoats
    {
        Task<ServiceResponse<List<GetBoatsResponseDto>>> GetAllBoats();

        Task<ServiceResponse<GetBoatsResponseDto>> GetBoatById(int id);

        Task<ServiceResponse<List<GetBoatsResponseDto>>> AddBoat(AddBoatRequestDto newBoat);
        Task<ServiceResponse<GetBoatsResponseDto>> UpdateBoat(UpdateBoatDto updateBoat);
    }
}