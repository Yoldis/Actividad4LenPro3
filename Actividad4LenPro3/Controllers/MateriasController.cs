using Actividad4LenPro3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Actividad4LenPro3.Controllers
{
    public class MateriasController : Controller
    {
        private readonly Actividad4LenPro3Context _context;

        public MateriasController(Actividad4LenPro3Context context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View("Crear");
        }


        [HttpPost]
        public IActionResult Registrar(Materia model)
        {
            if (!ModelState.IsValid)
            {
                return View("Crear", model);
            }

            _context.Materias.Add(model);
            var rowCounts = _context.SaveChanges();

            if (rowCounts > 0)
            {
                ViewBag.Mensaje = "Materia registrada correctamente!";
            }
            else
            {
                ViewBag.Mensaje = "Algo salio mal al registrar la materia";

            }

            return RedirectToAction("Lista");
        }


        [HttpGet]
        public IActionResult Lista()
        {
            var materias = _context.Materias.ToList();
            return View(materias);
        }


        [HttpGet]
        public IActionResult Editar(int id)
        {
            var materia = _context.Materias.FirstOrDefault(e => e.Id == id);

            if (materia == null)
            {
                ViewBag.Mensaje = "La materia no existe.";
                return RedirectToAction("Lista");
            }

            return View("Editar", materia);
        }



        [HttpPost]
        public IActionResult Editar(Materia materia)
        {
            if (!ModelState.IsValid)
            {
                return View("Editar", materia);
            }

            var materiaActual = _context.Materias.FirstOrDefault(e => e.Id == materia.Id);

            if (materiaActual == null)
            {
                ViewBag.Mensaje = "La materia no existe.";
                return RedirectToAction("Lista");
            }


            materiaActual.Nombre = materia.Nombre;
            materiaActual.Creditos = materia.Creditos;
            materiaActual.Carrera = materia.Carrera;

            var rowCounts = _context.SaveChanges();

            if (rowCounts > 0)
            {
                ViewBag.Mensaje = "¡Materia modificada correctamente!";
            }
            else
            {
                ViewBag.Mensaje = "No se realizaron cambios en la materia.";
            }

            return RedirectToAction("Lista");
        }




        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            var materia = _context.Materias.FirstOrDefault(e => e.Id == id);
            if (materia == null)
            {
                ViewBag.Mensaje = "La materia no existe.";
                return RedirectToAction("Lista");
            }

            _context.Materias.Remove(materia);
            var rowCounts = _context.SaveChanges();
            if (rowCounts > 0)
            {
                ViewBag.Mensaje = "Materia eliminado correctamente!";
            }
            else
            {
                ViewBag.Mensaje = "Algo salio mal al eliminar el materia";

            }
            return RedirectToAction("Lista");
        }
    }
}
