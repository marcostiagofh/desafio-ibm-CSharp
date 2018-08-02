using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Transacao
    {
        public int ID { get; set; }

        [DisplayName("ID da Conta Remetente")]
        public int IDContaRemetente { get; set; }

        [DisplayName("ID da Conta Destino")]
        public int IDContaDestino { get; set; }

        [DisplayName("Data e Hora (no formato americano)")]
        public DateTime DataHora { get; set; }
        [DisplayName("Valor (no formato americano)")]
        public decimal Valor { get; set; }
    }
    
}