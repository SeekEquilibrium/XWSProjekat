using Common.MongoDB;
using Common.Settings;
using AgentApp.Models;
using AgentApp.Services;
using AgentApp.Clients;

var builder = WebApplication.CreateBuilder(args);

ServiceSettings serviceSettings = builder.Configuration.GetSection(nameof(ServiceSettings)).Get<ServiceSettings>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<CompanyService>();
builder.Services.AddScoped<JobService>();
builder.Services.AddScoped<CommentService>();
builder.Services.AddScoped<JobOfferService>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddMongo()
                .AddMongoRepository<Company>("companies")
                .AddAutoMapper();

builder.Services.AddMongoRepository<User>("appUsers")
                .AddAutoMapper();

builder.Services.AddMongoRepository<Job>("jobs")
                .AddAutoMapper();

builder.Services.AddMongoRepository<Comment>("comments")
                .AddAutoMapper();  

builder.Services.AddMongoRepository<JobOffer>("offers")
                .AddAutoMapper(); 

builder.Services.AddHttpClient<JobOfferClient>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:5010");
            });  

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
    {
        builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
    }));  

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corsapp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
