using Microsoft.AspNetCore.Components.Forms;

namespace TravelsFreak.Server.Service.IService
{
    public interface IFileUpload
    {
        Task<string> UploadFile(IBrowserFile file, string folder);
        bool DeleteFile(string filePath);
    }
}
