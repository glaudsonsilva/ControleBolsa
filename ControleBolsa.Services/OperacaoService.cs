using ControleBolsa.DAL;
using System.Collections.Generic;

namespace ControleBolsa.Services
{
    public class OperacaoService
    {
        public IEnumerable<Models.Operacao> ObterOperacoes()
        {
            return new OperacaoDao().ObterOperacoes();
        }
    }
}
