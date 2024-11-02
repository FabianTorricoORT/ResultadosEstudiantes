using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultadosEstudiantes.Clases
{
    public class Estudiante
    {
        public int EstudianteID { get; set; }
        public string ApellidoNombre { get; set; }
        public string DNI { get; set; }
        public string Legajo { get; set; }
        public bool Asistencia { get; set; }
        public int? NotaFinal { get; set; }
    }

}
