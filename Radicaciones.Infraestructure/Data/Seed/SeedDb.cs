using System;
using System.Linq;
using System.Threading.Tasks;
using Radicaciones.Core.Entities;

namespace Radicaciones.Infraestructure.Data.Seed
{
    public class SeedDb
    {
        private readonly RadicacionesContext context;
        private Random random;

        public SeedDb(RadicacionesContext context)
        {
            this.context = context;
            this.random = new Random();
        }
        
        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();
            
            if (!this.context.TipoArchivo.Any())
            {
                this.AddTipoArchivos("Interno");
                this.AddTipoArchivos("Externo");
                
                await this.context.SaveChangesAsync();
            }
            
            if (!this.context.TipoAnotacion.Any())
            {
                this.AddTipoAnotacion("Agrego Archivo");
                this.AddTipoAnotacion("Edito Archivo");
                this.AddTipoAnotacion("Elimino Archivo");
                this.AddTipoAnotacion("Asigno Archivo");
                
                await this.context.SaveChangesAsync();
            }

            if (!this.context.TipoUsuario.Any())
            {
                this.AddTipoUsuario("Admin");
                this.AddTipoUsuario("Funcionario");
                this.AddTipoUsuario("Gestor");
                this.AddTipoUsuario("No Aplica");


                await this.context.SaveChangesAsync();
            }

        }
        private void AddTipoArchivos(
            string nombre
        )
        {
            this.context.TipoArchivo.Add(new TipoArchivo()
            {
                NombreTipoArchivo = nombre
            });

        }
        
        private void AddTipoAnotacion(
            string nombreEvento
        )
        {
            this.context.TipoAnotacion.Add(new TipoAnotacion()
            {
                NombreEvento = nombreEvento
            });

        }

        private void AddTipoUsuario(
            string nombreTipoUsuario
        )
        {
            this.context.TipoUsuario.Add(new TipoUsuario()
            {
                NombreTipoUsuario = nombreTipoUsuario
            });

        }
    }
}