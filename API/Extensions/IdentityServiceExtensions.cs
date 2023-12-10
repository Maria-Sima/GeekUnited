using Core.Entities;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace API.Extensions;

public static class IdentityServiceExtensions
{
    public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
    {
        Console.WriteLine("!!!Gets here IdServ");
        ConfigureIdentityOptions(services);
        ConfigureIdentityStores(services, config);
        ConfigureJwtAuthentication(services, config);
        Console.WriteLine("!!!Gets here");
        return services;
    }

    private static void ConfigureIdentityOptions(IServiceCollection services)
    {
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

    private static void ConfigureIdentityStores(IServiceCollection services, IConfiguration config)
    {
        var firebaseProjectName = "<FIREBASE_PROJECT_NAME>";
        services.AddSingleton(new FirebaseAuthClient(new FirebaseAuthConfig
        {
            ApiKey = "<API_KEY>",
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
        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = "https://securetoken.google.com/my-firebase-project";
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = "https://securetoken.google.com/my-firebase-project",
                    ValidateAudience = true,
                    ValidAudience = "my-firebase-project",
                    ValidateLifetime = true
                };
            });
    }
}
