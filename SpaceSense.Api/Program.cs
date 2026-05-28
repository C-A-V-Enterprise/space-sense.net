using Microsoft.EntityFrameworkCore;
using SpaceSense.Api.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});
builder.Services.AddOpenApi();

// Configura o DbContext utilizando SQLite para persistência relacional e suporte a Migrations.
builder.Services.AddDbContext<SatGuardDbContext>(options =>
    options.UseSqlite("Data Source=satguard.db"));

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
