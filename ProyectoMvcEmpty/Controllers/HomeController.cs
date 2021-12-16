using Microsoft.AspNetCore.Mvc;
using ProyectoMvcEmpty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoMvcEmpty.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contenido()
        {
            return View();
        }
        public IActionResult OtroContenido()
        {
            return View();
        }

        public IActionResult VistaPersona()
        {
            Persona persona = new Persona();
            persona.Nombre = "Lucia";
            persona.Edad = 18;
            persona.Email = "lucia@gmail.com";
            return View(persona);
        }
    }
}
