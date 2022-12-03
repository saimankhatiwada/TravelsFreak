using Newtonsoft.Json;
using TravelFreak.Client.Service.IService;
using TravelsFreak.Models.DataTransferObject;
using TravelsFreak.Models.Status;

namespace TravelFreak.Client.Service
{
    public class BlogService : IBlogService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _Configuration;
        private string BaseServerURL;
        public BlogService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _Configuration = configuration;
            BaseServerURL = _Configuration.GetSection("BaseServerUrl").Value;
        }

        public async Task<BlogDTO> Get(int BlogId)
        {
            var response = await _httpClient.GetAsync($"/api/Blog/{BlogId}");
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var blog = JsonConvert.DeserializeObject<BlogDTO>(content);
                blog.BlogImageUrl = BaseServerURL + blog.BlogImageUrl;
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
                foreach (var blog in blogs)
                {
                    blog.BlogImageUrl = BaseServerURL + blog.BlogImageUrl;
                }
                return blogs;
            }
            return new List<BlogDTO>();
        }
    }
}
