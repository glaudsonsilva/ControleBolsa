using ControleBolsa.Services;
using System.Web.Mvc;

namespace ControleBolsa.UI.Web.Controllers
{
    public class OperacaoController : Controller
    {
        public ActionResult Index()
        {
            var service = new OperacaoService();

            return View(service.ObterOperacoes());
        }
    }
}