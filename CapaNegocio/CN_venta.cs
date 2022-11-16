using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_venta
    {
        private CD_cliente objVenta = new CD_cliente();
        public DataTable MostrarVentas()
        {
            DataTable tabla_venta = new DataTable();
            tabla_venta = objVenta.Mostrar();
            return tabla_venta;
        }
    }
}
