using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Radicaciones.Core.Interfaces;


namespace Radicaciones.Core.ViewModel
{
    public class ArchivoController : Controller
    {

        private readonly IArchivoService _archivoService;
        private readonly ITipoArchivoService _tipoArchivoService;
        private readonly IUsuarioService _usuarioService;
        private readonly IHostingEnvironment hostingEnvironment;

        public ArchivoController(IArchivoService archivoService,
                                 ITipoArchivoService tipoArchivoService,
                                 IUsuarioService usuarioService,
                                 IHostingEnvironment environment)
        {
            _tipoArchivoService = tipoArchivoService;
            _archivoService = archivoService;
            _usuarioService = usuarioService;
            hostingEnvironment = environment;
        }
        // GET
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            var ListTipoDocumento = _tipoArchivoService.GetTipoArchivoAll().ToList();
            List<SelectListItem> tipoArchivoSelect = ListTipoDocumento.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.NombreTipoArchivo.ToString(),
                    Value = d.Id.ToString(),
                    Selected = false
                };
            });

            var ListUsuario = _usuarioService.GetUsuarioAll().ToList();
            List<SelectListItem> usuarioSelect = ListUsuario.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = (d.Nombre.ToString() + d.Apellido.ToString()),
                    Value = d.Id.ToString(),
                    Selected = false
                };
            });

            ViewBag.tipoArchivoSelect = tipoArchivoSelect;
            ViewBag.usuarioSelect = usuarioSelect;
           

            return View();
        }

        [HttpPost]
        public IActionResult Create(RadicadoViewModel radicadoViewModel)
        {
                     
            if (ModelState.IsValid)
            {
                try
                {
                    var img = radicadoViewModel.Archivo;
                    string nombreDocumento = "example.pdf";
                    var uniqueFileName = GetUniqueFileName(nombreDocumento);
                    var uploads = Path.Combine(hostingEnvironment.WebRootPath, "uploads");
                    var filePath = Path.Combine(uploads, uniqueFileName);
                    radicadoViewModel.Archivo.CopyTo(new FileStream(filePath, FileMode.Create));
                    radicadoViewModel.UrlArchivo = filePath;
                    _archivoService.InsertarArchivoProcedure(radicadoViewModel);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError(string.Empty, e.Message);
                }
            }
            return Redirect("Index");

        }

        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }
    }
}