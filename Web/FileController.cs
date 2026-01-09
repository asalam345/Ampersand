using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RapidFireLib.Lib.Core;
using RapidFireLib.Services.FileStorageService;

namespace Web
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        IStorageService _storageService;
        private readonly IConfiguration _configuration;
        public FileController(IConfig config, IConfiguration configuration, IStorageService storageService)
        {
            _storageService = storageService;
            _configuration = configuration;
        }
        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                    return BadRequest("No file selected.");

                long fileSizeInBytes = file.Length;
                long fileSizeInMegabytes = fileSizeInBytes / (1024 * 1024);
                string fileSize = _configuration["FileSize"]?.ToString() ?? string.Empty;
                int fileSizeInt = string.IsNullOrEmpty(fileSize) ? 5 : Convert.ToInt32(fileSize);
                if (fileSizeInMegabytes > fileSizeInt)
                    return BadRequest("File size is large than.");


                string fileExt = Path.GetExtension(file.FileName);

                string name = $"file_{Guid.NewGuid()}{fileExt}";
                using var memoryStream = new MemoryStream();
                file.CopyTo(memoryStream);
                name = (await _storageService.UploadAsync(name, memoryStream.ToArray(), "api")) as string ?? string.Empty;
                var ru = $"{Request.Scheme}://{Request.Host}{Request.PathBase}/";
                return Ok(name);
            }
            catch (Exception ex)
            {
                return Problem(title: "An unexpected error occurred.", detail: ex.Message);
            }
        }
    }
}
