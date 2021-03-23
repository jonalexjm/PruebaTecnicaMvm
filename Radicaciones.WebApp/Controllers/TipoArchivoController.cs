using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Radicaciones.Core.Entities;
using Radicaciones.Core.Interfaces;

namespace Radicaciones.WebApp.Controllers
{
    public class TipoArchivoController : Controller
    {
        private readonly ITipoArchivoService _tipoArchivoService;
       
        public TipoArchivoController(ITipoArchivoService tipoArchivoService)
        {
            _tipoArchivoService = tipoArchivoService;
        }
        public IActionResult Index()
        {

            return View(_tipoArchivoService.GetTipoArchivoAll());
        }

        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TipoArchivo tipoArchivo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _tipoArchivoService.InsertTipoArchivo(tipoArchivo);            
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
            var TipoaArchivoResult = await _tipoArchivoService.GetTipoArchivo(id);

            return View(TipoaArchivoResult);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TipoArchivo tipoArchivo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _tipoArchivoService.UpdateTipoArchivo(tipoArchivo);
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
                   
           var ResultTipoAnotacion = await _tipoArchivoService.GetTipoArchivo(id);
            if (ResultTipoAnotacion == null)
            {
                return NotFound();
            }

            try
            {

               
                await _tipoArchivoService.DeleteTipoArchivo(id);               
                
            }
            catch
            {
                Console.WriteLine("Error");
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
