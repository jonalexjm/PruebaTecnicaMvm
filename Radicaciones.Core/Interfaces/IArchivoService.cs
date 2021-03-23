using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Radicaciones.Core.Entities;
using Radicaciones.Core.ViewModel;

namespace Radicaciones.Core.Interfaces
{
    public interface IArchivoService
    {
        IEnumerable<Archivo> GetArchivoAll();
        Task<Archivo> GetArchivo(long id);
        Task InsertArchivo(Archivo typeDocument);
        Task<bool> UpdateArchivo(Archivo typeDocument);
        Task<bool> DeleteArchivo(long id);
        Task InsertarArchivoProcedure(RadicadoViewModel radicadoViewModel);
    }
}


