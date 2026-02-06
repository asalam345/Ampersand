using System;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class FileUploadService : IFileUploadService
    {
        private readonly IWebHostEnvironment _env;

        public FileUploadService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<string> UploadAsync(IBrowserFile file, string folderName)
        {
            if (file == null)
                return string.Empty;

            var uploadPath = Path.Combine(_env.WebRootPath, "files", folderName);

            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);
            //file_5c05f6d5-5895-416e-ab26-347b369fbc32_rffile_Screenshot 2025-12-19 225500
            var fileName = $"file_{Guid.NewGuid()}_rffile_{file.Name}";
            var fullPath = Path.Combine(uploadPath, fileName);

            await using var stream = new FileStream(fullPath, FileMode.Create);
            await file.OpenReadStream(maxAllowedSize: 10 * 1024 * 1024).CopyToAsync(stream); // 10MB

            return $"files/{folderName}/{fileName}";
        }
    }
    public interface IFileUploadService
    {
        Task<string> UploadAsync(IBrowserFile file, string folderName);
    }


}
