using Microsoft.AspNetCore.Mvc;
using ShiftSoftware.ShiftEntity.Model;
using ShiftSoftware.ShiftEntity.Model.Dtos;
using System.Drawing;
using ShiftSoftware.ShiftEntity.Web.Services;
using ShiftSoftware.TypeAuth.AspNetCore;
using ToDo.Shared;

namespace ToDo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private AzureStorageService azureStorageService;

        public FileController(AzureStorageService azureStorageService)
        {
            this.azureStorageService = azureStorageService;
        }

        [HttpPost("upload")]
        [TypeAuth(typeof(ToDoActions), nameof(ToDoActions.UploadFiles), ShiftSoftware.TypeAuth.Core.Access.Write)]
        public async Task<IActionResult> UploadAsync(IFormFile file)
        {
            var res = new ShiftEntityResponse<ShiftFileDTO>();
            string? cloudUrl;
            string? blob;
            try
            {
                blob = await azureStorageService.UploadAsync(file);
                cloudUrl = azureStorageService.GetSignedURL(blob);

                if (blob == null) throw new Exception("Could not retrieve blob name");
                if (cloudUrl == null) throw new Exception("Could not retrieve blob url");
            }
            catch (Exception e)
            {
                res.Message = new Message { Title = "Failed to upload file to the cloud", Body = e.Message};
                return Ok(res);
            }

            res.Entity = new ShiftFileDTO
            {
                Name = file.FileName,
                Url = cloudUrl,
                Blob = blob,
                ContentType = file.ContentType,
                Size = file.Length,
            };

            try
            {
                if (file.ContentType.StartsWith("image"))
                {
                    var memoryStream = new MemoryStream();
                    file.CopyTo(memoryStream);
                    Image image = Image.FromStream(memoryStream);

                    res.Entity.Width = image.Width;
                    res.Entity.Height = image.Height;
                }
            }
            catch
            {
                res.Message = new Message { Title = "Could not parse image" };
            }

            return Ok(res);
        }
    }
}
