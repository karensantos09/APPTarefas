using Microsoft.AspNetCore.Mvc;

namespace APPTarefas.Controllers
{
    public class TarefasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
