using ControleBolsa.DAL;
using ControleBolsa.Models;
using System;
using System.Collections;
using System.Data.Entity;
using System.Linq;

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
            var path = GetDataBaseRelativePath();
            AppDomain.CurrentDomain.SetData("DataDirectory", path);

            Database.SetInitializer(new MyInitializer());
        }

        private static string GetDataBaseRelativePath()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory.Split('\\');

            Stack pilha = new Stack(path);

            Enumerable.Range(0, 4).ToList().ForEach(x => pilha.Pop());

            pilha.Push("ControleBolsa.UI.Web");
            pilha.Push("App_Data");

            var arr = pilha.ToArray();
            Array.Reverse(arr);

            return string.Join("\\", arr);
        }

        class MyInitializer : DropCreateDatabaseIfModelChanges<Context>
        {

        }
    }
}
