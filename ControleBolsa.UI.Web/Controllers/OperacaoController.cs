using ControleBolsa.Domain;
using ControleBolsa.Services;
using System.Web.Mvc;

namespace ControleBolsa.UI.Web.Controllers
{
    public class OperacaoController : Controller
    {
        OperacaoService Service;

        public OperacaoController()
        {
            this.Service = new OperacaoService();
        }
        public ActionResult Index()
        {
            return View(this.Service.ObterOperacoes());
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        public ActionResult Cadastrar(Models.Operacao operacao)
        {
            this.Service.CadastrarOperacao(operacao);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Carteira()
        {
            var carteira = this.Service.ObterCarteira();

            return View(carteira);
        }
    }
}