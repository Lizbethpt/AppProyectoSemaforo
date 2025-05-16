namespace AppProyectoAppMovil.Models
{
    public class Articulo
    {
        public string CodigoArticulo { get; set; }
        public int CantidadRequerida { get; set; }
        public int CantidadEscaneada { get; set; } = 0;
    }
}
