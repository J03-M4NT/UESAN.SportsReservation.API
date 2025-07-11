﻿using System;
using System.Collections.Generic;

namespace UESAN.SportsReservation.CORE.Core.Entities;

public partial class Reservas
{
    public int Id { get; set; }

    public DateOnly Fecha { get; set; }

    public TimeOnly HoraInicio { get; set; }

    public TimeOnly HoraFin { get; set; }

    public string ClienteNombre { get; set; } = null!;

    public int CanchaId { get; set; }

    public virtual Canchas Cancha { get; set; } = null!;
}
