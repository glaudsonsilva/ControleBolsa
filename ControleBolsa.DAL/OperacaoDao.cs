using ControleBolsa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBolsa.DAL
{
    public class OperacaoDao
    {

        public IEnumerable<Operacao> ObterOperacoes()
        {
            var operacoes = new List<Operacao>();

            using (var db = new Context())
            {
                operacoes = db.Operacoes.ToList();
            }

            return operacoes;
        }
    }
}
