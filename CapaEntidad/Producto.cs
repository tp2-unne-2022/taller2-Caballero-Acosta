using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Producto
    {
        public int id_producto { get; set; }
        public int codigo { get; set; }
        public string nombre { get; set; }
        public decimal p_venta { get; set; }
        public decimal p_compra { get; set; }
        public int stock { get; set; }
        public string genero { get; set; }
        public int id_marca { get; set; }
        public string marca { get; set; }
        public bool estado { get; set; }
    }
}
