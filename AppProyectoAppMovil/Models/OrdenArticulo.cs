using SQLite;

namespace AppProyectoAppMovil.Models
{
    public class OrdenArticulo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int OrdenId { get; set; }

        public int ArticuloId { get; set; }

        public int CantidadEsperada { get; set; }

        public int CantidadEscaneada { get; set; }
    }
}

