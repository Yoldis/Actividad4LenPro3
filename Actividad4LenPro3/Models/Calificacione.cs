using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Actividad4LenPro3.Models;

public partial class Calificacione
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage ="La matricula del estudiante es requerida")]
    public string MatriculaEstudiante { get; set; } = null!;
    [Required(ErrorMessage ="El codigo de la materia es requerido")]
    public string CodigoMateria { get; set; } = null!;
    [Required(ErrorMessage ="La nota es requerida")]
    [Range(0, 100, ErrorMessage ="La calificacion debe ser entre 0 y 100")]
    public double Nota { get; set; }
    [Required(ErrorMessage ="El periodo es requerido")]
    public string Periodo { get; set; } = null!;

    [ValidateNever]
    public virtual Materia CodigoMateriaNavigation { get; set; } = null!;
    [ValidateNever]
    public virtual Estudiante MatriculaEstudianteNavigation { get; set; } = null!;
}
