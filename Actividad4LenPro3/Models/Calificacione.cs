using System;
using System.Collections.Generic;

namespace Actividad4LenPro3.Models;

public partial class Calificacione
{
    public int Id { get; set; }

    public string MatriculaEstudiante { get; set; } = null!;

    public string CodigoMateria { get; set; } = null!;

    public double Nota { get; set; }

    public string Periodo { get; set; } = null!;

    public virtual Materia CodigoMateriaNavigation { get; set; } = null!;

    public virtual Estudiante MatriculaEstudianteNavigation { get; set; } = null!;
}
