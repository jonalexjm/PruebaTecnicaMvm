using System;

namespace Radicaciones.Core.Entities
{
    public class Anotacion : BaseEntity
    {
        public DateTime FechaEvento { get; set; }
        public string Usuario { get; set; }
        
        public long TipoAnotacionId { get; set; }
        public TipoAnotacion TipoAnotacion { get; set; }
        
    }
}