using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Transacao
    {
        public int ID { get; set; }
        public int IDContaRemetente { get; set; }
        public int IDContaDestino { get; set; }
        public DateTime DataHora { get; set; }
        public decimal Valor { get; set; }
    }

    public class TransacaoDBContext : DbContext
    {
        public DbSet<Transacao> Transacoes { get; set; }
    }
}