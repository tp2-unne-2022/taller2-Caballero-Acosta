using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
namespace CapaNegocio
{
    public class CN_cliente
    {
        private CD_cliente objCliente = new CD_cliente();
        public DataTable MostrarClientes()
        {
            DataTable tabla_clientes = new DataTable();
            tabla_clientes = objCliente.Mostrar();
            return tabla_clientes;
        }

        public DataTable MostrarModal()
        {
            DataTable tabla_clientes = new DataTable();
            tabla_clientes = objCliente.MostrarModal();
            return tabla_clientes;
        }

        public void InsertarCliente(string nombre, string apellido, string dni, string email, string tel, string direccion, string fecha)
        {
            objCliente.Insertar(nombre, apellido, dni, email, tel, direccion, fecha);
        }

        public void EditarCliente(string nombre, string apellido, string dni, string email, string tel, string direccion, string fecha, string id)
        {
            objCliente.Editar(nombre, apellido, dni, email, tel, direccion, fecha, Convert.ToInt32(id));
        }

        public void BajaLogicaCliente(int id_cliente)
        {
            objCliente.BajaLogica(id_cliente);
        }

        public List<Cliente> ListarClientes()
        {
            return objCliente.ListarClientes();
        }
    }
}
