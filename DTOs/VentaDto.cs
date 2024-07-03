namespace Entity.DTOs
{
    public class VentaDto
    {
        public double IdFactura { get; set; }

        public string? NumFact { get; set; }

        public DateTime? Fecha_Hora { get; set; }

        public string? ClienteDetalle { get; set; }

        public string? ProductoDetalle { get; set; }

        public string? ModeloDetalle { get; set; }

        public string? CategDetalle { get; set; }

        public string? MarcaDetalle { get; set; }

        public string? SucursalDetalle { get; set; }

        public string? Caja { get; set; }

        public string? Vendedor { get; set; }

        public double? Precio { get; set; }

        public double? Unidades { get; set; }

        public int? EstadoId { get; set; }

    }
}
