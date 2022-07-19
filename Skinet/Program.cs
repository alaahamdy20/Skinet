using Core.Interfaces;
using Infrasturcure.Data;
using Infrasturcure.Repositories;
using Microsoft.EntityFrameworkCore;
using Skinet.Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<StoreContext>(options => options.UseSqlite(connectionString));
//add auto mapper
builder.Services.AddAutoMapper(typeof(MappingProfile));
#region Repositories

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

#endregion

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    try
    {
        var context = services.GetRequiredService<StoreContext>();
        await context.Database.MigrateAsync();
        await StoreContextSeed.SeedData(context,loggerFactory);
    }
    catch (Exception e)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(e, "An Error ocuured during migrations ");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
// app.UseRouting();
app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();
app.Run();