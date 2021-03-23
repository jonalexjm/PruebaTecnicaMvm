using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Radicaciones.Core.Entities;
using Radicaciones.Core.Interfaces;

namespace Radicaciones.WebApp.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly IUsuarioService _usuarioService;
        private readonly ITipoUsuarioService _tipoUsuarioService;

        public UsuarioController(IUsuarioService usuarioService,
                                 ITipoUsuarioService tipoUsuarioService    )
        {
            _usuarioService = usuarioService;
            _tipoUsuarioService = tipoUsuarioService;
        }

        public IActionResult Index()
        {

            return View(_usuarioService.GetUsuarioAll());
        }

        public IActionResult Create()
        {
            var ListTipoDocumento = _tipoUsuarioService.GetTipoUsuarioAll().ToList();
            List<SelectListItem> tipoUsuarioSelect = ListTipoDocumento.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.NombreTipoUsuario.ToString(),
                    Value = d.Id.ToString(),
                    Selected = false
                };
            });


            ViewBag.tipoUsuarioSelect = tipoUsuarioSelect;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _usuarioService.InsertUsuario(usuario);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError(string.Empty, e.Message);
                }
            }

            return Redirect("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(long id)
        {
            var TipoaArchivoResult = await _usuarioService.GetUsuario(id);

            var ListTipoDocumento = _tipoUsuarioService.GetTipoUsuarioAll().ToList();
            List<SelectListItem> tipoUsuarioSelect = ListTipoDocumento.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.NombreTipoUsuario.ToString(),
                    Value = d.Id.ToString(),
                    Selected = false
                };
            });

            ViewBag.tipoUsuarioSelect = tipoUsuarioSelect;

            return View(TipoaArchivoResult);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _usuarioService.UpdateUsuario(usuario);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError(string.Empty, e.Message);
                }
            }

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete(long id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ResultTipoAnotacion = await _usuarioService.GetUsuario(id);
            if (ResultTipoAnotacion == null)
            {
                return NotFound();
            }

            try
            {


                await _usuarioService.DeleteUsuario(id);

            }
            catch
            {
                Console.WriteLine("Error");
            }

            return RedirectToAction(nameof(Index));
        }
    }
}