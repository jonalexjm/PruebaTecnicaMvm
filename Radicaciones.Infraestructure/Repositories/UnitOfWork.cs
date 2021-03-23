using Radicaciones.Core.Entities;
using Radicaciones.Core.Interfaces;
using System.Threading.Tasks;

namespace Radicaciones.Infraestructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RadicacionesContext _context;
        private readonly IRepository<TipoArchivo> _tipoArchivoRepository;
        private readonly IRepository<Usuario> _usuarioRepository;
        private readonly IRepository<Archivo> _archivoRepository;
        private readonly IRepository<TipoUsuario> _tipoUsuarioRepository;

        public UnitOfWork(RadicacionesContext context)
        {
            _context = context;
                
        }
        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
        public IRepository<TipoArchivo> tipoArchivoRepository =>
            _tipoArchivoRepository ?? new BaseRepository<TipoArchivo>(_context);

        public IRepository<Usuario> usuarioRepository =>
            _usuarioRepository ?? new BaseRepository<Usuario>(_context);

        public IRepository<Archivo> archivoRepository =>
            _archivoRepository ?? new BaseRepository<Archivo>(_context);

        public IRepository<TipoUsuario> tipoUsuarioRepository =>
            _tipoUsuarioRepository ?? new BaseRepository<TipoUsuario>(_context);



        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        
    }
}