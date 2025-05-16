using SQLite;

namespace AppProyectoAppMovil.Models
{
    public class Cliente
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string CodigoCliente { get; set; }
        public string Nombre { get; set; }
    }
}
