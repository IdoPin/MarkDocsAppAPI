using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarkDocsAppContracts.DTO.CloudUpload
{
    public class FileUploadResponseError : FileUploadResponse
    {
        public IFormFile File { get; }
        public FileUploadResponseError(IFormFile file)
        {
            File = file;
        }
    }
}
