using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace Domain.Services
{
    public class DownloadService
    {
        private readonly IWebHostEnvironment _env;

        public DownloadService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public (byte[]? FileBytes, string ContentType, string DownloadFileName, bool Success)
            GetSofTemplateFile(string fileName)
        {
            var filePath = Path.Combine(_env.WebRootPath, fileName);

            if (!File.Exists(filePath))
                return (null, "", "", false);

            var fileBytes = File.ReadAllBytes(filePath);
            var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            var downloadName = "SOF (Project) Template.xlsx";

            return (fileBytes, contentType, downloadName, true);
        }
    }
}
