using HS_BANK_V2.Database;
using HS_BANK_V2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HS_BANK_V2.Repository
{
    public class Repositorio : IRepositorio
    {
        private readonly Context _Context;
        public Repositorio(Context context)
        {
            _Context = context;

        }
        public UserRetorno BuscaUser(string email, string senha)
        {
            var retorno = _Context.Usuario.Where(x => x.DS_LOGIN == email && x.DS_SENHA == senha).FirstOrDefault();

            return retorno;
        }
        public UserRetorno BuscaUser(int id)
        {
            var retorno = _Context.Usuario.Where(x => x.ID_USUARIO == id).FirstOrDefault();

            return retorno;
        }

        public bool Delete(int idUsuario)
        {
            var auxiliar = GetConta(idUsuario);

            if(auxiliar.vlSaldoBitcoin == 0 && auxiliar.vlSaldoReal == 0 && auxiliar.vlSaldoDolar == 0 && auxiliar.vlSaldoDogecoin == 0)
            {
                _Context.Conta.Remove(auxiliar);
                _Context.Usuario.Remove(BuscaUser(idUsuario));
                _Context.Movimentacao.RemoveRange(GetExtrato(auxiliar.idConta));
                _Context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public Conta GetConta(int idUser)
        {
            var retorno = _Context.Conta.Where(x => x.idCliente == idUser).FirstOrDefault();

            return retorno;
        }
        public Conta GetContaByNumero(int numero)
        {
            var retorno = _Context.Conta.Where(x => x.cdConta == numero).FirstOrDefault();

            return retorno;
        }

        public IEnumerable<Movimentacao> GetExtrato(int conta)
        {
            var retorno = _Context.Movimentacao.Where(x => x.idContaOrigem == conta).ToList();

            return retorno;
        }

        public bool NovaTransferencia(Conta origem, Conta Destino, decimal valor, int tipoMoeda)
        {
            switch (tipoMoeda)
            {
                case 1:
                    origem.vlSaldoBitcoin = origem.vlSaldoBitcoin - valor;
                    Destino.vlSaldoBitcoin = Destino.vlSaldoBitcoin + valor;
                    break;
                case 2:
                    origem.vlSaldoReal = origem.vlSaldoReal - valor;
                    Destino.vlSaldoReal = Destino.vlSaldoReal + valor;
                    break;
                case 3:
                    origem.vlSaldoDolar = origem.vlSaldoDolar - valor;
                    Destino.vlSaldoDolar = Destino.vlSaldoDolar + valor;
                    break;
                case 4:
                    origem.vlSaldoDogecoin = origem.vlSaldoDogecoin - valor;
                    Destino.vlSaldoDogecoin = Destino.vlSaldoDogecoin + valor;
                    break;
            }

            _Context.Update<Conta>(origem);
            _Context.Update<Conta>(Destino);

            Movimentacao movimentacao = new Movimentacao();

            movimentacao.idContaOrigem = origem.idConta;
            movimentacao.idContaDestino = Destino.idConta;
            movimentacao.valor = valor;
            movimentacao.tipoMoeda = tipoMoeda;
            movimentacao.Data = DateTime.Today;

            _Context.Movimentacao.Add(movimentacao);

            _Context.SaveChanges();

            return true;
        }

        public UserRetorno NovoUser(UserRetorno userRetorno)
        {
            var retorno = _Context.Usuario.Add(userRetorno);
            _Context.SaveChanges();

            Conta conta = new Conta();

            var ultimaConta  = _Context.Conta.ToList();


            conta.nrAgencia = ultimaConta.Max(x => x.nrAgencia) + 1;
            conta.cdConta = ultimaConta.Max(x => x.cdConta) + 1;

            conta.idCliente = userRetorno.ID_USUARIO;
            conta.idBanco = 1;

            conta.vlSaldoBitcoin = 0;
            conta.vlSaldoReal = 0;
            conta.vlSaldoDolar = 0;
            conta.vlSaldoDogecoin = 0;

            _Context.Conta.Add(conta);
            _Context.SaveChanges();

            return userRetorno;
        }
    }
}
