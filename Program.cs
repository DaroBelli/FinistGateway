using FinistGateway.Controllers;
using FinistGateway.Maps;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins(ConfigJSON.GetConfig().GetSection("WebClientAddress").Value).AllowAnyHeader().AllowAnyMethod();
        });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

UserMap userMap = new(app);
LoginningMap loginningMap = new(app);

app.Run(ConfigJSON.GetConfig().GetSection("ThisAddress").Value);
