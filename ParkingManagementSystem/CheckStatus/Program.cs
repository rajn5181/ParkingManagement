using CheckStatus.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using CheckStatus.Services.IServices;
using CheckStatus.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ICPARepository, CPARepository>();
builder.Services.AddScoped<ISlotRepository, SlotRepository>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CheckStatus", Version = "v1" });
});

builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CheckStatus v1"));
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
