using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Radicaciones.Core.Entities;
using Radicaciones.Core.Interfaces;
using Radicaciones.Core.ViewModel;

namespace Radicaciones.Core.Services
{
    public class ArchivoService : IArchivoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IArchivoRepository _archivoRepository;
        public ArchivoService(IUnitOfWork unitOfWork, IArchivoRepository archivoRepository)
        {
            _unitOfWork = unitOfWork;
            _archivoRepository = archivoRepository;
        }

        public Task<bool> DeleteArchivo(long id)
        {
            throw new NotImplementedException();
        }

        public async  Task<Archivo> GetArchivo(long id)
        {
            return await _unitOfWork.archivoRepository.GetById(id);
        }

        public IEnumerable<Archivo> GetArchivoAll()
        {
            return _unitOfWork.archivoRepository.GetAll();
        }

        public async  Task InsertArchivo(Archivo typeDocument)
        {
            try
            {
                await _unitOfWork.archivoRepository.Add(typeDocument);
                await _unitOfWork.SaveChangesAsync();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async  Task<bool> UpdateArchivo(Archivo typeDocument)
        {
            try
            {
                _unitOfWork.archivoRepository.Update(typeDocument);
                await _unitOfWork.SaveChangesAsync();
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task InsertarArchivoProcedure(RadicadoViewModel radicadoViewModel)
        {
            try
            {
                
                await _archivoRepository.RadicarDocumento(radicadoViewModel);
                await _unitOfWork.SaveChangesAsync();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
}
