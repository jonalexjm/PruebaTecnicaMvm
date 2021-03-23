using System;

namespace Radicaciones.Core.Entities
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }
        
        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public string UsuarioActualizacion { get; set; }

    }
}