using Microsoft.AspNetCore.Mvc;
using WebApplicationMYSQL.Models;
using WebApplicationMYSQL.Services;

namespace WebApplicationMYSQL.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : Controller
    {
        [HttpPost]
        public IActionResult Auth(string username, string password)
        {
            if (username == "luiz" || password == "123456") 
            {
                var token = TokenServices.GerarToken(new Colaborador());
                return Ok(token);
            }
            return BadRequest("Usuário ou Senha inválido.");
        }
    }
}
