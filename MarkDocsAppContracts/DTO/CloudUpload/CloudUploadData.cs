using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarkDocsAppContracts.DTO.CloudUpload
{
    public class CloudUploadData
    {
        public string UserID { get; set; }
        public string Url { get; set; }
        public IFormFile File { get; set; }
    }
}
