using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Radicaciones.Core.Entities;

namespace Radicaciones.Infraestructure
{
    public class RadicacionesContext : DbContext
    {
        public RadicacionesContext(DbContextOptions<RadicacionesContext> options)
           : base(options)
    {

    }
    public DbSet<TipoArchivo> TipoArchivo { get; set; }
    public DbSet<TipoUsuario> TipoUsuario { get; set; }
    public DbSet<TipoAnotacion> TipoAnotacion { get; set; }
    public DbSet<Anotacion> Anotaciones { get; set; }
    public DbSet<Archivo> Archivo { get; set; }
    public DbSet<GestionDocumento> GestionDocumento { get; set; }
    public DbSet<Usuario> Usuario { get; set; }
    
    
}
}
