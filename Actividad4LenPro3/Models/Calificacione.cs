using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Actividad4LenPro3.Models;

public partial class Calificacione
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string MatriculaEstudiante { get; set; } = null!;
    [Required]
    public string CodigoMateria { get; set; } = null!;
    [Required, Range(0, 100)]
    public double Nota { get; set; }
    [Required]
    public string Periodo { get; set; } = null!;

    public virtual Materia CodigoMateriaNavigation { get; set; } = null!;

    public virtual Estudiante MatriculaEstudianteNavigation { get; set; } = null!;
}
