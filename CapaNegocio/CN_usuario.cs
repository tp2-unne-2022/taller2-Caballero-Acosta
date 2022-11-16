using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_usuario
    {
        private CD_usuario objUsuario = new CD_usuario();

        public DataTable MostrarUsuarios()
        {
            DataTable tabla_usuarios = new DataTable();
            tabla_usuarios = objUsuario.Mostrar();
            return tabla_usuarios;
        }

        public void InsertarUsuario(string rol, string nombre, string apellido, 
            string dni, string email, string tel, 
            string direccion, string fecha, string usuario, string contra)
        {
            objUsuario.Insertar(rol, nombre, apellido, dni, email, tel, direccion, fecha, usuario, contra);
        }

        public void EditarUsuario(string rol, string nombre, string apellido, string dni, 
            string email, string tel, string direccion, string fecha,string usuario, string contra, string id)
        {
            objUsuario.Editar(rol, nombre, apellido, dni, email, tel, direccion, fecha, usuario, contra, Convert.ToInt32(id));
        }

        public void BajaLogicaUsuario(int id_usuario)
        {
            objUsuario.BajaLogica(id_usuario);
        }


        public bool LoginUSer(string usuario, string contra)
        {
            return objUsuario.login(usuario, contra);
        }
    }
}
