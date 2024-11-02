using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultadosEstudiantes.Clases
{
    public class EstudianteMateria
    {
        public int EstudianteMateriaID { get; set; }
        public int EstudianteID { get; set; }
        public int MateriaID { get; set; }
        public string Situacion { get; set; }
        public int Asistencia { get; set; }
        public int? NotaFinal { get; set; } // Puede ser null
    }

}
