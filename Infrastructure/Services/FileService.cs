using API.Dtos;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Services;

public class FileService : IFileService
{
    public Task<BlobDto> DownloadAsync(string blobFileName)
    {
        throw new NotImplementedException();
    }

    public Task<List<BlobDto>> ListAsync()
    {
        throw new NotImplementedException();
    }

    public Task<BlobResponseDto> UploadAsync(IFormFile blob)
    {
        throw new NotImplementedException();
    }

    public Task<BlobResponseDto> DeleteAsync(string blobFileName)
    {
        throw new NotImplementedException();
    }
}
