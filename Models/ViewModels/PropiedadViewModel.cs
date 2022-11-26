namespace Proyecto.Models.ViewModels
{
    public class PropiedadViewModel
    {
        public int CodigoEscritura { get; set; }
        public string Descripcion { get; set; } = null!;
        public short Area { get; set; }
        public DateTime FechaCompra { get; set; }

        public string Dueno { get; set; } = null!;
    }
}
