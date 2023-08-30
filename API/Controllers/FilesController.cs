using API.Dtos;
using Core.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class FilesController:BaseApiController
{
    private readonly FileService _fileService;

    public FilesController(FileService fileService)
    {
        _fileService = fileService;
    }

    [HttpGet]
    public async Task<ActionResult<List<BlobDto>>> ListAllBlobs()
    {
        return Ok(_fileService.ListAsync());
    }

    [HttpPost]
    public async Task<ActionResult> Upload(IFormFile file)
    {
        var result = await _fileService.UploadAsync(file);
        return Ok();
    }

    [HttpGet]
    [Route("fileName")]
    public async Task<ActionResult> Download(string filename)
    {
        var result = await _fileService.DownloadAsync(filename);
        return File(result.Content, result.ContentType, result.Name);
    }

    [HttpDelete]
    [Route("filename")]
    public async Task<ActionResult> Delete(string fileName)
    {
        var result = await _fileService.DeleteAsync(fileName);
        return Ok(result);
    }
}