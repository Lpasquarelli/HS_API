using HS_BANK_V2.Models;
using HS_BANK_V2.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HS_BANK_V2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BancoController : ControllerBase
    {
        private readonly IRepositorio _repositorio;
        public BancoController(IRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet]
        public ActionResult<Conta> GetContas(int idUser)
        {
            var retorno = _repositorio.GetConta(idUser);

            if (retorno == null)
            {
                return NotFound();
            }

            return retorno;
        }

        [HttpGet("ContaByNumero/{numero}")]
        public ActionResult<Conta> GetContaByNumero(int numero)
        {
            var retorno = _repositorio.GetContaByNumero(numero);

            if (retorno == null)
            {
                return NotFound();
            }

            return retorno;
        }
        [HttpPut("Transfere/{contaOrigem}/{tipoMoeda}/{valor}/{contaDestino}")]
        public ActionResult<bool> NovaTransferencia(int contaOrigem, int tipoMoeda, decimal valor, int contaDestino)
        {
            var ContaOrigem = _repositorio.GetContaByNumero(contaOrigem);
            var ContaDestino = _repositorio.GetContaByNumero(contaDestino);

            var retorno = _repositorio.NovaTransferencia(ContaOrigem, ContaDestino, valor, tipoMoeda);

            if (retorno == false)
            {
                return NotFound();
            }


            return Ok();
        }
        [HttpPost("AddCliente")]
        public ActionResult<UserRetorno> NovoCliente([FromBody] NewCliente cliente)
        {
            UserRetorno userRetorno = new UserRetorno();

            userRetorno.NR_CPF = cliente.NR_CPF;
            userRetorno.NR_IDADE = cliente.NR_IDADE;
            userRetorno.DT_NASCIMENTO = cliente.DT_NASCIMENTO;
            userRetorno.DS_NOME = cliente.DS_NOME;
            userRetorno.DS_LOGIN = cliente.DS_LOGIN;
            userRetorno.DS_SENHA = cliente.DS_SENHA;
            userRetorno.DS_SOBRENOME = cliente.DS_SOBRENOME;

            var retorno = _repositorio.NovoUser(userRetorno);

            return retorno;
        }
        [HttpGet("Extrato/{conta}")]
        public ActionResult<IEnumerable<Movimentacao>> Extrato(int conta)
        {
            var retorno = _repositorio.GetExtrato(conta);

            return retorno.ToList();
        }
        [HttpDelete("{idUsuario}")]
        public ActionResult<bool> Apagar(int idUsuario)
        {
            var retorno = _repositorio.Delete(idUsuario);

            if (retorno)
            {
                return Ok(true);
            }
            return BadRequest(false);
        }
    }
}
