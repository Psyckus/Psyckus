using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class usuario
    {
        public int idUsuario { get; set; }
        public int idRol { get; set; }
        public int identificacion { get; set; }
        public int tipoIdentificacion { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set;}
        public string email { get; set; }
        public string clave { get; set; }
        public bool Reestablecer { get; set;}
        public  bool activo { get; set; }

    }
}
