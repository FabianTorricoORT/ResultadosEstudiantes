using ResultadosEstudiantes.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ResultadosEstudiantes
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GuardarEstudiante(object sender, RoutedEventArgs e)
        {

            var materiaSeleccionada = (cmbMateria.SelectedItem as ComboBoxItem)?.Content.ToString();

            // COMENZAMOS CON LAS VALIDACION Y EXEPCIONES
            try
            {
                if (txtApellidoNombre.Text.Length > 50) //VALIDACION DEL NOMBRE COMPLETO
                {
                    MessageBox.Show("El apellido y nombre no puede exceder los 50 caracteres.", "Error de Validación", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return; 
                }

                long dni;
                if (!long.TryParse(txtDNI.Text, out dni) || txtDNI.Text.Length < 7 || txtDNI.Text.Length > 8) //VALIDACION DEL DNI(ARGENTINO)
                {
                    MessageBox.Show("El DNI debe ser un número de 7 a 8 dígitos.", "Error de Validación", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return; 
                }

                if (int.TryParse(txtParcial1.Text, out int parcial1) && (parcial1 < 1 || parcial1 > 10)) 
                {
                    MessageBox.Show("El Parcial 1 debe ser un número entre 1 y 10.", "Error de Validación", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return; 
                }
          
                if (int.TryParse(txtParcial2.Text, out int parcial2) && (parcial2 < 1 || parcial2 > 10))
                {
                    MessageBox.Show("El Parcial 2 debe ser un número entre 1 y 10.", "Error de Validación", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return; 
                }

                // CREA UN NUEVO ESTUDIANTE
                var estudiante = new Estudiante
                {
                    ApellidoNombre = txtApellidoNombre.Text,
                    DNI = dni,
                    Legajo = string.IsNullOrWhiteSpace(txtLegajo.Text) ? (long?)null : long.Parse(txtLegajo.Text),
                    Asistencia = chkAsistencia.IsChecked ?? false,
                    TP1Entregado = cmbTP1.SelectedItem is ComboBoxItem tp1 && tp1.Content.ToString() == "Entregado",
                    TP2Entregado = cmbTP2.SelectedItem is ComboBoxItem tp2 && tp2.Content.ToString() == "Entregado",
                    TP3Entregado = cmbTP3.SelectedItem is ComboBoxItem tp3 && tp3.Content.ToString() == "Entregado",
                    TP4Entregado = cmbTP4.SelectedItem is ComboBoxItem tp4 && tp4.Content.ToString() == "Entregado",
                    Parcial1 = parcial1, 
                    Parcial2 = parcial2  
                };

                
                estudiante.CalcularResultados();

                // MOSTRAR DATOS POR PANTALLA
                MessageBox.Show(
                   $"Nombre: {estudiante.ApellidoNombre}\nDNI: {estudiante.DNI}\nLegajo: {(string.IsNullOrWhiteSpace(estudiante.Legajo.ToString()) ? "No posee" : estudiante.Legajo.ToString())}\n" +
                   $"Asistencia: {estudiante.Asistencia}\nTP1: {(estudiante.TP1Entregado ? "Entregado" : "No Entregado")}\n" +
                   $"TP2: {(estudiante.TP2Entregado ? "Entregado" : "No Entregado")}\nTP3: {(estudiante.TP3Entregado ? "Entregado" : "No Entregado")}\n" +
                   $"TP4: {(estudiante.TP4Entregado ? "Entregado" : "No Entregado")}\nParcial 1: {estudiante.Parcial1}\n" +
                   $"Parcial 2: {estudiante.Parcial2}\nMateria: {materiaSeleccionada}\nSituación de la Materia: {estudiante.SituacionMateria}\nNota Final: {estudiante.NotaFinal:F2}"
);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error de Validación", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void chkAsistencia_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
