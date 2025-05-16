using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppProyectoAppMovil.ViewModels
{
    public class ResultViewModel : BaseViewModel
    {
        public bool IsValid { get; set; }
        public Color BackgroundColor => IsValid ? Colors.Green : Colors.Red;
        public string Message => IsValid ? "Embarque válido" : "Error en validación";

        public ICommand ReturnCommand { get; }

        public ResultViewModel()
        {
            ReturnCommand = new Command(async () => await ReturnToScan());
        }

        private async Task ReturnToScan()
        {
            await Shell.Current.GoToAsync("//ScanPage");
        }
    }
}
