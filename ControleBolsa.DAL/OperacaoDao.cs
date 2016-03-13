using ControleBolsa.Models;
using System.Collections.Generic;
using System.Linq; 

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


        public void Cadastrar(Models.Operacao operacao)
        {
            using (var db = new Context())
            {
                db.Operacoes.Add(operacao);

                db.SaveChanges();
            }
        }
    }
}
