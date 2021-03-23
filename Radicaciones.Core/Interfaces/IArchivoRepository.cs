using System.Threading.Tasks;

using Radicaciones.Core.Entities;
using Radicaciones.Core.ViewModel;


namespace Radicaciones.Core.Interfaces
{
    public interface IArchivoRepository : IRepository<Archivo>
    {
        Task RadicarDocumento(RadicadoViewModel radicadoViewModel);
    }
}