using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Actividad4LenPro3.Models;

public partial class Materia
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage ="El nombre es requerido")]
    public string Nombre { get; set; } = null!;
    [Required(ErrorMessage = "El codigo es requerido")]
    public string Codigo { get; set; } = null!;
    [Required(ErrorMessage ="Los creditos son requeridos")]
    [Range(0, 10, ErrorMessage ="Los creditos deben estar entre 0 y 10")]
    public int Creditos { get; set; }
    [Required(ErrorMessage ="La carrera es requerida")]
    public string Carrera { get; set; } = null!;

    public virtual ICollection<Calificacione> Calificaciones { get; set; } = new List<Calificacione>();
}
