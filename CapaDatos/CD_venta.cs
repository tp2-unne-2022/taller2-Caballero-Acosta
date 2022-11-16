using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CapaDatos
{
    public  class CD_ventaDetalle { 
    //{
    //    private CD_conexion conexion = new CD_conexion();


    //    SqlDataReader mostrar_ventas;
    //    DataTable tabla_venta = new DataTable();
    //    SqlCommand cmd = new SqlCommand();

    //    public DataTable Mostrar()
    //    {
    //        cmd.Connection = conexion.abrir_conexion();
    //        cmd.CommandText = "MOSTRAR_VENTAS";
    //        cmd.CommandType = CommandType.StoredProcedure;
    //        mostrar_ventas = cmd.ExecuteReader();
    //        tabla_venta.Load(mostrar_ventas);
    //        conexion.cerrar_conexion();
    //        return tabla_venta;
    //    }

    //    public void Insertar()
    //    {
    //        cmd.Connection = conexion.abrir_conexion();
    //        cmd.CommandText = "insertar_venta";
    //        cmd.CommandType = CommandType.StoredProcedure;

    //        cmd.Parameters.AddWithValue("@nombre", nombre);


    //        cmd.ExecuteNonQuery();
    //        cmd.Parameters.Clear();
    //    }
    }
}
