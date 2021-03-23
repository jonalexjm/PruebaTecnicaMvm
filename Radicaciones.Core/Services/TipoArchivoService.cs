using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radicaciones.Core.Entities;
using Radicaciones.Core.Interfaces;

namespace Radicaciones.Core.Services
{
    public class TipoArchivoService : ITipoArchivoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TipoArchivoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IEnumerable<TipoArchivo> GetTipoArchivoAll()
        {
            return _unitOfWork.tipoArchivoRepository.GetAll();
        }

        public async Task<TipoArchivo> GetTipoArchivo(long id)
        {
            return await _unitOfWork.tipoArchivoRepository.GetById(id);
        }

        public async Task InsertTipoArchivo(TipoArchivo typeDocument)
        {
            try
            {
                await _unitOfWork.tipoArchivoRepository.Add(typeDocument);
                await _unitOfWork.SaveChangesAsync();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> UpdateTipoArchivo(TipoArchivo typeDocument)
        {
            try
            {
                _unitOfWork.tipoArchivoRepository.Update(typeDocument);
                await _unitOfWork.SaveChangesAsync();
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> DeleteTipoArchivo(long id)
        {
            try
            {
                await _unitOfWork.tipoArchivoRepository.Delete(id);
                await _unitOfWork.SaveChangesAsync();
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}