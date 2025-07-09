using System;
using System.Collections.Generic;

namespace Actividad4LenPro3.Models;

public partial class Materia
{
    public int Id { get; set; }

    public string Codigo { get; set; } = null!;

    public int Creditos { get; set; }

    public string Carrera { get; set; } = null!;

    public virtual ICollection<Calificacione> Calificaciones { get; set; } = new List<Calificacione>();
}
