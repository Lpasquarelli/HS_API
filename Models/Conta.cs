using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HS_BANK_V2.Models
{
    [Table("HS_CONTAS")]
    public class Conta
    {
        [Key]
        [Column("ID_CONTA")]
        public int idConta { get; set; }
        [Column("CD_CONTA")]
        public int cdConta { get; set; }
        [Column("NR_AGENCIA")]
        public int nrAgencia { get; set; }
        [Column("ID_CLIENTE")]
        public int idCliente { get; set; }
        [Column("ID_BANCO")]
        public int idBanco { get; set; }
        [Column("VL_SALDOBITCOIN")]
        public decimal vlSaldoBitcoin { get; set; }
        [Column("Vl_SALDOREAL")]
        public decimal vlSaldoReal { get; set; }
        [Column("VL_SALDODOLAR")]
        public decimal vlSaldoDolar { get; set; }
        [Column("VL_SALDODOGECOIN")]
        public decimal vlSaldoDogecoin { get; set; }
    }
}
