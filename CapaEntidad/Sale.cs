using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Sale
    {
        public int id_venta { get; set; }
        public Cliente _cliente { get; set; }
        public Usuario _usuario { get; set; }
        public DateTime fecha { get; set; }
        public string nro { get; set; }
        public decimal importe { get; set; }
        public decimal vuelto { get; set; }
        public decimal total { get; set; }
    }
}
