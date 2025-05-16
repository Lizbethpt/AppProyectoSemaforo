using SQLite;

namespace AppProyectoAppMovil.Models
{
    public class Articulo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string CodigoArticulo { get; set; }
        public int CantidadRequerida { get; set; }
        public int CantidadEscaneada { get; set; } = 0;
    }
}
