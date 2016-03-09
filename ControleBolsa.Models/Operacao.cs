
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleBolsa.Models
{
    [Table("Operacoes")]
    public class Operacao
    {
        public int Id { get; set; }
        public string Papel { get; set; }
        public int Quantidade { get; set; }
        public decimal Cotacao { get; set; }
        public DateTime DataHora { get; set; }
    }
}
