using API.Dtos;
using Core.Interfaces;
using Google.Cloud.Storage.V1;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Services;

public class FileService :IFileService
{
    private readonly StorageClient _storageClient;
    public FileService(StorageClient storageClient)
    {
        _storageClient = storageClient;
    }




    public async Task<Uri> UploadFile(string name, IFormFile file,string bucketName)
    {
        Guid randomGuid = Guid.NewGuid();
        using var stream = new MemoryStream();
        await file.CopyToAsync(stream);
        var blob = await _storageClient.UploadObjectAsync(bucketName, 
            $"{name}-{randomGuid}", file.ContentType, stream);
        Uri photoUri = new Uri(blob.MediaLink);
        return photoUri;
    }

  
}
