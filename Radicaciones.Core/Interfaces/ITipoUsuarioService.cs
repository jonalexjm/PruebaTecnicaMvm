using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Radicaciones.Core.Entities;

namespace Radicaciones.Core.Interfaces
{
    public interface ITipoUsuarioService
    {
        IEnumerable<TipoUsuario> GetTipoUsuarioAll();
        Task<TipoUsuario> GetTipoUsuario(long id);
        Task InsertTipoUsuario(TipoUsuario typeDocument);
        Task<bool> UpdateTipoUsuario(TipoUsuario typeDocument);
        Task<bool> DeleteTipoUsuario(long id);

    }
}
