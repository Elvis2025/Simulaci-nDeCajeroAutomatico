using Microsoft.AspNetCore.Mvc;
using SimulaciónDeCajeroAutomatico.Models;
using System.Diagnostics;

namespace SimulaciónDeCajeroAutomatico.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new BilletesViewModel();
            return View(model);
            /*return View();*/
        }

        [HttpPost]
        public IActionResult Index(BilletesViewModel model, int monto)
        {
            
                var seleccion = model.ItemsSelected;

              
                switch (seleccion)
                {
                    case TiposDeBilletes.MilYDosCientos:
                        break;
                    case TiposDeBilletes.CienYQuinientos:
                        break;
                    case TiposDeBilletes.ModoEficiente:
                        break;
                    default:
                        
                        break;
                }

                // Puedes devolver la vista actualizada o redirigir a otra acción
                return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}