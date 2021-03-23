using System.Collections.Generic;

namespace Radicaciones.Core.Entities
{
    public class TipoUsuario : BaseEntity
    {
       
        public string NombreTipoUsuario { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
        
    }
}