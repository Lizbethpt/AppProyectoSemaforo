using AppProyectoAppMovil.ViewModels;
using ZXing;
using System.Linq;

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
            if (e.Results.Count() > 0)
            {
                var code = e.Results[0].Value;
                if (!string.IsNullOrEmpty(code))
                {
                    barcodeReader.IsDetecting = false;

                    viewModel.ScanCommand.Execute(code); // Corrección aquí

                    await Task.Delay(2000);
                    barcodeReader.IsDetecting = true;
                }
            }
        }

    }
}
