using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSystem.Services.Interfaces
{
    public interface ICloudinaryService
    {
        Task<string> UploadPictureAsync(IFormFile pictureFile, string fileName);
    }
}
