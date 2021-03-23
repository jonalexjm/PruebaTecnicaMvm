using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Radicaciones.Core.Entities;

namespace Radicaciones.Core.Interfaces
{
    public interface IUsuarioService
    {
        IEnumerable<Usuario> GetUsuarioAll();
        Task<Usuario> GetUsuario(long id);
        Task InsertUsuario(Usuario usuario);
        Task<bool> UpdateUsuario(Usuario usuario);
        Task<bool> DeleteUsuario(long id);
    }
}
