using API.Extensions;
using API.Helpers;
using API.Middleware;
using Core.Entities;
using Infrastructure.Data;
using MongoDB.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(provider =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    var databaseName = builder.Configuration["Mongo:DB"];
    return new ForumContext(connectionString, databaseName);
});
builder.Services.AddAutoMapper(typeof(MappingProfiles));
builder.Services.AddControllers();
builder.Services.AddServiceCollection();
builder.Services.AddIdentityServices(builder.Configuration);
builder.Services.AddSwaggerDocumentation();

builder
    .Services
    .AddCors(opt =>
    {
        opt.AddPolicy(
            "CorsPolicy",
            policy =>
            {
                policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200");
            }
        );
    });
var app = builder.Build();
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
});
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<ForumContext>();
var logger = services.GetRequiredService<ILogger<Program>>();


app.Run();
