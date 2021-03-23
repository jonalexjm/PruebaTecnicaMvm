using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;

using Radicaciones.Core.Entities;
using Radicaciones.WebApp.ViewModel;

namespace Radicaciones.WebApp.Helpers
{
    public interface IUserHelper
    {
        Task<Usuario> GetUserAsync(string email);
        Task<IdentityResult> AgregarUsuarioAsync(Usuario user, string password);
        // Task<User> GetUserAsync(Guid userId);
        Task CheckRoleAsync(string roleName);
        Task AddUserToRoleAsync(Usuario user, string roleName);
        Task LogoutAsync();
        Task<bool> IsUserInRoleAsync(Usuario user, string roleName);
        Task<SignInResult> LoginAsync(LoginViewModel model);
    }
}
