using System;
using System.Collections.Generic;
using System.Text;

namespace MarkDocsAppContracts.DTO.CloudUpload
{
    public class FileUploadResponseOK : FileUploadResponse
    {
        public string Url { get; }
        public FileUploadResponseOK(string url)
        {
            Url = url;
        }
    }
}
