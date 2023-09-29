using Microsoft.EntityFrameworkCore;
using UserProfileService.Data;
using UserProfileService.Service;
using UserProfileService.Service.IService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IProfileService, ProfileService>();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(builder =>
{
    builder.WithOrigins("http://localhost:4200") // Replace with your Angular app's URL
        .AllowAnyHeader()
        .AllowAnyMethod();
});
app.UseAuthorization();

app.MapControllers();

app.Run();
