using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HS_BANK_V2.Models
{
    [Keyless]
    [Table("HS_MOVIMENTACOES")]
    public class Movimentacao
    {
        [Column("ID_CONTA_ORIGEM")]
        public int idContaOrigem { get; set; }
        [Column("ID_CONTA_DESTINO")]
        public int idContaDestino { get; set; }
        [Column("VALOR")]
        public decimal valor { get; set; }
        [Column("TP_MOEDA")]
        public int tipoMoeda { get; set; }
        [Column("dt_movimentacao")]
        public DateTime Data{ get; set; }
    }
}
