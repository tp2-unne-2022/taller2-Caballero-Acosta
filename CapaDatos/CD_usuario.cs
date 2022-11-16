using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaComun;
using CapaComun.Cache;

namespace CapaDatos
{
    public class CD_usuario:CD_conexion
    {
        private CD_conexion conexion = new CD_conexion();

        SqlDataReader mostrar_usuarios;
        DataTable tabla_usuarios = new DataTable();
        SqlCommand cmd = new SqlCommand();

        public DataTable Mostrar()
        {
            cmd.Connection = conexion.abrir_conexion();
            cmd.CommandText = "MOSTRAR_USUARIOS";
            cmd.CommandType = CommandType.StoredProcedure;
            mostrar_usuarios = cmd.ExecuteReader();
            tabla_usuarios.Load(mostrar_usuarios);
            conexion.cerrar_conexion();
            return tabla_usuarios;  
        }

        public void Insertar(string rol, string nombre, string apellido, 
            string dni, string email, string tel, 
            string direccion, string fecha, 
            string usuario, string contra)
        {
            cmd.Connection = conexion.abrir_conexion();
            cmd.CommandText = "INSERTAR_USUARIO";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@rol",rol);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@apellido", apellido);
            cmd.Parameters.AddWithValue("@dni", dni);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@tel", tel);
            cmd.Parameters.AddWithValue("@direccion", direccion);
            cmd.Parameters.AddWithValue("@fecha_nac", fecha);
            cmd.Parameters.AddWithValue("@usuario", usuario);
            cmd.Parameters.AddWithValue("@contra", contra);

            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        public void Editar(string rol, string nombre, string apellido, string dni, 
            string email, string tel, string direccion, string fecha, string usuario, string contra, int id)
        {
            cmd.Connection = conexion.abrir_conexion();
            cmd.CommandText = "ACTUALIZAR_USUARIO";
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@rol", rol);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@apellido", apellido);
            cmd.Parameters.AddWithValue("@dni", dni);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@tel", tel);
            cmd.Parameters.AddWithValue("@direccion", direccion);
            cmd.Parameters.AddWithValue("@fecha_nac", fecha);
            cmd.Parameters.AddWithValue("@usuario", usuario);
            cmd.Parameters.AddWithValue("@contra", contra);
            cmd.Parameters.AddWithValue("@id_usuario", id);

            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        public void BajaLogica(int id_usuario)
        {
            cmd.Connection = conexion.abrir_conexion();
            cmd.CommandText = "BAJA_LOGICA_USUARIO";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id_usuario", id_usuario);

            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }


        public bool login(string usuario, string contra)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "select * from Usuario where usuario = @usuario and contra = @contra";
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@contra", contra);
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {


                        while (dr.Read())
                        {
                            UserLoginCache.id_usuario = dr.GetInt32(0);
                            UserLoginCache.rol = dr.GetString(1);
                            UserLoginCache.nombre = dr.GetString(2);
                            UserLoginCache.apellido = dr.GetString(3);
                            UserLoginCache.dni = dr.GetString(4);
                            UserLoginCache.email = dr.GetString(5);
                            UserLoginCache.tel = dr.GetString(6);
                            UserLoginCache.direccion = dr.GetString(7);
                            UserLoginCache.fecha_nacimiento = dr.GetDateTime(8);
                            UserLoginCache.usuario = dr.GetString(9);
                            UserLoginCache.contra = dr.GetString(9);
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
        }
    }
}