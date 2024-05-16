using SimulaciónDeCajeroAutomatico.Services;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SimulaciónDeCajeroAutomatico.Models
{
    public class BilletesViewModel
    {
        public int Nothing { get; set; } = (int)TiposDeBilletes.Nothing;
        public int MilYDosCientos { get; set; } = (int)TiposDeBilletes.MilYDosCientos;
        public int CienYQuinientos { get; set; } = (int)TiposDeBilletes.CienYQuinientos;
        public int ModoEficiente { get; set; } = (int)TiposDeBilletes.ModoEficiente;
        public TiposDeBilletes ItemsSelected { get; set; } = new();
        public Dictionary<int,int> Billetes { get; set; } = new();


        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public string? Monto { get; set; }
   
    }
}
