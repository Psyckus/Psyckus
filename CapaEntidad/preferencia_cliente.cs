using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class preferencia_cliente
    {
        public int idPreferenciaCliente { get; set; }
        public preferencia opreferencia { get; set; }
        public cliente ocliente { get; set; }
    }
}
