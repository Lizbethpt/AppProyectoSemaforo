using AppProyectoAppMovil.Services;
namespace AppProyectoAppMovil
{
    public partial class App : Application
    {
        public App(DatabaseService dbService)

        {
            InitializeComponent();

            // El Shell es ahora tu página principal
            MainPage = new AppShell();

            Task.Run(async () => await dbService.Init()).Wait();
        }
    }
}