using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;
using TravelsFreak.Server.Service.IService;

namespace TravelsFreak.Server.Service
{
    public class FileUpload : IFileUpload
    {
        private readonly IWebHostEnvironment _WebHostEnviroment;

        public FileUpload(IWebHostEnvironment webHostEnviroment)
        {
            _WebHostEnviroment = webHostEnviroment;
        }

        public bool DeleteFile(string filePath)
        {
            if(File.Exists(_WebHostEnviroment.WebRootPath + filePath))
            {
                File.Delete(_WebHostEnviroment.WebRootPath + filePath);
                return true;
            }
            return false;
        }

        public async Task<string> UploadFile(IBrowserFile file, string folder)
        {
            FileInfo fileInfo = new(file.Name);
            var fileName = Guid.NewGuid().ToString() + fileInfo.Extension;
            var folderDirectory = $"{_WebHostEnviroment.WebRootPath}\\images\\{folder}";
            if(!Directory.Exists(folderDirectory))
            {
                Directory.CreateDirectory(folderDirectory);
            }
            var filePath = Path.Combine(folderDirectory, fileName);
            await using FileStream fs = new FileStream(filePath, FileMode.Create);
            await file.OpenReadStream().CopyToAsync(fs);
            var fullPath = $"/images/{folder}/{fileName}";
            return fullPath;
        }
    }
}
