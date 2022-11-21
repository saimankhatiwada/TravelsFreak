using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using TravelsFreak.MAUI.Service.IService;
using TravelsFreak.Models.DataTransferObject;
using TravelsFreak.Models.Status;

namespace TravelFreak.Client.Service
{
    public class TourPackageService : ITourPackageService
    {
        private readonly HttpClient _httpClient;
        public TourPackageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<TourPackageDTO> Get(int TourPackageId)
        {
            var response = await _httpClient.GetAsync($"/api/TourPackage/{TourPackageId}");
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var tourpackage = JsonConvert.DeserializeObject<TourPackageDTO>(content);
                //tourpackage.TourPackageImageUrl = BaseServerURL + tourpackage.TourPackageImageUrl;
                return tourpackage;
            }
            else
            {
                var errorModel = JsonConvert.DeserializeObject<ErrorModelDTO>(content);
                throw new Exception(errorModel.ErrorMessage);
            }
        }

        public async Task<IEnumerable<TourPackageDTO>> GetAll()
        {
            var response = await _httpClient.GetAsync("/api/TourPackage");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var tourpackages = JsonConvert.DeserializeObject<IEnumerable<TourPackageDTO>>(content);
                //foreach (var tp in tourpackages)
                //{
                //    tp.TourPackageImageUrl = BaseServerURL + tp.TourPackageImageUrl;
                //}
                return tourpackages;
            }
            return new List<TourPackageDTO>();
        }
    }
}
