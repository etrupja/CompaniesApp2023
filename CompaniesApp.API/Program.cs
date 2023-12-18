using CompaniesApp.API.Data;
using CompaniesApp.API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Configure AppDbContext
builder.Services.AddDbContext<AppDbContext>(options =>
{
    //options.UseSqlServer(builder.Configuration.GetConnectionString("Default123"));

    options.UseSqlServer("Data Source=ETR\\SQLEXPRESS;Initial Catalog=CompaniesAppDB;Integrated Security=True;Encrypt=False");
});

//Configure Services
builder.Services.AddScoped<ICompaniesService, CompaniesService>();
//builder.Services.AddScoped<ICompaniesService, CompaniesMySqlService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
