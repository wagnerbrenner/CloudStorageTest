using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudStoragePratic.Application.UseCases.Users.UploadProfilePhoto;
public interface IUploadProfilePhotoUseCase
{

    public void Execute(IFormFile file);
}
