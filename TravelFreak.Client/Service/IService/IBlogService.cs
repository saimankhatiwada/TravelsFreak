using TravelsFreak.Models.DataTransferObject;

namespace TravelFreak.Client.Service.IService
{
    public interface IBlogService
    {
        public Task<IEnumerable<BlogDTO>> GetAll();

        public Task<BlogDTO> Get(int BlogId);
    }
}
