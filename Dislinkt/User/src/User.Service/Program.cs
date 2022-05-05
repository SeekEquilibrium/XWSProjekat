using Common.MongoDB;
using Common.Settings;
using User.Service.Models;
using User.Service.Service.Implements;
using User.Service.Service.Interfaces;
using User.Service.Clients;


var builder = WebApplication.CreateBuilder(args);
// builder.Services.Configure<AppUser>(
//     builder.Configuration.GetSection("UserDatabase"));
// Add services to the container.

ServiceSettings serviceSettings = builder.Configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IRequestService, RequestSevice>();

builder.Services.AddMongo()
                .AddMongoRepository<AppUser>("users")
                .AddAutoMapper();

builder.Services.AddMongoRepository<Request>("requests")
                .AddAutoMapper();

builder.Services.AddHttpClient<ConnectionClient>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:5007");
            });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers(options =>
            {
                options.SuppressAsyncSuffixInActionNames = false;
            });

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