using SimulaciónDeCajeroAutomatico.Models;
using System.Reflection;
using System.Threading;

namespace SimulaciónDeCajeroAutomatico.Services
{
    public class ValidacionesBilletesViewModel
    {
        public (string message, string messageType,bool isAlert)Validaciones(BilletesViewModel model)
        {
            Dictionary<int,int>values = new Dictionary<int,int>();
            var seleccion = model.ItemsSelected;
            var monto = model.Monto != null ? Convert.ToInt32(model.Monto) : 0;
            string message = "";
            string messageType = "";
            bool isAlert = false;
            switch (seleccion)
            {
                case TiposDeBilletes.MilYDosCientos:
                    if (monto < 200 || monto % 200 != 0)
                    {
                        message = "Solo se dispensan billetes de RD$ 200 y RD$ 1,000.";
                        messageType = "alert-danger";
                        //return View(model);
                    }
                    message = "Prosesando transacción...";
                    messageType = "alert-success";
                    isAlert = true;
                    break;
                case TiposDeBilletes.CienYQuinientos:
                    if (monto < 100 || monto % 500 != 0 && monto % 100 != 0)
                    {
                        message = "Solo se dispensan billetes de RD$ 100  y 500.";
                        messageType = "alert-danger";
                    }
                    message = "Prosesando transacción...";
                    messageType = "alert-success";
                    isAlert = true;
                    break;
                case TiposDeBilletes.ModoEficiente:
                    if (monto < 100 || monto % 100 != 0)
                    {
                        message = "Solo se dispensan billetes inferior a 100";
                        messageType = "alert-danger";
                    }
                    message = "Prosesando transacción...";
                    messageType = "alert-success";
                    isAlert = true;
                    break;

                default:
                    message = "Debes seleccionar un metodo de dispensación";
                    messageType = "alert-danger";
                    break;
            }

            return (message, messageType,isAlert);
        }

        public Dictionary<int,int> cantidadBilletes(int monto,TiposDeBilletes tiposDeBilletes)
        {
            var resultado = new Dictionary<int, int>();
            var billetes = new List<int>();

            switch (tiposDeBilletes)
            {
                case TiposDeBilletes.MilYDosCientos:
                    billetes = new List<int> { 1000, 200 };
                    break;
                case TiposDeBilletes.CienYQuinientos:
                    billetes = new List<int> { 500, 100 };
                    break;
                case TiposDeBilletes.ModoEficiente:
                    billetes = new List<int> { 1000, 500, 200, 100 };
                    break;
            }

            foreach (var billete in billetes)
            {
                if (monto >= billete)
                {
                    var cantidad = monto / billete;
                    monto %= billete;
                    resultado[billete] = cantidad;
                }
            }

            return resultado;
        }

    }
}
