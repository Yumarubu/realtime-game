using Microsoft.OpenApi.Models;
using realtime_game.Server.StreamingHubs;

var builder = WebApplication.CreateBuilder(args);
var magiconion = builder.Services.AddMagicOnion();

if (builder.Environment.IsDevelopment())
{
    magiconion.AddJsonTranscoding();
    builder.Services.AddMagicOnionJsonTranscodingSwagger();
}

builder.Services.AddSwaggerGen(options =>
{
    options.IncludeMagicOnionXmlComments(Path.Combine(AppContext.BaseDirectory, "realtime_game.Shared.xml"));
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "",
        Description = "",
    });
});

builder.Services.AddMvcCore().AddApiExplorer();
builder.Services.AddSingleton<RoomContextRepository>();@//©1s’Ç‰Á

// Add services to the container.
builder.Services.AddMagicOnion();

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "");
    });
}

// Configure the HTTP request pipeline.
app.MapMagicOnionService();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();