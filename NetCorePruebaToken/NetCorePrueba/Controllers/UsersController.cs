using Microsoft.AspNetCore.Mvc;
using NetCoreAPIMySQL.Model;
using Newtonsoft.Json;
using NetcoreAPIMySQL.Data.Repositories;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace NetCorePrueba.Controllers
{


    [ApiController]
    [Route("Users")]
    public class usersController : ControllerBase
    {

        private readonly IUsersRepository _usersRepository;
        public IConfiguration _configuration;


        public usersController(IUsersRepository usersRepository, IConfiguration configuration)
        {
            _usersRepository = usersRepository;
            _configuration=configuration;

        }

      
        [HttpPost]
        [Route("Login")]
        public dynamic Login([FromBody] object optData)
        {  

            var data = JsonConvert.DeserializeObject<dynamic>(optData.ToString());
            string user=data.usuario.ToString();
            string password=data.password.ToString();

            var result=_usersRepository.GetUsers(user, password);

            if (result.Result ==null)
            {
                return new{success = false,message="Acceso denegado Clave incorrecta",result=""};
            }

            var jwt = _configuration.GetSection("Jwt").Get<Jwt>();
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,jwt.Subject),new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),new Claim("id",result.Result.ToString())
            };

            var key= new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
            var singIn= new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(jwt.Issuer,jwt.Audience,claims,expires: DateTime.Now.AddMinutes(60),signingCredentials: singIn);
            return new
            {
                success = true,message = "Exito",result = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }
    }
}
