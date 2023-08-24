using API.Middleware;
using Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API;

public class Startup
{
    private readonly IConfiguration _config;

    public Startup(IConfiguration config)
    {
        _config = config;
    }

    public void ConfigureDevelopmentServices(IServiceCollection services)
    {
        var connectionStringsChildren = _config.GetSection("ConnectionStrings").GetChildren();
        Console.WriteLine("Here:");
        connectionStringsChildren.ToList().ForEach(child => Console.WriteLine($"Key: {child.Key}, Value: {child.Value}"));
        services.AddDbContext<ForumContext>(options => { options.UseSqlServer(_config.GetConnectionString("DefaultConnection")); });

        ConfigureServices(services);
    }

    private void ConfigureServices(IServiceCollection services)
    {
        services.AddSwaggerGen();
        services.AddControllers();

        services.AddCors(opt =>
        {
            opt.AddPolicy("CorsPolicy",
                policy => { policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"); });
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseMiddleware<ExceptionMiddleware>();
        app.UseStatusCodePagesWithReExecute("/errors/{0}");

        app.UseHttpsRedirection();
        app.UseSwagger();
        app.UseSwaggerUI();


        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseCors("CorsPolicy");

        app.UseAuthentication();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapFallbackToController("Index", "Fallback");
        });
    }
}