using Microsoft.EntityFrameworkCore;
using SpaceSense.Api.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Configura o DbContext em memória. Substitua por UseOracle no momento de produção com as credenciais.
builder.Services.AddDbContext<SatGuardDbContext>(options =>
    options.UseInMemoryDatabase("SatGuardDb"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
