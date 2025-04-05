using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebApplication1.Modelos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DBContext>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
    });
});


var app = builder.Build();

app.UseCors("AllowSpecificOrigin");

// Configure the HTTP request pipeline.

//#if DEBUG 
//using var scope2 = app.Services.CreateScope();
//#endif

if (app.Environment.IsDevelopment())
{

    #region SEEDERS

    using var scope = app.Services.CreateScope();

    var context = scope.ServiceProvider.GetRequiredService<DBContext>();

    WebApplication1.Seeders.UsuarioSeeder.Seed(context);
    WebApplication1.Seeders.ClienteSeeder.Seed(context);
    WebApplication1.Seeders.ProductSeeder.Seed(context);
    WebApplication1.Seeders.FacturaSeeder.Seed(context);

    #endregion


    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();