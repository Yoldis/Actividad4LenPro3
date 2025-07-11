using Actividad4LenPro3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Actividad4LenPro3.Controllers
{
    public class CalificacionesController : Controller
    {
        private readonly Actividad4LenPro3Context _context;

        public CalificacionesController(Actividad4LenPro3Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Estudiantes = _context.Estudiantes
                .Select(e => new SelectListItem
                {
                    Value = e.Matricula,
                    Text = e.Matricula + " - " + e.NombreCompleto
                }).ToList();

            ViewBag.Materias = _context.Materias
                .Select(m => new SelectListItem
                {
                    Value = m.Codigo,
                    Text = m.Codigo + " - " + m.Nombre
                }).ToList();

            return View("Crear");
        }


        [HttpPost]
        public IActionResult Registrar(Calificacione model)
        {
            if (!ModelState.IsValid)
            {

                ViewBag.Estudiantes = _context.Estudiantes
                    .Select(e => new SelectListItem
                    {
                        Value = e.Matricula,
                        Text = e.Matricula + " - " + e.NombreCompleto
                    }).ToList();

                ViewBag.Materias = _context.Materias
                    .Select(m => new SelectListItem
                    {
                        Value = m.Codigo,
                        Text = m.Codigo + " - " + m.Nombre
                    }).ToList();

                return View("Crear", model);
            }

            _context.Calificaciones.Add(model);
            _context.SaveChanges();

            TempData["Mensaje"] = "¡Calificación registrada correctamente!";
            return RedirectToAction("Lista");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var calificacion = _context.Calificaciones.FirstOrDefault(e => e.Id == id);

            if (calificacion == null)
            {
                ViewBag.Mensaje = "La calificacion no existe.";
                return RedirectToAction("Lista");
            }

            ViewBag.Estudiantes = _context.Estudiantes
                   .Select(e => new SelectListItem
                   {
                       Value = e.Matricula,
                       Text = e.Matricula + " - " + e.NombreCompleto
                   }).ToList();

            ViewBag.Materias = _context.Materias
                .Select(m => new SelectListItem
                {
                    Value = m.Codigo,
                    Text = m.Codigo + " - " + m.Nombre
                }).ToList();
            return View("Editar", calificacion);
        }


        [HttpPost]
        public IActionResult Editar(Calificacione calificacion)
        {
            if (!ModelState.IsValid)
            {
                return View("Editar", calificacion);
            }

            var calificacionActual = _context.Calificaciones.FirstOrDefault(e => e.Id == calificacion.Id);

            if (calificacionActual == null)
            {
                ViewBag.Mensaje = "La materia no existe.";
                return RedirectToAction("Lista");
            }


            calificacionActual.MatriculaEstudiante = calificacion.MatriculaEstudiante;
            calificacionActual.CodigoMateria = calificacion.CodigoMateria;
            calificacionActual.Nota = calificacion.Nota;
            calificacionActual.Periodo = calificacion.Periodo;

            var rowCounts = _context.SaveChanges();

            if (rowCounts > 0)
            {
                ViewBag.Mensaje = "¡Calificaion modificada correctamente!";
            }
            else
            {
                ViewBag.Mensaje = "No se realizaron cambios en la calificacion.";
            }

            return RedirectToAction("Lista");
        }


        [HttpGet]
        public IActionResult Lista()
        {
            var calificaciones = _context.Calificaciones.ToList();
            return View(calificaciones);
        }

        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            var calificacion = _context.Calificaciones.FirstOrDefault(c => c.Id == id);
            if (calificacion == null)
            {
                TempData["Mensaje"] = "La calificación no existe.";
                return RedirectToAction("Lista");
            }

            _context.Calificaciones.Remove(calificacion);
            _context.SaveChanges();

            TempData["Mensaje"] = "Calificación eliminada correctamente.";
            return RedirectToAction("Lista");
        }
    }
}
