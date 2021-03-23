using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;

using Radicaciones.Core.Entities;
using Radicaciones.Core.Interfaces;
using Radicaciones.Infraestructure;
using Radicaciones.WebApp.ViewModel;

namespace Radicaciones.WebApp.Helpers
{
    public class UserHelper : IUserHelper
    {
        private readonly RadicacionesContext _context;
        private readonly UserManager<Usuario> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly IUsuarioService _usuarioService;

        public UserHelper(RadicacionesContext context,
                          UserManager<Usuario> userManager,
                          RoleManager<IdentityRole> roleManager,
                          SignInManager<Usuario> signInManager,
                          IUsuarioService usuarioService)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _usuarioService = usuarioService;
        }

        public async Task<IdentityResult> AgregarUsuarioAsync(Usuario user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task AddUserToRoleAsync(Usuario user, string roleName)
        {
            await _userManager.AddToRoleAsync(user, roleName);
        }

        public async Task CheckRoleAsync(string roleName)
        {
            bool roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole
                {
                    Name = roleName
                });
            }
        }

        public async Task<Usuario> GetUserAsync(string email)
        {


            return _usuarioService.GetUsuarioAll().Where(u => u.CorreoElectronico == email).First();

        }


        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
        public async Task<bool> IsUserInRoleAsync(Usuario user, string roleName)
        {
            return await _userManager.IsInRoleAsync(user, roleName);
        }

        public async Task<SignInResult> LoginAsync(LoginViewModel model)
        {
            return await _signInManager.PasswordSignInAsync(
                model.Username,
                model.Password,
                model.RememberMe,
                false);
        }
    }
}
