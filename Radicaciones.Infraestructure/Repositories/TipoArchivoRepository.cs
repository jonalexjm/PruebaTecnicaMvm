using Radicaciones.Core.Entities;
using Radicaciones.Core.Interfaces;

namespace Radicaciones.Infraestructure.Repositories
{
    public class TipoArchivoRepository : BaseRepository<TipoArchivo>, ITipoArchivoRepository
    {
        public TipoArchivoRepository(RadicacionesContext context) : base(context){}
    }
}