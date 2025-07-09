
using Actividad4LenPro3.Models;
using Microsoft.AspNetCore.Mvc;
using System;


namespace Actividad3LenProg3.Controllers
{
    public class EstudiantesController : Controller
    {
        private Actividad4LenPro3Context _context;

        public static List<Estudiante> estudiantes = new List<Estudiante>()
        {

        };
         
        public EstudiantesController(Actividad4LenPro3Context context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View("Crear");
        }

        [HttpPost]
        public IActionResult Registrar(Estudiante estudiante)
        {
            bool existEstudiante = estudiantes.Any(e => e.Matricula == estudiante.Matricula);
            if (!ModelState.IsValid || existEstudiante)
            {
                return View("Crear", estudiante);
            }
            estudiantes.Add(estudiante);
            return View("Lista", estudiantes);
        }

        [HttpGet]
        public IActionResult Lista()
        {
            return View(estudiantes);
        }

        [HttpGet]
        public IActionResult Editar(string matricula)
        {
            var estudianteEncontrado = estudiantes.FirstOrDefault(e => e.Matricula == matricula);
            if (estudianteEncontrado == null)
            {
                ViewBag.Mensaje = "Estudiante no encontrado.";
                //return View("Lista", estudiantes);
            }

            return View("Editar", estudianteEncontrado);
        }


        [HttpPost]
        public IActionResult Editar(Estudiante estudiante)
        {
            var index = estudiantes.FindIndex(e => e.Matricula == estudiante.Matricula);
            if (index != -1)
            {
                estudiantes[index] = estudiante;
                return View("Lista", estudiantes);
            }
            
            ViewBag.Mensaje = "Estudiante no encontrado.";
            return View("Lista", estudiantes); 
        }

        [HttpGet]
        public IActionResult Eliminar(string matricula)
        {
            var estudiante = estudiantes.FirstOrDefault(e => e.Matricula == matricula);
            if (estudiante == null)
            {
                return NotFound();
            }

            estudiantes.Remove(estudiante);

            return View("Lista", estudiantes);
        }
    }
}
