using System.Windows;

namespace ResultadosEstudiantes
{
    public partial class VentanaBienvenida : Window
    {
        public VentanaBienvenida()
        {
            InitializeComponent();
        }

        private void Iniciar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close(); 
        }
    }
}
