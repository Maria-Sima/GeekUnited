using API.Dtos;
using Azure.Storage;
using Azure.Storage.Blobs;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Services;

public class FileService : IFileService
{
    private readonly IConfiguration _configuration;


    private readonly BlobContainerClient _filesContainer;

    public FileService(IConfiguration configuration)
    {
        _configuration = configuration;
        var blobConfig = _configuration.GetSection("AzureBlobStorage");
        var storageAccount = blobConfig["StorageAccount"];
        var key = blobConfig["key"];
        var blobUri = $"https://{storageAccount}.blob.core.windows.net";
        var credential = new StorageSharedKeyCredential(storageAccount, key);

        var blobServiceClient = new BlobServiceClient(new Uri(blobUri), credential);
        _filesContainer = blobServiceClient.GetBlobContainerClient("files");
    }

    public async Task<List<BlobDto>> ListAsync()
    {
        var files = new List<BlobDto>();

        await foreach (var file in _filesContainer.GetBlobsAsync())
        {
            var uri = _filesContainer.Uri.ToString();
            var name = file.Name;
            var fullUri = $"{uri}/{name}";

            files.Add(new BlobDto
            {
                Uri = fullUri,
                Name = name,
                ContentType = file.Properties.ContentType
            });
        }

        return files;
    }


    public async Task<BlobResponseDto> UploadAsync(IFormFile blob)
    {
        BlobResponseDto response = new();
        var client = _filesContainer.GetBlobClient(blob.FileName);

        await using (var data = blob.OpenReadStream())
        {
            await client.UploadAsync(data);
        }

        response.Status = $"File {blob.FileName} Uploaded Succesfully";

        response.Error = false;
        response.Blob.Uri = client.Uri.AbsoluteUri;
        response.Blob.Name = client.Name;
        return response;
    }

    public async Task<BlobDto?> DownloadAsync(string blobFileName)
    {
        var file = _filesContainer.GetBlobClient(blobFileName);

        if (await file.ExistsAsync())
        {
            var data = await file.OpenReadAsync();
            var blobContent = data;

            var content = await file.DownloadContentAsync();

            var name = blobFileName;
            var contentType = content.Value.Details.ContentType;
            return new BlobDto { Content = blobContent, Name = name, ContentType = contentType };
        }

        return null;
    }

    public async Task<BlobResponseDto> DeleteAsync(string blobFileName)
    {
        var file = _filesContainer.GetBlobClient(blobFileName);

        await file.DeleteAsync();

        return new BlobResponseDto { Error = false, Status = $"File:{blobFileName} has been succesfully deleted" };
    }
}