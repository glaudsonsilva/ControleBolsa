using ControleBolsa.DAL;
using System.Collections.Generic;
using ControleBolsa.Domain;
using System.Linq;

namespace ControleBolsa.Services
{
    public class OperacaoService
    {
        private OperacaoDao _dao;

        private OperacaoDao OperacaoDao
        {
            get
            {
                if (this._dao == null)
                {
                    this._dao = new OperacaoDao();
                }
                return _dao;
            }
        }

        public IEnumerable<Models.Operacao> ObterOperacoes()
        {
            return this.OperacaoDao.ObterOperacoes();
        }

        public void CadastrarOperacao(Models.Operacao operacao)
        {
            this.OperacaoDao.Cadastrar(operacao);
        }

        public Models.Carteira ObterCarteira()
        {
            var operacoesSumarizadas = from o in this.OperacaoDao.ObterOperacoes()
                                       group o by o.Papel into g
                                       select new
                                       {
                                           Papel = g.Key,
                                           Quantidade = g.Sum(x => x.Quantidade),
                                           Total = g.Sum(x => x.Quantidade * x.Cotacao),
                                       };

            var carteira = new Models.Carteira();

            foreach (var operacao in operacoesSumarizadas)
            {
                carteira.Posicoes.Add(new Models.Posicao
                {
                    Papel = operacao.Papel,
                    Quantidade = operacao.Quantidade,
                    Total = operacao.Total
                });
            }

            return carteira;
        }
    }
}
