using API;
using API.Extensions;
using API.Helpers;
using API.Middleware;
using Infrastructure.Data;
using Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ForumContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddDbContext<AppIdentityDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddAutoMapper(typeof(MappingProfiles));
    builder.Services.AddControllers();
builder.Services.AddServiceCollection();
builder.Services.AddIdentityServices(builder.Configuration);
builder.Services.AddSwaggerDocumentation();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy",
        policy => { policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"); });
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
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<ForumContext>();
var logger = services.GetRequiredService<ILogger<Program>>();
try
{
   // await context.Database.MigrateAsync();

}
catch (Exception e)
{
    logger.LogError(e, "Error during migration");
    throw;
}

app.Run();