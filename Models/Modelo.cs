﻿using System;
using System.Collections.Generic;

namespace Entity.Models;

public partial class Modelo
{
    public double ModeloId { get; set; }

    public string? ModeloDescripción { get; set; }

    public int? EstadoId { get; set; }

    public DateTime? FechaHoraReg { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
