using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_conexion
    {
        //objeto que guarda la cadena de conexion
        private SqlConnection conexion = new SqlConnection("Server = AR-IT25649\\SQLEXPRESS; Database = joyeria; Integrated Security = true");

        // funcion para abrir la conexion a base  de datos local
        public SqlConnection abrir_conexion()
        {
            if (conexion.State == ConnectionState.Closed)
                conexion.Open();
            return conexion;
        }

        // funcion para cerrar la conexion a base de datos local
        public SqlConnection cerrar_conexion()
        {
            if (conexion.State == ConnectionState.Open)
                conexion.Close();
            return conexion;
        }



        public SqlConnection GetConnection()
        {
            return new SqlConnection(conexion.ConnectionString);
        }
    }
}
