using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using enigma_restapi.Services;

namespace enigma_restapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration Configuration;

        public AuthController(IConfiguration config)
        {
            Configuration = config;
        }

        [HttpPost("token")]
        public async Task<IActionResult> getToken()
        {
            //obtener la llave secreta
            string secreatKey = Configuration["Authentication:secretKey"];
            string issuerAudice = Configuration["Authentication:Issuer"];
            string audice = Configuration["Authentication:Audience"];

            // realizar la seguridad simetrica
            var SymetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secreatKey));

            //credenciales de acceso
            var signingCredentials = new SigningCredentials(SymetricKey, SecurityAlgorithms.HmacSha256Signature);

            //obenemos los roles
            List<Claim> roles = (new ClamisRoles()).rolesDeAcceso();

            //creamos token
            var Token = new JwtSecurityToken(
                issuer: issuerAudice,
                audience: audice,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: signingCredentials,
                claims: roles
                );

            //regresar token

            var response = new
            {
                token = new JwtSecurityTokenHandler().WriteToken(Token),
                expire = 1 * 60 * 60,
                type = "bearer"
            };

            return Ok(response);

        }

    }
}