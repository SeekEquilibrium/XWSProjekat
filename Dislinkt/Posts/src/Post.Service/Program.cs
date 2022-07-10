using Common.MongoDB;
using Post.Service.Clients;
using Post.Service.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins("http://localhost:3000")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        }
    );
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddMongo()
                .AddMongoRepository<UserPost>("posts")
                .AddAutoMapper();

builder.Services.AddMongoRepository<PostInteractions>("postInteractions")
                .AddAutoMapper();

builder.Services.AddHttpClient<UserClient>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:5001");
            });

builder.Services.AddHttpClient<ConnectionClient>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:5007");
            });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
