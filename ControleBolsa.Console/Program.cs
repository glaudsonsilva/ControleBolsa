using ControleBolsa.DAL;
using ControleBolsa.Models;
using System;
using System.Data.Entity;

namespace ControleBolsa.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            InicializarBanco();

            var operacao = new Operacao
            {
                Papel = "KROT3",
                Cotacao = 10.19m,
                Quantidade = 2200,
                DataHora = DateTime.Now
            };

            using (var db = new Context())
            {
                db.Operacoes.Add(operacao);

                db.SaveChanges();
            }
        }

        private static void InicializarBanco()
        {
            Database.SetInitializer(new MyInitializer());
        }

        class MyInitializer : DropCreateDatabaseIfModelChanges<Context>
        {

        }
    }
}
