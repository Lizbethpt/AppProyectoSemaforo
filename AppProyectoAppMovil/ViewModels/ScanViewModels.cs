using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using AppProyectoAppMovil.Models; // Asegúrate de tener este namespace para tus modelos
using AppProyectoAppMovil.Services; // Para DatabaseService
using Microsoft.Maui.Controls; // Para Shell y Command

namespace AppProyectoAppMovil.ViewModels
{
    public class ScanViewModel : BaseViewModel // Nombre más descriptivo que AppProyectoAppMovil
    {
        private readonly DatabaseService _dbService;

        private Cliente _clienteActual;
        public Cliente ClienteActual
        {
            get => _clienteActual;
            set => SetProperty(ref _clienteActual, value);
        }

        private OrdenTrabajo _ordenActual;
        public OrdenTrabajo OrdenActual
        {
            get => _ordenActual;
            set => SetProperty(ref _ordenActual, value);
        }

        public ICommand ScanCommand { get; }
        public ICommand ValidateCommand { get; }

        public ScanViewModel(DatabaseService dbService)
        {
            _dbService = dbService;

            ScanCommand = new Command<string>(async (code) => await ProcessScannedCode(code));
            ValidateCommand = new Command(async () => await ValidateEmbarque());

            // Inicializar propiedades
            OrdenActual = new OrdenTrabajo();
        }

        private async Task ProcessScannedCode(string code)
        {
            if (ClienteActual == null)
            {
                // Buscar cliente en la base de datos
                ClienteActual = await _dbService.GetClienteByCodeAsync(code);
                if (ClienteActual != null)
                {
                    await Shell.Current.DisplayAlert("Éxito", $"Cliente encontrado: {ClienteActual.Nombre}", "OK");
                    return;
                }
            }
            else if (OrdenActual.CodigoOrden == null)
            {
                // Buscar orden de trabajo
                OrdenActual = await _dbService.GetOrdenByCodeAsync(code);
                if (OrdenActual != null)
                {
                    await Shell.Current.DisplayAlert("Éxito", $"Orden encontrada: {OrdenActual.CodigoOrden}", "OK");
                    return;
                }
            }
            else
            {
                // Validar artículo
                var articulo = OrdenActual.Articulos.FirstOrDefault(a => a.CodigoArticulo == code);
                if (articulo != null)
                {
                    if (articulo.CantidadEscaneada < articulo.CantidadRequerida)
                    {
                        articulo.CantidadEscaneada++;
                        await Shell.Current.DisplayAlert("Éxito", $"Artículo escaneado: {code}", "OK");
                    }
                    else
                    {
                        await Shell.Current.DisplayAlert("Error", $"Cantidad máxima alcanzada para: {code}", "OK");
                    }
                    return;
                }
            }

            await Shell.Current.DisplayAlert("Error", "Código no reconocido", "OK");
        }

        private async Task ValidateEmbarque()
        {
            if (OrdenActual == null || OrdenActual.Articulos == null || !OrdenActual.Articulos.Any())
            {
                await Shell.Current.DisplayAlert("Error", "No hay artículos para validar", "OK");
                return;
            }

            bool isValid = OrdenActual.Articulos.All(a =>
                a.CantidadEscaneada == a.CantidadRequerida);

            await Shell.Current.GoToAsync($"//ResultPage?isValid={isValid}");
        }
    }
}
