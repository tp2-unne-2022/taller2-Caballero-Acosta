using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Cliente
    {
        public int id_cliente { get; set; }
        //public string nombre_completo { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string dni { get; set; }
        public string email { get; set; }
        public string tel { get; set; }
        public string direccion { get; set; }
        public string fecha_nacimiento { get; set; }
        public bool estado { get; set; }
    }
}
