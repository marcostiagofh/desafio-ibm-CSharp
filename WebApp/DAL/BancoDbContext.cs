using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.DAL
{
    public class BancoDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }
    }
}