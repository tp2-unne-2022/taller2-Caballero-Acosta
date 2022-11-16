using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    public  class CD_cliente
    {
        private CD_conexion conexion = new CD_conexion();


        SqlDataReader mostrar_clientes;
        DataTable tabla_cliente = new DataTable();
        SqlCommand cmd = new SqlCommand();

        public DataTable Mostrar()
        {
            cmd.Connection = conexion.abrir_conexion();
            cmd.CommandText = "MOSTRAR_CLIENTES";
            cmd.CommandType = CommandType.StoredProcedure;
            mostrar_clientes = cmd.ExecuteReader();
            tabla_cliente.Load(mostrar_clientes);
            conexion.cerrar_conexion();
            return tabla_cliente;
        }


        public DataTable MostrarModal()
        {
            cmd.Connection = conexion.abrir_conexion();
            cmd.CommandText = "MOSTRAR_CLIENTES_MODAL";
            cmd.CommandType = CommandType.StoredProcedure;
            mostrar_clientes = cmd.ExecuteReader();
            tabla_cliente.Load(mostrar_clientes);
            conexion.cerrar_conexion();
            return tabla_cliente;
        }



        public void Insertar(string nombre,string apellido, string dni, string email, string tel, string direccion, string fecha)
        {
            cmd.Connection = conexion.abrir_conexion();
            cmd.CommandText = "INSERTAR_CLIENTE";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@apellido", apellido);
            cmd.Parameters.AddWithValue("@dni", dni);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@tel", tel);
            cmd.Parameters.AddWithValue("@direccion", direccion);
            cmd.Parameters.AddWithValue("@fecha_nac", fecha);

            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        public void Editar(string nombre, string apellido, string dni, string email, string tel, string direccion, string fecha, int id)
        {
            cmd.Connection = conexion.abrir_conexion();
            cmd.CommandText = "ACTUALIZAR_CLIENTE";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@apellido", apellido);
            cmd.Parameters.AddWithValue("@dni", dni);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@tel", tel);
            cmd.Parameters.AddWithValue("@direccion", direccion);
            cmd.Parameters.AddWithValue("@fecha_nac", fecha);
            cmd.Parameters.AddWithValue("@id_cliente", id);

            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        public void BajaLogica(int id_cliente)
        {
            cmd.Connection = conexion.abrir_conexion();
            cmd.CommandText = "BAJA_LOGICA_CLIENTE";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id_cliente", id_cliente);

            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }


        


        //==========================//==========================//==========================//==========================


        public List<Cliente> ListarClientes()
        {
            //listar cluentes
            List<Cliente> lista_clientes = new List<Cliente>();
            //using (SqlConnection oconexion = new SqlConnection("Server = AR-IT25649\\SQLEXPRESS; Database = joyeria; Integrated Security = true"))
            using (SqlConnection oconexion = new SqlConnection("Server = AR-IT25649\\SQLEXPRESS; Database = joyeria; Integrated Security = true"))
            {
                try
            {
                    
                    string query = "select nombre, apellido dni, email, tel, direccion, fecha_nacimiento, id_cliente from Cliente where estado = 1";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista_clientes.Add(new Cliente()
                            {
                                nombre = dr["nombre"].ToString(),
                                apellido = dr["apellido"].ToString(),
                                dni = dr["dni"].ToString(),
                                email = dr["email"].ToString(),
                                tel = dr["tel"].ToString(),
                                direccion = dr["direccion"].ToString(),
                                fecha_nacimiento = dr["fecha_nacimiento"].ToString(),
                                id_cliente = Convert.ToInt32(dr["id_cliente"])
                            });
                        }
                    }
                }
                catch (Exception e)
                {
                    lista_clientes = new List<Cliente>();
                }
            }
            return lista_clientes;
        }
    }
}
