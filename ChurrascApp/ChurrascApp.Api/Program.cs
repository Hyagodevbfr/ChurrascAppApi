using ChurrascApp.Api.Extensions;
using ChurrascApp.Infrastructure.Configurations.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddConfigurations(builder.Configuration)
    .AddServices()
    .AddRepositories()
    .AddSwagger()
    .AddInfrastructure(builder.Configuration)
    .AddCustomCors(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
app.UseCors("AllowAll");

app.MapControllers();

app.Run();