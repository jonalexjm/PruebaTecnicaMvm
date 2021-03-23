using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

using Radicaciones.Infraestructure;
using Radicaciones.Core.Interfaces;
using Radicaciones.Core.Services;
using Radicaciones.Infraestructure.Data.Seed;
using Radicaciones.Infraestructure.Repositories;
using Radicaciones.WebApp.Helpers;
using Radicaciones.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace Radicaciones.WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            

            services.AddDbContext<RadicacionesContext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("SqlServerConnection"));
                //configuracion del servidor
            });

            //services.AddIdentity<Usuario, IdentityRole>(cfg =>
            //{
            //    cfg.User.RequireUniqueEmail = true;
            //    cfg.Password.RequireDigit = false;
            //    cfg.Password.RequiredUniqueChars = 0;
            //    cfg.Password.RequireLowercase = false;
            //    cfg.Password.RequireNonAlphanumeric = false;
            //    cfg.Password.RequireUppercase = false;
            //}).AddEntityFrameworkStores<RadicacionesContext>();

            services.AddTransient<SeedDb>();
           // services.AddTransient<IUserHelper, UserHelper>();
            services.AddTransient<ITipoArchivoService, TipoArchivoService>();
            services.AddTransient<IArchivoService, ArchivoService>();
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<ITipoUsuarioService, TipoUsuarioService>();
            services.AddTransient<IArchivoRepository, ArchivoRepository>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}