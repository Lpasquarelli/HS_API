using HS_BANK_V2.Models;
using HS_BANK_V2.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS_BANK_V2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IRepositorio _repositorio;
        public LoginController(IRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpPost]
        public ActionResult<dynamic> Login([FromBody] User user)
        {
            var email = user.email;
            var senha = user.senha;

            var User = _repositorio.BuscaUser(email, senha);


            if(User != null)
            {
                var geraToken = email + ":" + senha;

                byte[] array = Encoding.UTF8.GetBytes(geraToken);

                var retorno = Convert.ToBase64String(array);

                LoginRetorno loginRetorno = new LoginRetorno();

                loginRetorno.user = User;
                loginRetorno.token = retorno;

                return Ok(loginRetorno);
            }

            return BadRequest("Usuario Nao encontrado");
            
        }
    }
}
