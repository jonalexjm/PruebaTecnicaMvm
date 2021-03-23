using System.Collections.Generic;

namespace Radicaciones.Core.Entities
{
    public class TipoAnotacion : BaseEntity
    {
        public string NombreEvento { get; set; }
        public virtual ICollection<Anotacion> Anotaciones { get; set; }
    }
}