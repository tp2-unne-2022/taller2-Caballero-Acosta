using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_marcas
    {
        private CD_marca objMarca = new CD_marca();
        public DataTable MostrarMArcas()
        {
            DataTable tabla_marcas = new DataTable();
            tabla_marcas = objMarca.Mostrar();
            return tabla_marcas;
        }
    }
}
