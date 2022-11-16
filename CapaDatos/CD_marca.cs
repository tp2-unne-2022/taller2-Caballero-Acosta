using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public  class CD_marca
    {
        private CD_conexion conexion = new CD_conexion();


        SqlDataReader mostrar_marcas;
        DataTable tabla_marcas = new DataTable();
        SqlCommand cmd = new SqlCommand();

        public DataTable Mostrar()
        {
            cmd.Connection = conexion.abrir_conexion();
            cmd.CommandText = "cargar_combo_marcas";
            cmd.CommandType = CommandType.StoredProcedure;
            mostrar_marcas = cmd.ExecuteReader();
            tabla_marcas.Load(mostrar_marcas);
            conexion.cerrar_conexion();
            return tabla_marcas;
        }
    }
}
