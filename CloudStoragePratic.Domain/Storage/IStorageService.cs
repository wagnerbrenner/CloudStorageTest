using CloudStoragePratic.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace CloudStoragePratic.Domain.Storage;
public interface IStorageService
{
    string Upload(IFormFile file, User user );
}
