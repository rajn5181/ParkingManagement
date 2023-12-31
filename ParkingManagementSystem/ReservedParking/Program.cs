using ReservedParking.Data;
using Microsoft.EntityFrameworkCore;
using ReservedParking.Services.IServices;
using ReservedParking.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IReservedService, ReservedService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
// Apply pending migrations on application startup
//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;
//    var dbContext = services.GetRequiredService<AppDbContext>();

//    // Check for pending migrations and apply them
//    if (dbContext.Database.GetPendingMigrations().Any())
//    {
//        dbContext.Database.Migrate();
//    }
//}

app.Run();
