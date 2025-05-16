using SQLite;
using System.Collections.Generic;

namespace AppProyectoAppMovil.Models
{
    public class OrdenTrabajo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string CodigoOrden { get; set; }

        public int ClienteId { get; set; } // Relación con Cliente

        [Ignore]
        public List<Articulo> Articulos { get; set; } = new List<Articulo>();
    }
}

