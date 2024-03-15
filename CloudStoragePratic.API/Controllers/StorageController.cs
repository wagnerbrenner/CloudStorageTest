using CloudStoragePratic.Application.UseCases.Users.UploadProfilePhoto;
using CloudStoragePraticApplication.UseCases.Users.UploadProfilePhoto;
using Microsoft.AspNetCore.Mvc;

namespace CloudStoragePratic.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StorageController : ControllerBase
{
    [HttpPost]
    public IActionResult UploadImage([FromServices] IUploadProfilePhotoUseCase useCase,IFormFile file)
    {
        useCase.Execute(file);

        return Created();
    }
}
