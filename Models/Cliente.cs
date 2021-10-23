using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HS_BANK_V2.Models
{
    [Table("HS_CLIENTES")]
    public class Cliente
    {
        [Key]
        [Column("ID_CLIENTE")]
        public int idCliente { get; set; }
        [Column("DS_NOME")]
        public string nmCliente { get; set; }
        [Column("NR_CPF")]
        public string nrCpf { get; set; }
        [Column("NR_IDADE")]
        public int nrIdade { get; set; }
    }
}
