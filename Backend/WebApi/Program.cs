using Application.Ports;
using Application.UseCases.Owner;
using Application.UseCases.Owner.Interfaces;
using Application.UseCases.PropertyTrace;
using Application.UseCases.PropertyTrace.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ReporitoryMongoDb.Configs;
using ReporitoryMongoDb.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDbSettings"));

builder.Services.AddSingleton<IMongoDatabase>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
    var client = new MongoClient(settings.ConnectionString);
    return client.GetDatabase(settings.DatabaseName);
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IGetAllOwnerUseCase, GetAllOwnerUseCase>();
builder.Services.AddScoped<IGetOwnerByIdUseCase, GetOwnerByIdUseCase>();
builder.Services.AddScoped<IAddOwnerUseCase, AddOwnerUseCase>();
builder.Services.AddScoped<IUpdateOwnerUseCase, UpdateOwnerUseCase>();

builder.Services.AddScoped<IGetAllByPropertyIdUseCase, GetAllByPropertyIdUseCase>();
builder.Services.AddScoped<IAddPropertyTraceUseCase, AddPropertyTraceUseCase>();
builder.Services.AddScoped<IGetPropertyTraceByIdUseCase, GetPropertyTraceByIdUseCase>();

builder.Services.AddScoped<IOwnerRepositoryPort, OwnerRepository>();
builder.Services.AddScoped<IPropertyTraceRepositoryPort, PropertyTraceRepository>();

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
