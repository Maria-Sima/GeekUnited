using API.Extensions;
using API.Helpers;
using API.Middleware;
using Infrastructure.Data;
using Infrastructure.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
      
        var conn = new SqlConnection("");
        services.AddDbContext<ForumContext>(options =>
        {
            options.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
            
        });
        services.AddDbContext<AppIdentityDbContext>(options =>
        {
            options.UseSqlServer(_config.GetConnectionString("IdentityConnection"));
            
        });

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
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapFallbackToController("Index", "Fallback");
        });
    }
}