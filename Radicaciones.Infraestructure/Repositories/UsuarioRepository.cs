using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Radicaciones.Core.Entities;
using Radicaciones.Core.Interfaces;

namespace Radicaciones.Infraestructure.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(RadicacionesContext context) : base(context) { }
    }
}
