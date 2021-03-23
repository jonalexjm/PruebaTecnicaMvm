using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Radicaciones.Core.Entities;
using Radicaciones.Core.Interfaces;

namespace Radicaciones.Core.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsuarioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> DeleteUsuario(long id)
        {
            try
            {
                await _unitOfWork.usuarioRepository.Delete(id);
                await _unitOfWork.SaveChangesAsync();
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async  Task<Usuario> GetUsuario(long id)
        {
            return await _unitOfWork.usuarioRepository.GetById(id);
        }

        public IEnumerable<Usuario> GetUsuarioAll()
        {
            return _unitOfWork.usuarioRepository.GetAll();
        }

        public async  Task InsertUsuario(Usuario usuario)
        {
            try
            {
                await _unitOfWork.usuarioRepository.Add(usuario);
                await _unitOfWork.SaveChangesAsync();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async  Task<bool> UpdateUsuario(Usuario usuario)
        {
            try
            {
                _unitOfWork.usuarioRepository.Update(usuario);
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
