using Actividad4LenPro3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Actividad4LenPro3.Controllers
{
    public class EstudiantesController : Controller
    {
        private readonly Actividad4LenPro3Context _context;

        public EstudiantesController(Actividad4LenPro3Context context)
        {
            _context = context;
        }

        
        public IActionResult Index()
        {
            return View("Crear");
        }

        
        [HttpPost]
        public IActionResult Registrar(Estudiante model)
        {
            if (!ModelState.IsValid)
            {
                return View("Crear", model);
            }

            _context.Estudiantes.Add(model);
            var rowCounts = _context.SaveChanges();

            if(rowCounts > 0)
            {
                ViewBag.Mensaje = "Estudiante registrado correctamente!";
            }
            else
            {
                ViewBag.Mensaje = "Algo salio mal al registrar el estudiante";

            }

            return RedirectToAction("Lista");
        }

        
        [HttpGet]
        public IActionResult Lista()
        {
            var estudiantes = _context.Estudiantes.ToList();
            return View(estudiantes);
        }


        [HttpGet]
        public IActionResult Editar(string matricula)
        {
            var estudiante = _context.Estudiantes.FirstOrDefault(e => e.Matricula == matricula);

            if (estudiante == null)
            {
                ViewBag.Mensaje = "El estudiante no existe.";
                return RedirectToAction("Lista");
            }

            return View("Editar", estudiante);
        }



        [HttpPost]
        public IActionResult Editar(Estudiante estudiante)
        {
            if (!ModelState.IsValid)
            {
                return View("Editar", estudiante);
            }

            var estudianteActual = _context.Estudiantes.FirstOrDefault(e => e.Matricula.Equals(estudiante.Matricula));

            if (estudianteActual == null)
            {
                ViewBag.Mensaje = "El estudiante no existe.";
                return RedirectToAction("Lista");
            }

            estudianteActual.NombreCompleto = estudiante.NombreCompleto;
            estudianteActual.Carrera = estudiante.Carrera;
            estudianteActual.CorreoElectronico = estudiante.CorreoElectronico;
            estudianteActual.Telefono = estudiante.Telefono;
            estudianteActual.FechaNacimiento = estudiante.FechaNacimiento;
            estudianteActual.Genero = estudiante.Genero;
            estudianteActual.Turno = estudiante.Turno;
            estudianteActual.TipoIngreso = estudiante.TipoIngreso;
            estudianteActual.EstaBecado = estudiante.EstaBecado;
            estudianteActual.PorcentajeBeca = estudiante.PorcentajeBeca;
            estudianteActual.TerminoCondicione = estudiante.TerminoCondicione;

            var rowCounts = _context.SaveChanges();

            if (rowCounts > 0)
            {
                ViewBag.Mensaje = "Estudiante modificado correctamente!";
            }
            else
            {
                ViewBag.Mensaje = "Algo salió mal al modificar el estudiante.";
            }

            return RedirectToAction("Lista");
        }



        [HttpGet]
        public IActionResult Eliminar(string matricula)
        {
            var estudiante = _context.Estudiantes.FirstOrDefault(e => e.Matricula == matricula);
            if (estudiante == null)
            {
                ViewBag.Mensaje = "El estudiante no existe.";
                return RedirectToAction("Lista");
            }

            _context.Estudiantes.Remove(estudiante);
            var rowCounts = _context.SaveChanges();
            if (rowCounts > 0)
            {
                ViewBag.Mensaje = "Estudiante eliminado correctamente!";
            }
            else
            {
                ViewBag.Mensaje = "Algo salio mal al eliminar el estudiante";

            }
            return RedirectToAction("Lista");
        }
    }
}
