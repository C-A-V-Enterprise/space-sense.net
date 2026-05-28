using Microsoft.EntityFrameworkCore;
using SpaceSense.Api.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura o DbContext utilizando SQLite para persistência relacional e suporte a Migrations.
builder.Services.AddDbContext<SatGuardDbContext>(options =>
    options.UseSqlite("Data Source=satguard.db"));

var app = builder.Build();

// Redireciona a raiz para o Swagger automaticamente
app.MapGet("/", () => Results.Redirect("/swagger"));

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection(); // Comentado para evitar aviso de porta HTTPS no console local

app.UseAuthorization();

app.MapControllers();

app.Run();
