using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelsFreak.MAUI.Service.IService;
using TravelsFreak.Models.DataTransferObject;
using TravelsFreak.Models.Status;

namespace TravelsFreak.MAUI.Service
{
    public class BlogService : IBlogService
    {
        private readonly HttpClient _httpClient;
        public BlogService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<BlogDTO> Get(int BlogId)
        {
            var response = await _httpClient.GetAsync($"/api/Blog/{BlogId}");
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var blog = JsonConvert.DeserializeObject<BlogDTO>(content);
                //tourpackage.TourPackageImageUrl = BaseServerURL + tourpackage.TourPackageImageUrl;
                return blog;
            }
            else
            {
                var errorModel = JsonConvert.DeserializeObject<ErrorModelDTO>(content);
                throw new Exception(errorModel.ErrorMessage);
            }
        }

        public async Task<IEnumerable<BlogDTO>> GetAll()
        {
            var response = await _httpClient.GetAsync("/api/Blog");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var blogs = JsonConvert.DeserializeObject<IEnumerable<BlogDTO>>(content);
                //foreach (var tp in tourpackages)
                //{
                //    tp.TourPackageImageUrl = BaseServerURL + tp.TourPackageImageUrl;
                //}
                return blogs;
            }
            return new List<BlogDTO>();
        }
    }
}

