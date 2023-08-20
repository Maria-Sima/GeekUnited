using Infrastructure.Data;
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
        services.AddDbContext<ForumContext>(x =>
        {
            x.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
        });

        ConfigureServices(services);
    }

    private void ConfigureServices(IServiceCollection services)
    {
        throw new NotImplementedException();
    }
}