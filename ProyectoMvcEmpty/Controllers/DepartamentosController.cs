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

        public IActionResult Details(int id)
        {
            Departamento departamento = this.context.FindDepartamento(id);
            return View(departamento);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(int id, String nombre, String localidad)
        {
            int results = this.context.InsertDepartamento(id, nombre, localidad);
            ViewData["MENSAJE"] = "Departamentos insertados " + results;
            return View();
        }

        public IActionResult Edit(int id)
        {
            Departamento departamento = this.context.FindDepartamento(id);
            return View(departamento);
        }

        [HttpPost]
        public IActionResult Edit(Departamento departamento)
        {
            int results = this.context.UpdateDepartamento(departamento.IdDepartamento
                , departamento.Nombre, departamento.Localidad);
            ViewData["MENSAJE"] = "Departamento modificado: " + results;
            return View(departamento);
        }
    }
}
