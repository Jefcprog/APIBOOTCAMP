using System;
using System.Collections.Generic;

namespace Entity.Models;

public partial class Caja
{
    public int CajaId { get; set; }

    public string? CajaDescripcion { get; set; }

    public int EstadoId { get; set; }

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
