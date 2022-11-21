using TravelsFreak.Models.DataTransferObject;

namespace TravelsFreak.MAUI.Service.IService
{
    public interface ITourPackageService
    {
        public Task<IEnumerable<TourPackageDTO>> GetAll();

        public Task<TourPackageDTO> Get(int TourPackageId);
    }
}
