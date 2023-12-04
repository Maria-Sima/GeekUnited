using API.Dtos;
using Microsoft.AspNetCore.Http;

namespace Core.Interfaces;

public interface IFileService
{
    public Task<BlobDto> DownloadAsync(string blobFileName);
    public Task<List<BlobDto>> ListAsync();
    public Task<BlobResponseDto> UploadAsync(IFormFile blob);
    public Task<BlobResponseDto> DeleteAsync(string blobFileName);
}
