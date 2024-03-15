using CloudStoragePratic.Domain.Entities;
using CloudStoragePratic.Domain.Storage;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Drive.v3;
using Microsoft.AspNetCore.Http;

namespace CloudStoragePratic.Infrastructure.Storage;
public class GoogleDriveStorageService : IStorageService
{

    private readonly GoogleAuthorizationCodeFlow _Authorization;

    public GoogleDriveStorageService( GoogleAuthorizationCodeFlow authorization)
    {
        _Authorization = authorization;
    }
        
    
    public string Upload(IFormFile file, User user)
    {
        var credential = new UserCredential(_Authorization, user.Email, new TokenResponse
        {
            AccessToken = user.AcessToken,
            RefreshToken = user.RefreshToken
        });


        var service = new DriveService(new Google.Apis.Services.BaseClientService.Initializer
        {
            ApplicationName = "GoogleDriveTest",
            HttpClientInitializer = credential
        }
            
            );

        var driveFile = new Google.Apis.Drive.v3.Data.File
        {
            Name = file.Name,
            MimeType = file.ContentType
        };

        var command = service.Files.Create(driveFile, file.OpenReadStream(), file.ContentType);
        command.Fields = "id";

        var response = command.Upload();

        if (response.Status is not Google.Apis.Upload.UploadStatus.Completed)
            throw response.Exception;

        return command.ResponseBody.Id;
    }
}
