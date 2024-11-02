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
using System.Configuration;
using System.Data.SqlClient;

namespace ResultadosEstudiantes
{
    public partial class MainWindow : Window
    {
        private string connectionString = "Data Source=YOUR_SERVER;Initial Catalog=UniversidadDB;Integrated Security=True"; // Cambia YOUR_SERVER por tu servidor SQL

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CargarEstudiantes()
        {
            List<Estudiante> estudiantes = new List<Estudiante>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT e.estudianteID, e.Apellido + ', ' + e.Nombre AS ApellidoNombre, e.DNI, e.Legajo, em.Asistencia, em.NotaFinal, em.Situacion FROM Estudiantes e JOIN EstudiantesMaterias em ON e.estudianteID = em.EstudianteID", connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    estudiantes.Add(new Estudiante
                    {
                        estudianteID = reader.GetInt32(0),
                        ApellidoNombre = reader.GetString(1),
                        DNI = reader.GetString(2),
                        Legajo = reader.IsDBNull(3) ? null : reader.GetString(3),
                        Asistencia = reader.IsDBNull(4) ? 0 : reader.GetInt32(4),
                        NotaFinal = reader.IsDBNull(5) ? 0 : reader.GetInt32(5),
                        Situacion = reader.GetString(6)
                    });
                }
            }

            dataGridEstudiantes.ItemsSource = estudiantes;
        }

        private void GuardarEstudiante(object sender, RoutedEventArgs e)
        {
            string apellidoNombre = txtApellidoNombre.Text;
            string dni = txtDNI.Text;
            string legajo = txtLegajo.Text;
            int asistencia = chkAsistencia.IsChecked == true ? 1 : 0;
            int notaFinal = 0; // Se puede calcular según los parciales y trabajos prácticos
            string situacion = "Aprobado"; // Establecer según la lógica

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Estudiantes (Apellido, Nombre, DNI, Legajo) OUTPUT INSERTED.estudianteID VALUES (@Apellido, @Nombre, @DNI, @Legajo)", connection);
                command.Parameters.AddWithValue("@Apellido", apellidoNombre.Split(',')[0].Trim());
                command.Parameters.AddWithValue("@Nombre", apellidoNombre.Split(',')[1].Trim());
                command.Parameters.AddWithValue("@DNI", dni);
                command.Parameters.AddWithValue("@Legajo", legajo ?? (object)DBNull.Value);

                int estudianteID = (int)command.ExecuteScalar();

                // Aquí puedes agregar lógica para la tabla EstudiantesMaterias si es necesario
                SqlCommand commandEm = new SqlCommand("INSERT INTO EstudiantesMaterias (EstudianteID, MateriaID, Situacion, Asistencia, NotaFinal) VALUES (@EstudianteID, @MateriaID, @Situacion, @Asistencia, @NotaFinal)", connection);
                commandEm.Parameters.AddWithValue("@EstudianteID", estudianteID);
                commandEm.Parameters.AddWithValue("@MateriaID", 1); // Cambia según la materia seleccionada
                commandEm.Parameters.AddWithValue("@Situacion", situacion);
                commandEm.Parameters.AddWithValue("@Asistencia", asistencia);
                commandEm.Parameters.AddWithValue("@NotaFinal", notaFinal);

                commandEm.ExecuteNonQuery();
            }

            CargarEstudiantes();
        }

        // Aquí podrías agregar métodos para editar y eliminar estudiantes

        // Ejemplo de cómo podrías implementar el método para editar un estudiante
        private void EditarEstudiante(int estudianteID)
        {
            // Lógica para editar el estudiante, similar a GuardarEstudiante
        }

        // Ejemplo de cómo podrías implementar el método para eliminar un estudiante
        private void EliminarEstudiante(int estudianteID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM Estudiantes WHERE estudianteID = @EstudianteID", connection);
                command.Parameters.AddWithValue("@EstudianteID", estudianteID);
                command.ExecuteNonQuery();
            }

            CargarEstudiantes();
        }
    }

    public class Estudiante
    {
        public int estudianteID { get; set; }
        public string ApellidoNombre { get; set; }
        public string DNI { get; set; }
        public string Legajo { get; set; }
        public int Asistencia { get; set; }
        public int NotaFinal { get; set; }
        public string Situacion { get; set; }
    }
}
