using API.Dtos;
using Microsoft.AspNetCore.Http;

namespace Core.Interfaces;

public interface IFileService
{
    public Task<Uri> UploadFile(string name, IFormFile file, string bucketName);
}
