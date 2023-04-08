using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using LionsTimes.Entities.Dtos;
using LionsTimes.Shared.Utilities.Results.Abstract;

namespace LionsTimes.Mvc.Helpers.Abstract
{
    public interface IImageHelper
    {
        Task<IDataResult<ImageUploadedDto>> UploadUserImage(string userName, IFormFile pictureFile, string folderName = "userImages");
        IDataResult<ImageDeletedDto> Delete(string pictureName);
    }
}
