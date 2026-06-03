using Microsoft.EntityFrameworkCore;
using SpaceSense.Api.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "SatGuard API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Insira o token JWT aqui."
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

var secret = builder.Configuration.GetSection("JwtSettings:Secret").Value;
var key = Encoding.ASCII.GetBytes(secret ?? "A_Very_Long_Secret_Key_For_SatGuard_API_12345_Security_First");

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

// Configura o DbContext utilizando Oracle para persistência relacional FIAP
builder.Services.AddDbContext<SatGuardDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleFiap")));

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

app.UseCors("AllowAll");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
