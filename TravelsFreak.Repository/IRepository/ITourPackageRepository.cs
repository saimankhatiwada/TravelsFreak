using TravelsFreak.Models.DataTransferObject;

namespace TravelsFreak.Repository.IRepository
{
    public interface ITourPackageRepository
    {
        public Task<TourPackageDTO> Create(TourPackageDTO objectDTO);
        public Task<TourPackageDTO> Update(TourPackageDTO objectDTO);
        public Task<int> Delete(int id);
        public Task<TourPackageDTO> Get(int id);
        public Task<IEnumerable<TourPackageDTO>> GetAll();
    }
}
