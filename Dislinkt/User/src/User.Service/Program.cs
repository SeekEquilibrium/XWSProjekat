using System.Net.NetworkInformation;
using System.Reflection.Metadata;
using User.Service.Models;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using User.Service.Settings;
using MongoDB.Driver;
using User.Service.Repositories.Interface;
using User.Service.Repositories;

var builder = WebApplication.CreateBuilder(args);
// builder.Services.Configure<AppUser>(
//     builder.Configuration.GetSection("UserDatabase"));
// Add services to the container.

ServiceSettings serviceSettings = builder.Configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();

builder.Services.AddSingleton(serviceProvider =>
{
    var mongoDbSettings = builder.Configuration.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>();
    var mongoclient = new MongoClient(mongoDbSettings.ConnectionString);
    return mongoclient.GetDatabase(serviceSettings.ServiceName);
});

builder.Services.AddSingleton<IUserRepository, UserRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers(options =>
            {
                options.SuppressAsyncSuffixInActionNames = false;
            });

// BsonSerializer.RegisterSerializer(new GuidSerializer(NetBiosNodeType.String));
// builder.Services.AddMongo()
//                     .AddMongoRepository<AppUser>("users")
//                     .AddMassTransitWithRabbitMq();

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