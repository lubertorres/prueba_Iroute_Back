using System;
using System.Collections.Generic;

namespace prueba_Iroute_Back.Infrastructure.Models;

public partial class ClienteEntity
{
    public int Id { get; set; }

    public string Identificacion { get; set; } = null!;

    public string PrimerNombre { get; set; } = null!;

    public string? SegundoNombre { get; set; }

    public string Apellidos { get; set; } = null!;

    public string Mail { get; set; } = null!;

    public bool Estado { get; set; }
}
