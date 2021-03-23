using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Radicaciones.Core.Entities;
using Radicaciones.Core.Interfaces;

namespace Radicaciones.Core.Services
{
    public class TipoUsuarioService : ITipoUsuarioService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TipoUsuarioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async  Task<bool> DeleteTipoUsuario(long id)
        {
            try
            {
                await _unitOfWork.tipoUsuarioRepository.Delete(id);
                await _unitOfWork.SaveChangesAsync();
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async  Task<TipoUsuario> GetTipoUsuario(long id)
        {
            return await _unitOfWork.tipoUsuarioRepository.GetById(id);
        }

        public  IEnumerable<TipoUsuario> GetTipoUsuarioAll()
        {
            return _unitOfWork.tipoUsuarioRepository.GetAll();
        }

        public async  Task InsertTipoUsuario(TipoUsuario typeDocument)
        {
            try
            {
                await _unitOfWork.tipoUsuarioRepository.Add(typeDocument);
                await _unitOfWork.SaveChangesAsync();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async  Task<bool> UpdateTipoUsuario(TipoUsuario typeDocument)
        {

            try
            {
                _unitOfWork.tipoUsuarioRepository.Update(typeDocument);
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
