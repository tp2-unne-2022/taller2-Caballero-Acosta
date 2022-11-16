using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_sale
    {
        private CD_sale objVenta = new CD_sale();
        

        public bool restarStock(int id_producto, int cantidad)
        {
            return objVenta.restarStock(id_producto, cantidad);
        }


        public bool sumarStock(int id_producto, int cantidad)
        {
            return objVenta.sumarStock(id_producto, cantidad);
        }

        public int getCorelative()
        {
            return objVenta.getCorelative();
        }

        public bool registrarVenta(Sale obj, DataTable DetalleVenta, out string mensaje)
        {
            return objVenta.RegistrarVenta(obj, DetalleVenta, out mensaje);
        }
    }
}
