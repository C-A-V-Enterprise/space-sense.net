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

// Registro de Injeção de Dependência para a Clean Architecture
builder.Services.AddScoped(typeof(SpaceSense.Api.Repositories.IRepository<>), typeof(SpaceSense.Api.Repositories.Repository<>));
builder.Services.AddScoped<SpaceSense.Api.Services.IEmpresaService, SpaceSense.Api.Services.EmpresaService>();
builder.Services.AddScoped<SpaceSense.Api.Services.IOrbitaService, SpaceSense.Api.Services.OrbitaService>();
builder.Services.AddScoped<SpaceSense.Api.Services.ISateliteService, SpaceSense.Api.Services.SateliteService>();
builder.Services.AddScoped<SpaceSense.Api.Services.IDetritoEspacialService, SpaceSense.Api.Services.DetritoEspacialService>();
builder.Services.AddScoped<SpaceSense.Api.Services.IPlataformaService, SpaceSense.Api.Services.PlataformaService>();
builder.Services.AddScoped<SpaceSense.Api.Services.IAlertaService, SpaceSense.Api.Services.AlertaService>();
builder.Services.AddScoped<SpaceSense.Api.Services.IUsuarioService, SpaceSense.Api.Services.UsuarioService>();

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
