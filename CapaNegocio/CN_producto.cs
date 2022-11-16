using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_producto
    {
        private CD_producto objProducto = new CD_producto();
        public DataTable MostrarProductos()
        {
            DataTable tabla_productos= new DataTable();
            tabla_productos = objProducto.Mostrar();
            return tabla_productos;
        }

        public DataTable ListarProductos()
        {
            DataTable tabla_productos = new DataTable();
            tabla_productos = objProducto.Listar();
            return tabla_productos;
        }


        public void InsertarProducto(int codigo, string nombre, decimal p_venta,
            decimal p_compra, int stock, string genero, int marca)
        {
            objProducto.Insertar(codigo, nombre, p_venta, p_compra, stock, genero, marca);
        }


        public void EditarProducto(int codigo, string nombre, decimal p_venta,
            decimal p_compra, int stock, string genero, int marca, int id_producto)
        {
            objProducto.Editar(codigo, nombre, p_venta, p_compra, stock, genero, marca, id_producto);
        }

        public void BajaLogicaProducto(int id_prodcto)
        {
            objProducto.BajaLogica(id_prodcto);
        }
    }
}
