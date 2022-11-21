using TravelsFreak.Models.DataTransferObject;

namespace TravelsFreak.Repository.IRepository
{
    public interface IDestinationsRepository
    {
        public Task<DestinationsDTO> Create(DestinationsDTO objectDTO);
        public Task<DestinationsDTO> Update(DestinationsDTO objectDTO);
        public Task<int> Delete(int id);
        public Task<DestinationsDTO> Get(int id);
        public Task<IEnumerable<DestinationsDTO>> GetAll();
    }
}
