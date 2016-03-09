using ControleBolsa.Models;
using System.Data.Entity;

namespace ControleBolsa.DAL
{
    public class Context : DbContext
    {
        public Context()
        : base("DefaultConnection")
        {
        }

        public DbSet<Operacao> Operacoes { get; set; }
    }
}
