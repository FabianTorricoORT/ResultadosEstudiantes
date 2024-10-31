using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultadosEstudiantes.Clases
{
    internal class Materias
    {
        public class Materia
        {
            public string Nombre { get; set; }


            public List<Estudiante> Estudiantes { get; private set; }

            public Materia(string nombre)
            {
                Nombre = nombre;

                Estudiantes = new List<Estudiante>();
            }

            public void AgregarEstudiante(Estudiante estudiante)
            {
                if (estudiante != null && !Estudiantes.Contains(estudiante))
                {
                    Estudiantes.Add(estudiante);
                }
            }

            public void RemoverEstudiante(Estudiante estudiante)
            {
                if (estudiante != null && Estudiantes.Contains(estudiante))
                {
                    Estudiantes.Remove(estudiante);
                }
            }

            public void CalcularResultadosDeEstudiantes()
            {
                foreach (var estudiante in Estudiantes)
                {
                    estudiante.CalcularResultados();
                }
            }

            public List<Estudiante> ObtenerResultados()
            {
                return Estudiantes;
            }

            // Método para crear y retornar una lista de materias predefinidas
            public static List<Materia> CrearMateriasPredefinidas()
            {
                return new List<Materia>
            {
                new Materia("Programacion I"),
                new Materia("Programacion II"),
                new Materia("Base de Datos"),
                new Materia("Arquitectura y Sistemas Informaticos"),
                new Materia("Ingles I"),
                new Materia("Matematica"),
                new Materia("Organizacion Empresarial")
            };
            }
        }
    }
}

