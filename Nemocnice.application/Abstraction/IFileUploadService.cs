using Microsoft.AspNetCore.Http;

namespace Nemocnice.application.Abstraction
{
    public interface IFileUploadService
    {
        string FileUpload(IFormFile fileToUpload, string folderNameOnServer);
    }
}
