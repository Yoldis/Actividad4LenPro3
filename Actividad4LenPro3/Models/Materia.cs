using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Actividad4LenPro3.Models;

public partial class Materia
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Codigo { get; set; } = null!;
    [Required, Range(0,10)]
    public int Creditos { get; set; }
    [Required]
    public string Carrera { get; set; } = null!;

    public virtual ICollection<Calificacione> Calificaciones { get; set; } = new List<Calificacione>();
}
