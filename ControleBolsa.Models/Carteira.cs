using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleBolsa.Models
{
    [NotMapped]
    public class Carteira
    {
        public Carteira()
        {
            this.Posicoes = new List<Posicao>();
        }

        public List<Posicao> Posicoes { get; set; }
    }

    [NotMapped]
    public class Posicao
    {
        public string Papel { get; set; }
        public int Quantidade { get; set; }
        public decimal Total { get; set; }
        public decimal PrecoMedio
        {
            get
            {
                return this.Total / this.Quantidade;
            }
        } 
    }
}
