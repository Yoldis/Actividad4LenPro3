using System;
using System.Collections.Generic;

namespace Actividad4LenPro3.Models;

public partial class Estudiante
{
    public int Id { get; set; }

    public string NombreCompleto { get; set; } = null!;

    public string Matricula { get; set; } = null!;

    public string Carrera { get; set; } = null!;

    public string CorreoElectronico { get; set; } = null!;

    public string? Telefono { get; set; }

    public DateOnly FechaNacimiento { get; set; }

    public string Genero { get; set; } = null!;

    public string Turno { get; set; } = null!;

    public string TipoIngreso { get; set; } = null!;

    public bool EstaBecado { get; set; }

    public int? PorcentajeBeca { get; set; }

    public bool TerminoCondicione { get; set; }

    public virtual ICollection<Calificacione> Calificaciones { get; set; } = new List<Calificacione>();
}
