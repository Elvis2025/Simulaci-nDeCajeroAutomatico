using Microsoft.AspNetCore.Mvc;
using SimulaciónDeCajeroAutomatico.Models;
using SimulaciónDeCajeroAutomatico.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace SimulaciónDeCajeroAutomatico.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ValidacionesBilletesViewModel myVal;
        private BilletesViewModel myBill;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            myVal = new ValidacionesBilletesViewModel();
            myBill = new BilletesViewModel();
        }

        public IActionResult Index()
        {
            var model = new BilletesViewModel();
            return View(model);
            /*return View();*/
        }

        [HttpPost]
        public IActionResult Index(BilletesViewModel model)
        {
            myBill = model;
            if (ModelState.IsValid)
            {
                var isAlert = false;
                (ViewBag.Message, ViewBag.MessageType, isAlert) = myVal.Validaciones(model);
                if (!isAlert)
                {
                    return View(model);
                }
                myBill.Billetes = myVal.cantidadBilletes(Convert.ToInt32(model.Monto),model.ItemsSelected);
                myBill.Monto = "5";
            }

            return RedirectToAction("Retiro");
        }
        public IActionResult Retiro()
        {
            if(myBill is null)
            {
                return View();

            }

            return View(myBill);
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