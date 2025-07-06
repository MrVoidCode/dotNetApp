using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Serilog;
using SimpleApi;
using SimpleApi.DbContexts;
using SimpleApi.Repositories;
using SimpleApi.Services;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("Logs/cityInfo.txt")
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();
builder.Services.AddDbContext<CityInfoDbContext>(options =>
{
    options.UseSqlServer((builder.Configuration.GetConnectionString("DefaultConnection")));
});

// Add services to the container.

builder.Services.AddControllers(options =>
{
    //options.OutputFormatters.Add();
    options.ReturnHttpNotAcceptable = true;
})  .AddNewtonsoftJson()
    .AddXmlDataContractSerializerFormatters();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<FileExtensionContentTypeProvider>();
builder.Services.AddSingleton<CitiesDataStore>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// my services
builder.Services.AddScoped<ICityInfoRepository, CityInfoRepository>();
builder.Services.AddScoped<IPointOfInterestInfoRepository, PointOfInterestInfoRepository>();

#if DEBUG
builder.Services.AddScoped<IMailServices, LocalMailServices>();
#else
builder.Services.AddScoped<IMailServices, CloudMailServices>();
#endif


var app = builder.Build();

// Configure the HTTP request pipeline.


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();

});



app.Run();
