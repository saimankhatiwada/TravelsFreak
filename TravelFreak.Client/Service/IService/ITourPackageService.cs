using TravelsFreak.Models.DataTransferObject;

namespace TravelFreak.Client.Service.IService
{
    public interface ITourPackageService
    {
        public Task<IEnumerable<TourPackageDTO>> GetAll();

        public Task<TourPackageDTO> Get(int TourPackageId);
    }
}
