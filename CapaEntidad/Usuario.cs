using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Usuario
    {
        public int id_usuario { get; set; }
        public string rol { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string dni { get; set; }
        public string email { get; set; }
        public string tel { get; set; }
        public string direccion { get; set; }
        public string fecha_nacimiento { get; set; }
        public string usuario { get; set; }
        public string contra { get; set; }
        public bool estado { get; set; }
    }
}
