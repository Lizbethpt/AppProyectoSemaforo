using System.Collections.Generic;

namespace AppProyectoAppMovil.Models
{
    public class OrdenTrabajo
    {
        public string CodigoOrden { get; set; }
        public List<Articulo> Articulos { get; set; } = new List<Articulo>();
    }
}
