using HS_BANK_V2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HS_BANK_V2.Repository
{
    public interface IRepositorio
    {
        public IEnumerable<Movimentacao> GetExtrato (int conta);
        public UserRetorno NovoUser(UserRetorno userRetorno);
        public UserRetorno BuscaUser(string email, string senha);
        public Conta GetConta(int idUser);
        public Conta GetContaByNumero(int numero);
        public bool NovaTransferencia(Conta origem, Conta Destino, decimal valor, int tipoMoeda);
        public bool Delete(int idUsuario);
    }
}
