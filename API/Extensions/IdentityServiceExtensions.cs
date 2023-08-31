using System.Text;
using Core.Entities;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace API.Extensions;

public static class IdentityServiceExtensions
{
    public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
    {
        Console.WriteLine("!!!Gets here IdServ");
        ConfigureIdentityOptions(services);
        ConfigureIdentityStores(services);
        ConfigureJwtAuthentication(services, config);
        Console.WriteLine("!!!Gets here");
        return services;
    }

    private static void ConfigureIdentityOptions(IServiceCollection services)
    {
        Console.WriteLine("!!!Gets here IdOpt");
        services.AddIdentityCore<AppUser>(opt =>
        {
            opt.Password.RequireDigit = true;
            opt.Password.RequireLowercase = true;
            opt.Password.RequireUppercase = true;
            opt.Password.RequireNonAlphanumeric = true;
            opt.Password.RequiredLength = 8;
            opt.Password.RequiredUniqueChars = 1;
        });
    }

    private static void ConfigureIdentityStores(IServiceCollection services)
    {
        Console.WriteLine("!!!Gets here IdStores");
        services.AddIdentity<AppUser, IdentityRole>()
            .AddEntityFrameworkStores<AppIdentityDbContext>()
            .AddSignInManager<SignInManager<AppUser>>();
    }

    private static void ConfigureJwtAuthentication(IServiceCollection services, IConfiguration config)
    {
        Console.WriteLine("!!!Gets here JWT");
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Token:Key"])),
                    ValidIssuer = config["Token:Issuer"],
                    ValidateIssuer = true,
                    ValidateAudience = false
                };
            });
    }
}