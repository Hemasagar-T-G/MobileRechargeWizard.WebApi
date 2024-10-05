using MobileRechargeWizard.WebApi;
using MobileRechargeWizard.WebApi.DependencyInjection;
using MobileRechargeWizard.WebApi.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Configure DatabaseSettings from appsettings.json
builder.Services.Configure<DatabaseSettings>(
    builder.Configuration.GetSection(nameof(DatabaseSettings))
);

// Add MongoDB client
builder.Services.AddSingleton<IMongoClient>(s =>
    new MongoClient(builder.Configuration.GetValue<string>("DatabaseSettings:ConnectionString")));

// Register MongoDB collections separately
builder.Services.AddScoped<IMongoCollection<Mobile>>(s =>
{
    var settings = s.GetRequiredService<IOptions<DatabaseSettings>>().Value;
    var mongoClient = s.GetRequiredService<IMongoClient>();
    var database = mongoClient.GetDatabase(settings.DatabaseName);
    return database.GetCollection<Mobile>(settings.Collections["MobileCollection"].ToString());
});

builder.Services.AddScoped<IMongoCollection<RechargePlan>>(s =>
{
    var settings = s.GetRequiredService<IOptions<DatabaseSettings>>().Value;
    var mongoClient = s.GetRequiredService<IMongoClient>();
    var database = mongoClient.GetDatabase(settings.DatabaseName);
    return database.GetCollection<RechargePlan>(settings.Collections["RechargePlansCollection"].ToString());
});

// Add repositories and services to the container
builder.Services.AddRepositories();
builder.Services.AddServices();

// Add controllers and other configurations
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
