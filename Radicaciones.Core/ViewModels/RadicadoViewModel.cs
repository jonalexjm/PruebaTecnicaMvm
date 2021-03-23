using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

namespace Radicaciones.Core.ViewModel
{
    public class RadicadoViewModel
    {
        public long UsuarioIdDestinatario { get; set; }
        public long UsuarioIdRemitente { get; set; }
        public long TipoArchivoId { get; set; }
        public string Observaciones { get; set; }
        public string UrlArchivo { get; set; }

        public IFormFile Archivo { set; get; }



    }
}
