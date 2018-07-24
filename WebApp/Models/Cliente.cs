using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel;

namespace WebApp.Models
{
    public class Cliente
    {
        public int ID { get; set; }

        [DisplayName("Número da Conta")]
        public string NumConta { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Endereço { get; set; }
        public decimal Saldo { get; set; }
    }

    public class ClienteDBContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
    }
}