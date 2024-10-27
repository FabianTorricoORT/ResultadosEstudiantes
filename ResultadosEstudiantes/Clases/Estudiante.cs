using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultadosEstudiantes.Clases
{
    public class Estudiante
    {

    // hola que hace 
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

}
