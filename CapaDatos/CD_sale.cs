using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_sale
    {
    

        public int getCorelative()
        {
            int correlativo = 0;

            using (SqlConnection conexion = new SqlConnection("Server = AR-IT25649\\SQLEXPRESS; Database = joyeria; Integrated Security = true"))
            {
                try
                {
                    StringBuilder query =   new StringBuilder();
                    query.AppendLine("select count(*) + 1 from SALE");
                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.CommandType = CommandType.Text;
                    conexion.Open();

                    correlativo = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch
                {
                    correlativo = 0;
                }


        }
            return correlativo;
        }


        public bool restarStock(int id_producto, int cantidad)
        {
            bool respuesta = true;
            
            using (SqlConnection conexion = new SqlConnection("Server = AR-IT25649\\SQLEXPRESS; Database = joyeria; Integrated Security = true"))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("update Producto set stock - @cantidad where id_producto = @id_producto");

                    SqlCommand cmd = new SqlCommand(query.ToString(),conexion);
                    cmd.Parameters.AddWithValue("@cantidad", cantidad);
                    cmd.Parameters.AddWithValue("@id_producto", id_producto);
                    cmd.CommandType= CommandType.Text;
                    conexion.Open();

                    respuesta = cmd.ExecuteNonQuery() > 0 ? true : false;
                }
                catch(Exception ex)
                {
                    respuesta = false;  
                }
            }
            return respuesta;
        }



        public bool sumarStock(int id_producto, int cantidad)
        {
            bool respuesta = true;

            using (SqlConnection conexion = new SqlConnection("Server = AR-IT25649\\SQLEXPRESS; Database = joyeria; Integrated Security = true"))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("update Producto set stock + @cantidad where id_producto = @id_producto");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.Parameters.AddWithValue("@cantidad", cantidad);
                    cmd.Parameters.AddWithValue("@id_producto", id_producto);
                    cmd.CommandType = CommandType.Text;
                    conexion.Open();

                    respuesta = cmd.ExecuteNonQuery() > 0 ? true : false;
                }
                catch (Exception ex)
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }



        public bool RegistrarVenta(Sale obj, DataTable DetalleVenta, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;
            using (SqlConnection conexion = new SqlConnection("Server = AR-IT25649\\SQLEXPRESS; Database = joyeria; Integrated Security = true"))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("registrar_venta", conexion);
                    cmd.Parameters.AddWithValue("id_cliente", obj._cliente.id_cliente);
                    cmd.Parameters.AddWithValue("id_usuario",obj._usuario.id_usuario);
                    cmd.Parameters.AddWithValue("fecha",obj.fecha);
                    cmd.Parameters.AddWithValue("documento_nro",obj.nro);
                    cmd.Parameters.AddWithValue("dni_cliente",obj._cliente.dni);
                    cmd.Parameters.AddWithValue("nombre_cliente",obj._cliente.nombre);
                    cmd.Parameters.AddWithValue("importe", obj.importe);
                    cmd.Parameters.AddWithValue("vuelto", obj.vuelto);
                    cmd.Parameters.AddWithValue("total", obj.total);
                    cmd.Parameters.AddWithValue("apellido_cliente", obj._cliente.apellido);


                    cmd.Parameters.Add("resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("mensaje", SqlDbType.VarChar,500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;

                    conexion.Open();
                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["resultado"].Value);
                    mensaje = cmd.Parameters["mensaje"].Value.ToString();
                }
                catch (Exception ex)
                {
                    respuesta = false;
                    mensaje = ex.Message;
                }
            }

            return respuesta;
        }
    }
}

    
  
