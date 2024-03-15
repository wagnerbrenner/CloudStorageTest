using CloudStoragePratic.Application.UseCases.Users.UploadProfilePhoto;
using CloudStoragePratic.Domain.Entities;
using CloudStoragePratic.Domain.Storage;
using FileTypeChecker.Extensions;
using FileTypeChecker.Types;
using Microsoft.AspNetCore.Http;

namespace CloudStoragePraticApplication.UseCases.Users.UploadProfilePhoto;

public class UploadProfilePhotoUseCase : IUploadProfilePhotoUseCase
{
    private readonly IStorageService _storageService;


    public UploadProfilePhotoUseCase(IStorageService storageService)
    {
        _storageService = storageService;
    }

    public void Execute(IFormFile file)
    {
        var fileStream = file.OpenReadStream();

        var isImage = fileStream.Is<JointPhotographicExpertsGroup>();


        if (isImage == false)
            throw new Exception("The file is not an image.");

        var user = GetFromDatabase();


        _storageService.Upload(file, user);
    }

    private User GetFromDatabase()
    {
        return new User
        {
            Id = 1,
            Name = "Wagner",
            Email = "wagner.brenner98@gmail.com",
            RefreshToken = "1//04d_oKW8N-8xbCgYIARAAGAQSNwF-L9IrUyo5VotESwmsnU56nMM542uBBdtmcMJQCJOPvBenUpSoDu3mZL8Nk6TaOTBHwx6BLYE",
            AcessToken = "ya29.a0Ad52N39hVPrHxh1t8x5X3wxNA6hw78CciD1HFbVnn0c4N_fT_s3toiUEi8DwRJoZWfZQcRBwrg9bbErPJZLwrWpb3J9eqypCDntT-hr9kSjlVbA_ht06lZV9uburwVKhTuI_LJL09dXp3Tel_GVXvEWGOQLoiqqImywgaCgYKAW8SARASFQHGX2MiYYg_jug_8mrfZpMZ5mBwww0171",

        };
    }
}
