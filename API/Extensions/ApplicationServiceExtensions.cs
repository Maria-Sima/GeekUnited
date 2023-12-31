using API.Errors;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddServiceCollection(this IServiceCollection services)
    {
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IPostService, PostService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IBoardService, BoardService>();
        services.AddScoped<IFileService, FileService>();
        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.InvalidModelStateResponseFactory = actionContext =>
            {
                var errors = actionContext
                    .ModelState
                    .Where(e => e.Value.Errors.Count > 0)
                    .SelectMany(x => x.Value.Errors)
                    .Select(x => x.ErrorMessage)
                    .ToArray();

                var errorResponse = new ApiValidationErrorResponse { Errors = errors };

                return new BadRequestObjectResult(errorResponse);
            };
        });

        return services;
    }
}
