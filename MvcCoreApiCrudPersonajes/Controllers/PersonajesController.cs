using Microsoft.AspNetCore.Mvc;
using MvcCoreApiCrudPersonajes.Models;
using MvcCoreApiCrudPersonajes.Service;

namespace MvcCoreApiCrudPersonajes.Controllers
{
    public class PersonajesController : Controller
    {
        private ServiceApiPersonajes service;

        public PersonajesController(ServiceApiPersonajes service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            List<Personaje> personajes =
                await this.service.GetPersonajesAsync();
            return View(personajes);
        }
        public async Task<IActionResult> Details(int id)
        {
            Personaje personaje =
                await this.service.FindPersonajeAsync(id);
            return View(personaje);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Personaje per)
        {
            await this.service.InsertPersonajeAsync
                (per.Nombre, per.Imagen, per.IdSerie);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            Personaje personaje =
                await this.service.FindPersonajeAsync(id);
            return View(personaje);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Personaje per)
        {
            await this.service.UpdatePersonajeAsync
                (per.IdPersonaje, per.Nombre, per.Imagen, per.IdSerie);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await this.service.DeletePersonajeAsync(id);
            return RedirectToAction("Index");
        }
    }
}
