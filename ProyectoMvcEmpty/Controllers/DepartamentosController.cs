using Microsoft.AspNetCore.Mvc;
using ProyectoMvcEmpty.Data;
using ProyectoMvcEmpty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoMvcEmpty.Controllers
{
    public class DepartamentosController : Controller
    {
        DepartamentosContext context;

        public DepartamentosController()
        {
            this.context = new DepartamentosContext();
        }

        public IActionResult Index()
        {
            List<Departamento> lista = this.context.GetDepartamentos();
            return View(lista);
        }
    }
}
