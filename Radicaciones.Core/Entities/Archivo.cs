using System;

namespace Radicaciones.Core.Entities
{
    public class Archivo : BaseEntity
    {
        public string NumeroRadicado { get; set; }
        public DateTime FechaRadicado { get; set; }
        public string UrlArchivo { get; set; }
        
        public long TipoArchivoId { get; set; }
        public TipoArchivo TipoArchivo { get; set; }
    }
}