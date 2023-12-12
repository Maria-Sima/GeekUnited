using Firebase.Auth;
using Firebase.Auth.Providers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace API.Extensions;

public static class AuthServiceExtensions
{
    public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
    {
        ConfigureIdentityStores(services, config);
        ConfigureJwtAuthentication(services, config);
        return services;
    }

    // private static void ConfigureIdentityOptions(IServiceCollection services)
    // {
    //     services.AddIdentityCore<AppUser>(opt =>
    //     {
    //         opt.Password.RequireDigit = true;
    //         opt.Password.RequireLowercase = true;
    //         opt.Password.RequireUppercase = true;
    //         opt.Password.RequireNonAlphanumeric = true;
    //         opt.Password.RequiredLength = 8;
    //         opt.Password.RequiredUniqueChars = 1;
    //     });
    // }

    private static void ConfigureIdentityStores(IServiceCollection services, IConfiguration config)
    {
        var firebaseProjectName = config["Firebase:ProjectName"];
        services.AddSingleton(new FirebaseAuthClient(new FirebaseAuthConfig
        {
            ApiKey = config["Firebase:APIKey"],
            AuthDomain = $"{firebaseProjectName}.firebaseapp.com",
            Providers = new FirebaseAuthProvider[]
            {
                new EmailProvider(),
                new GoogleProvider()
            }
        }));
    }

    private static void ConfigureJwtAuthentication(IServiceCollection services, IConfiguration config)
    {
        var projectUrl = $"https://securetoken.google.com/{config["Firebase:ProjectName"]}";
        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = projectUrl;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = projectUrl,
                    ValidateAudience = true,
                    ValidAudience = config["Firebase:ProjectName"],
                    ValidateLifetime = true
                };
            });
    }
}
