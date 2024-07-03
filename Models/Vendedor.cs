using System;
using System.Collections.Generic;

namespace Entity.Models;

public partial class Vendedor
{
    public int VendedorId { get; set; }

    public string? VendedorDescripcion { get; set; }

    public int EstadoId { get; set; }

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
