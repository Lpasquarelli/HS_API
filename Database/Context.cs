using HS_BANK_V2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HS_BANK_V2.Database
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> opt) : base(opt)
        { }

        public DbSet<Banco> Banco { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Conta> Conta { get; set; }
        public DbSet<Movimentacao> Movimentacao { get; set; }
        public DbSet<UserRetorno> Usuario { get; set; }
    }
}
