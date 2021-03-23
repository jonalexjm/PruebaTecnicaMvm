using System;

namespace Radicaciones.Core.Entities
{
    public class GestionDocumento : BaseEntity
    {
        public string Observaciones { get; set; }
        public DateTime FechaEnvio { get; set; }
        
        public long ArchivoId { get; set; }
        public Archivo Archivo { get; set; }
        
        public long UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}