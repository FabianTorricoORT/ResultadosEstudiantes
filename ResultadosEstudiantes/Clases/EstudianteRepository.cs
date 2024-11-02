using ResultadosEstudiantes.Clases;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

public class EstudianteRepository
{
    private string connectionString;

    public EstudianteRepository(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public List<Estudiante> GetAllEstudiantes()
    {
        var estudiantes = new List<Estudiante>();

        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            var command = new SqlCommand("SELECT * FROM Estudiantes", connection);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    estudiantes.Add(new Estudiante
                    {
                        EstudianteID = reader.GetInt32(0),
                        ApellidoNombre = reader.GetString(1),
                        DNI = reader.GetString(2),
                        Legajo = reader.IsDBNull(3) ? null : reader.GetString(3)
                    });
                }
            }
        }
        return estudiantes;
    }

    public void AddEstudiante(Estudiante estudiante)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            var command = new SqlCommand("INSERT INTO Estudiantes (Apellido, Nombre, DNI, Legajo) VALUES (@Apellido, @Nombre, @DNI, @Legajo)", connection);
            command.Parameters.AddWithValue("@Apellido", estudiante.ApellidoNombre.Split(' ')[0]);
            command.Parameters.AddWithValue("@Nombre", estudiante.ApellidoNombre.Split(' ')[1]);
            command.Parameters.AddWithValue("@DNI", estudiante.DNI);
            command.Parameters.AddWithValue("@Legajo", (object)estudiante.Legajo ?? DBNull.Value);
            command.ExecuteNonQuery();
        }
    }

    public void UpdateEstudiante(Estudiante estudiante)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            var command = new SqlCommand("UPDATE Estudiantes SET Apellido = @Apellido, Nombre = @Nombre, DNI = @DNI, Legajo = @Legajo WHERE EstudianteID = @EstudianteID", connection);
            command.Parameters.AddWithValue("@Apellido", estudiante.ApellidoNombre.Split(' ')[0]);
            command.Parameters.AddWithValue("@Nombre", estudiante.ApellidoNombre.Split(' ')[1]);
            command.Parameters.AddWithValue("@DNI", estudiante.DNI);
            command.Parameters.AddWithValue("@Legajo", (object)estudiante.Legajo ?? DBNull.Value);
            command.Parameters.AddWithValue("@EstudianteID", estudiante.EstudianteID);
            command.ExecuteNonQuery();
        }
    }

    public void DeleteEstudiante(int id)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            var command = new SqlCommand("DELETE FROM Estudiantes WHERE EstudianteID = @EstudianteID", connection);
            command.Parameters.AddWithValue("@EstudianteID", id);
            command.ExecuteNonQuery();
        }
    }
}
