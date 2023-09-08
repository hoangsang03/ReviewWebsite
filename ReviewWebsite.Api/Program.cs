
using ReviewWebsite.Application;
using ReviewWebsite.Application.Services.Authentication;
using ReviewWebsite.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    // Dependency Injection
    builder.Services
        .AddApplication()
        .AddInfrastructure();
}
// Add services to the container.

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
