using Microsoft.Maui.Controls;

namespace AppProyectoAppMovil.Views
{
    [QueryProperty(nameof(IsValid), "isValid")]
    public partial class ResultPage : ContentPage
    {
        private string _isValid;
        public string IsValid
        {
            get => _isValid;
            set
            {
                _isValid = value;
                MostrarResultado();
            }
        }

        public ResultPage()
        {
            InitializeComponent();
        }

        private void MostrarResultado()
        {
            bool resultado = bool.TryParse(IsValid, out bool isValidBool) && isValidBool;

            resultadoLabel.Text = resultado
                ? "Embarque validado correctamente ✅"
                : "Faltan artículos por escanear ❌";
        }
    }
}
