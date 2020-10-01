using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MarkDocsAppContracts.DTO.CloudUpload;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MarkDocsAppContracts.DTO;
using System;
using Microsoft.AspNetCore.Http;

namespace MarkDocsApp.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CloudUploadController : ControllerBase
    {

        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
        private Cloudinary _cloudinary;
        public CloudUploadController(IOptions<CloudinarySettings> cloudinaryConfig)
        {
            _cloudinaryConfig = cloudinaryConfig;


            Account acc = new Account(
                _cloudinaryConfig.Value.CloudName,
                _cloudinaryConfig.Value.ApiKey,
                _cloudinaryConfig.Value.ApiSecret
            );

            _cloudinary = new Cloudinary(acc);
        }



        [HttpPost]
        public async Task<Response> UploadPhoto([FromForm(Name = "File")] IFormFile File)
        {
            Response response = new FileUploadResponseError(File);

            var file = File;
            Console.WriteLine(file);


            var uploadResult = new ImageUploadResult();
            try
            {
                if (file.Length > 0)
                {
                    using (var stream = file.OpenReadStream())
                    {
                        var uploadParams = new ImageUploadParams
                        {
                            File = new FileDescription(file.FileName, stream),
                        };

                        uploadResult =  _cloudinary.Upload(uploadParams);
                    }
                }
                response = new FileUploadResponseOK(uploadResult.Url.ToString());
            }
            catch(Exception ex)
            {
                response = new AppResponseError(ex.Message);
            }

            return response;
            
        }

 
    }
}