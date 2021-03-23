using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Radicaciones.Core.Entities;

namespace Radicaciones.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TipoArchivo> tipoArchivoRepository { get; }

        IRepository<Usuario> usuarioRepository { get; }

        IRepository<Archivo> archivoRepository { get; }

        IRepository<TipoUsuario> tipoUsuarioRepository { get; }

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
