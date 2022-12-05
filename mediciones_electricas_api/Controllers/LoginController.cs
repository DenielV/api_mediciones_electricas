using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mediciones_electricas_api.Models;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using mediciones_electricas_api.Dtos.Login;

namespace mediciones_electricas_api.Controllers
{
    [NonController]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly mediciones_electricasContext _context;
       
        //Obtener la llave secreta
        private readonly string secrekey;
        public LoginController(IConfiguration config, mediciones_electricasContext context)
        {
            secrekey = config.GetSection("settings").GetSection("secretkey").ToString();
            _context=context;
        }

        [HttpPost]
        [Route("IniciarSesion")]
        public IActionResult IniciarSesion(DtoLoginIniciarSesion request)
        {
            if (_context.Logins.Where(l=>l.Usuario.Equals(request.Usuario)&&l.Contraseña.Equals(request.Contraseña)).ToList().Count>0)
            {
                var keyBytes = Encoding.ASCII.GetBytes(secrekey);
                var claims = new ClaimsIdentity();
                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, request.Usuario));
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddMinutes(60),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);
                string tokencreado = tokenHandler.WriteToken(tokenConfig);
                return StatusCode(StatusCodes.Status200OK, new { token = tokencreado });
            }else
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new { token = "" });
            }
        }
        [HttpPost]
        [Route("CrearUsuario")]
        public IActionResult CrearUsuario(DtoLoginNuevoEditar request)
        {
            if(request == null)           
                return StatusCode(StatusCodes.Status400BadRequest);
            else
            {
                _context.Add(request);
                 _context.SaveChanges();
                return Ok();
            }
        }
    }
}
