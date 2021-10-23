using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HS_BANK_V2.Models
{
    [Table("HS_BANCOS")]
    public class Banco
    {
        [Key]
        [Column("ID_BANCO")]
        public int? idBanco { get; set; }
        [Column("CD_BANCO")]
        public int cdBanco { get; set; }
        [Column("DS_NOMERAZAO")]
        public string dsNomeBanco { get; set; }
    }
}
