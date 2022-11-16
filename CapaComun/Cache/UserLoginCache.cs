using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaComun.Cache
{
    public class UserLoginCache
    {
        public static int id_usuario { get; set; }
        public static string rol { get; set; }
        public static string nombre { get; set; }
        public static string apellido { get; set; }
        public static string dni { get; set; }
        public static string email { get; set; }
        public static string tel { get; set; }
        public static string direccion { get; set; }
        public static DateTime fecha_nacimiento { get; set; }
        public static string usuario { get; set; }
        public static string contra { get; set; }
    }
}
