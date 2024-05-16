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
        private static BilletesViewModel? myBill;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            myVal = new ValidacionesBilletesViewModel();
           
        }

        public IActionResult Index()
        {
            if(myBill is null)
            {
                var model = new BilletesViewModel();
                model.ItemsSelected = TiposDeBilletes.ModoEficiente;
                myBill = model;
                return View(myBill);
            }
            myBill.Monto = "";
            return View(myBill);
            /*return View();*/
        }

        [HttpPost]
        public IActionResult Index(BilletesViewModel model)
        {
            myBill.Monto = model.Monto;
            if (ModelState.IsValid)
            {
                var isAlert = false;
                (ViewBag.Message, ViewBag.MessageType, isAlert) = myVal.Validaciones(myBill);
                myBill.ModoTransaccion = myVal.tipoTransaccion(myBill.ItemsSelected);
                if (!isAlert)
                {
                    return View(model);
                }
                myBill.Billetes = myVal.cantidadBilletes(Convert.ToInt32(model.Monto), myBill.ItemsSelected);
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
            if(myBill is null)
            {
                var model = new BilletesViewModel();
                model.ItemsSelected = TiposDeBilletes.ModoEficiente;
                return View(model);
            }
            return View(myBill);
        }
        [HttpPost]
         public IActionResult Privacy(BilletesViewModel model)
        {
            if(myBill is null)
            {
                return View(model);
            }
            myBill.ItemsSelected = model.ItemsSelected;
            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}