using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Radicaciones.Core.Entities;

namespace Radicaciones.Core.Interfaces
{
    public interface ITipoArchivoService
    {
        IEnumerable<TipoArchivo> GetTipoArchivoAll();
        Task<TipoArchivo> GetTipoArchivo(long id);
        Task InsertTipoArchivo(TipoArchivo typeDocument);
        Task<bool> UpdateTipoArchivo(TipoArchivo typeDocument);
        Task<bool> DeleteTipoArchivo(long id);
    }
}
