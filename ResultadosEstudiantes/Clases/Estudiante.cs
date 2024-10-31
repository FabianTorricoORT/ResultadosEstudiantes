using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultadosEstudiantes.Clases
{
    public class Estudiante
    {
        //hola 
        public string ApellidoNombre { get; set; }
        public long DNI { get; set; }
        public long? Legajo { get; set; }
        public bool Asistencia { get; set; }
        public bool TP1Entregado { get; set; }
        public bool TP2Entregado { get; set; }
        public bool TP3Entregado { get; set; }
        public bool TP4Entregado { get; set; }
        public int Parcial1 { get; set; }
        public int Parcial2 { get; set; }
        public double NotaFinal { get; set; }
        public string SituacionMateria { get; set; }
        public string Materia { get; set; }

        public void CalcularResultados()
        {
 
            if (Parcial1 < 4 || Parcial2 < 4)
            {
                SituacionMateria = "Recursa la materia";
                NotaFinal = 0; 
                return;
            }


            if (!Asistencia) 
            {
                SituacionMateria = "Recursa la materia"; 
                NotaFinal = 0; 
                return;
            }

          
            if (!TP1Entregado || !TP2Entregado || !TP3Entregado || !TP4Entregado)
            {
                SituacionMateria = "Rinde final"; 
                NotaFinal = 0; 
                return;
            }

        
            NotaFinal = (Parcial1 + Parcial2) / 2.0;

       
            if (NotaFinal < 4)
            {
                SituacionMateria = "Recursa la materia";
            }
            else if (NotaFinal >= 4 && NotaFinal <= 5)
            {
                SituacionMateria = "Rinde final";
            }
            else
            {
                SituacionMateria = "Promociona";
            }
        }

    }
    
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


