using Microsoft.AspNet.Identity.EntityFramework;

namespace Radicaciones.Core.Entities
{
    public class Usuario :  BaseEntity
    {
        
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string NumeroDocumento { get; set; }
        public string Ciudad { get; set; }
        public string CorreoElectronico { get; set; }
        public string Contraseña { get; set; }
        
        public long TipoUsuarioId { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
    }
}