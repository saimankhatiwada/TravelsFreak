using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelsFreak.Models.DataTransferObject;

namespace TravelsFreak.MAUI.Service.IService
{
    public interface IBlogService
    {
        public Task<IEnumerable<BlogDTO>> GetAll();

        public Task<BlogDTO> Get(int BlogId);
    }
}
