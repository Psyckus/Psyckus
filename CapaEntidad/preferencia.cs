using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class preferencia
    {
        public int idPreferencia { get; set; }
        public categoria_preferencias oCategoria_preferencia { get; set; }
        public bool estado { get; set; }
    }
}
