using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HS_BANK_V2.Models
{
    public class User
    {
        public string email { get; set; }
        public string senha { get; set; }
    }
    [Table("HS_USUARIO")]
    public class UserRetorno
    {
        [Key]
        [Column("ID_USUARIO")]
        public int ID_USUARIO { get; set; }
        [Column("DS_NOME")]
        public string DS_NOME { get; set; }
        [Column("DS_SOBRENOME")]
        public string DS_SOBRENOME { get; set; }
        [Column("NR_IDADE")]
        public int NR_IDADE { get; set; }
        [Column("NR_CPF")]
        public string NR_CPF { get; set; }
        [Column("DT_NASCIMENTO")]
        public DateTime DT_NASCIMENTO { get; set; }
        [Column("DS_LOGIN")]
        public string DS_LOGIN { get; set; }
        [Column("DS_SENHA")]
        public string DS_SENHA { get; set; }
    }

    public class LoginRetorno 
    {
        public UserRetorno user{ get; set; }
        public string token { get; set; }
    }

    public class NewCliente
    {
        public int ID_USUARIO { get; set; }
        public string DS_NOME { get; set; }
        public string DS_SOBRENOME { get; set; }
        public int NR_IDADE { get; set; }
        public string NR_CPF { get; set; }
        public DateTime DT_NASCIMENTO { get; set; }
        public string DS_LOGIN { get; set; }
        public string DS_SENHA { get; set; }
    }


}
