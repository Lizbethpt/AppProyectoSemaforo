using SQLite;
using AppProyectoAppMovil.Models;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AppProyectoAppMovil.Services
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService()
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "app_database.db");
            _database = new SQLiteAsyncConnection(dbPath);
        }

        public async Task Init()
        {
            await _database.CreateTableAsync<Cliente>();
            await _database.CreateTableAsync<OrdenTrabajo>();
            await _database.CreateTableAsync<Articulo>();
            await _database.CreateTableAsync<OrdenArticulo>();
        }

        // Métodos de ejemplo para obtener datos
        public async Task<Cliente> GetClienteByCodeAsync(string code)
        {
            return await _database.Table<Cliente>().FirstOrDefaultAsync(c => c.CodigoCliente == code);
        }

        public async Task<OrdenTrabajo> GetOrdenByCodeAsync(string code)
        {
            return await _database.Table<OrdenTrabajo>().FirstOrDefaultAsync(o => o.CodigoOrden == code);
        }

        // Puedes agregar más métodos para insertar, actualizar, etc.
    }
}
