using Microsoft.AspNetCore.Mvc;
using SpaceSense.Api.DTOs;
using SpaceSense.Api.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace SpaceSense.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _service;
        private readonly IConfiguration _configuration;

        public UsuariosController(IUsuarioService service, IConfiguration configuration)
        {
            _service = service;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioResponseDTO>>> GetUsuarios()
        {
            var response = await _service.GetUsuariosAsync();
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioResponseDTO>> PostUsuario(UsuarioRequestDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _service.CreateUsuarioAsync(request);
            return CreatedAtAction(nameof(GetUsuarios), new { id = response.UsuarioId }, response);
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginDTO login)
        {
            var adminEmail = _configuration.GetSection("JwtSettings:AdminEmail").Value;
            var adminSenha = _configuration.GetSection("JwtSettings:AdminPassword").Value;

            if (login.Email == adminEmail && login.Senha == adminSenha)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var secret = _configuration.GetSection("JwtSettings:Secret").Value ?? "Fallback_Secret_12345";
                var key = Encoding.ASCII.GetBytes(secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, login.Email),
                        new Claim(ClaimTypes.Role, "Admin")
                    }),
                    Expires = DateTime.UtcNow.AddHours(2),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return Ok(new { token = tokenHandler.WriteToken(token) });
            }
            return Unauthorized(new { message = "E-mail ou senha inválidos" });
        }
    }
}
