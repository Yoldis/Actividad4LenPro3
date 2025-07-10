using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Actividad4LenPro3.Models;

public partial class Estudiante
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage ="El nombre es requerido")]
    [StringLength(100)]
    public string NombreCompleto { get; set; } = null!;
    [Required(ErrorMessage = "La matricula es requerido")]
    [StringLength(15, MinimumLength = 6, ErrorMessage ="Debe tener al menos 6 caracteres")]
    public string Matricula { get; set; } = null!;
    [Required(ErrorMessage ="La carrera es requerida")]
    public string Carrera { get; set; } = null!;
    [Required(ErrorMessage ="El correo es requerido")]
    [EmailAddress(ErrorMessage ="El correo es invalido")]
    public string CorreoElectronico { get; set; } = null!;
    [Phone(ErrorMessage ="El telefono es invalido")]
    [MinLength(10, ErrorMessage ="El telefono debe tener minimo 10 caracteres")]
    public string? Telefono { get; set; }
    [Required(ErrorMessage ="La fecha es requerida")]
    [DataType(DataType.Date, ErrorMessage ="La fecha no es valida")]
    public DateOnly FechaNacimiento { get; set; }
    [Required(ErrorMessage ="El genero es requerido")]
    public string Genero { get; set; } = null!;
    [Required(ErrorMessage ="El turno es requerido")]
    public string Turno { get; set; } = null!;
    [Required(ErrorMessage ="El tipo de ingreso es requerido")]
    public string TipoIngreso { get; set; } = null!;
    
    public bool EstaBecado { get; set; }
    //[Range(0, 10, ErrorMessage ="El porcentaje debe ser entre 0 y 10")]
    public int? PorcentajeBeca { get; set; }

    [Required(ErrorMessage ="Los termino son requeridos")]
    public bool TerminoCondicione { get; set; }

    public virtual ICollection<Calificacione> Calificaciones { get; set; } = new List<Calificacione>();
}
