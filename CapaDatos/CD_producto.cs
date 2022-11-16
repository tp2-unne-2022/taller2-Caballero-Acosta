using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_producto
    {
        private CD_conexion conexion = new CD_conexion();


        SqlDataReader mostrar_productos;
        DataTable tabla_productos = new DataTable();
        SqlCommand cmd = new SqlCommand();

        public DataTable Mostrar()
        {
            cmd.Connection = conexion.abrir_conexion();
            cmd.CommandText = "MOSTRAR_PRODUCTOS";
            cmd.CommandType = CommandType.StoredProcedure;
            mostrar_productos = cmd.ExecuteReader();
            tabla_productos.Load(mostrar_productos);
            conexion.cerrar_conexion();
            return tabla_productos;
        }

        public DataTable Listar()
        {
            cmd.Connection = conexion.abrir_conexion();
            cmd.CommandText = "LISTAR_PRODUCTOS_MODAL";
            cmd.CommandType = CommandType.StoredProcedure;
            mostrar_productos = cmd.ExecuteReader();
            tabla_productos.Load(mostrar_productos);
            conexion.cerrar_conexion();
            return tabla_productos;
        }

        public void Insertar(int codigo, string nombre, decimal p_venta, decimal p_compra, 
            int stock, string genero, int marca)
        {
            cmd.Connection = conexion.abrir_conexion();
            cmd.CommandText = "INSERTAR_PRODUCTO";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@codigo", codigo);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@p_venta", p_venta);
            cmd.Parameters.AddWithValue("@p_compra", p_compra);
            cmd.Parameters.AddWithValue("@stock", stock);
            cmd.Parameters.AddWithValue("@genero", genero);
            cmd.Parameters.AddWithValue("@marca", marca);
            
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        public void Editar(int codigo, string nombre, decimal p_venta, decimal p_compra,
            int stock, string genero, int marca, int id_producto)
        {
            cmd.Connection = conexion.abrir_conexion();
            cmd.CommandText = "EDITAR_PRODUCTO";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@codigo", codigo);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@p_venta", p_venta);
            cmd.Parameters.AddWithValue("@p_compra", p_compra);
            cmd.Parameters.AddWithValue("@stock", stock);
            cmd.Parameters.AddWithValue("@genero", genero);
            cmd.Parameters.AddWithValue("@marca", marca);
            cmd.Parameters.AddWithValue("@id_producto", id_producto);
    
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }


        public void BajaLogica(int id_producto)
        {
            cmd.Connection = conexion.abrir_conexion();
            cmd.CommandText = "BAJA_LOGICA_PRODUCTO";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id_producto", id_producto);

            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }
    }
}
