using AppProyectoAppMovil.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppProyectoAppMovil.Services
{
    public class DatabaseService
    {
        private List<Cliente> _clientes;
        private List<OrdenTrabajo> _ordenes;

        public DatabaseService()
        {
            // Simulación de datos
            _clientes = new List<Cliente>
            {
                new Cliente { CodigoCliente = "CLI123", Nombre = "Cliente Prueba" }
            };

            _ordenes = new List<OrdenTrabajo>
            {
                new OrdenTrabajo
                {
                    CodigoOrden = "ORD456",
                    Articulos = new List<Articulo>
                    {
                        new Articulo { CodigoArticulo = "ART789", CantidadRequerida = 2, CantidadEscaneada = 0 }
                    }
                }
            };
        }

        public Task<Cliente> GetClienteByCodeAsync(string code)
        {
            var cliente = _clientes.FirstOrDefault(c => c.CodigoCliente == code);
            return Task.FromResult(cliente);
        }

        public Task<OrdenTrabajo> GetOrdenByCodeAsync(string code)
        {
            var orden = _ordenes.FirstOrDefault(o => o.CodigoOrden == code);
            return Task.FromResult(orden);
        }
    }
}
