using API.Extensions;
using API.Helpers;
using API.Middleware;
using Infrastructure.Data;
using Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;

namespace API;

public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.Development.json")
            .Build();
    }

    public void ConfigureDevelopmentServices(IServiceCollection services)
    {
      var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.Development.json").Build();

        Console.WriteLine("_config!!!!" + _config["ConnectionStrings:DefaultConnection"]);
        Console.WriteLine("_config!!!!" + config["ConnectionStrings:DefaultConnection"]);
        services.AddDbContext<ForumContext>(options => { options.UseSqlite("Data source=geeku.db"); });
        services.AddDbContext<AppIdentityDbContext>(options => { options.UseSqlite("Data source=identity.db"); });


        ConfigureServices(services);
    }

    private void ConfigureServices(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfiles));
        services.AddControllers();
        services.AddServiceCollection();
        services.AddIdentityServices(_config);
        services.AddSwaggerDocumentation();

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
        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}