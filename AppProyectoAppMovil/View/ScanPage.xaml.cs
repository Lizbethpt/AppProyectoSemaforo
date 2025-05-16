using AppProyectoAppMovil.ViewModels;
using ZXing;

namespace AppProyectoAppMovil.Views
{
    public partial class ScanPage : ContentPage
    {
        private ScanViewModel viewModel;

        public ScanPage()
        {
            InitializeComponent();
            viewModel = BindingContext as ScanViewModel;
        }

        private async void barcodeReader_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
        {
            if (e.Results.Count > 0)
            {
                var code = e.Results[0].Value;
                if (!string.IsNullOrEmpty(code))
                {
                    // Espera unos milisegundos para evitar múltiples lecturas del mismo código
                    barcodeReader.IsDetecting = false;

                    await viewModel.ScanCommand.ExecuteAsync(code);

                    // Vuelve a activar el lector después de un pequeño delay
                    await Task.Delay(2000);
                    barcodeReader.IsDetecting = true;
                }
            }
        }
    }
}
