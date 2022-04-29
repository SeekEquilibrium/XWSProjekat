using Common.MongoDB;
using Common.Settings;
using User.Service.Models;

var builder = WebApplication.CreateBuilder(args);
// builder.Services.Configure<AppUser>(
//     builder.Configuration.GetSection("UserDatabase"));
// Add services to the container.

ServiceSettings serviceSettings = builder.Configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();

builder.Services.AddMongo()
                .AddMongoRepository<AppUser>("users");

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