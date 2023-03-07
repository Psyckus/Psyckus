using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class foto
    {
        public int idfoto { get; set; }
        public string rutaFoto { get; set; }
        public cliente ocliente { get; set; }
        public string base64 { get; set; }
        public string extencion { get; set; }
    }
}
