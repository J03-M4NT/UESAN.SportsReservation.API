using System;
using System.Collections.Generic;

namespace UESAN.SportsReservation.CORE.Core.Entities;

public partial class Canchas
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public string Ubicacion { get; set; } = null!;

    public bool? IsActive { get; set; }

    public virtual ICollection<Reservas> Reservas { get; set; } = new List<Reservas>();
}
