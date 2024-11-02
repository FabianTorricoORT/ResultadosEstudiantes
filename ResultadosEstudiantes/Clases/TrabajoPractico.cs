using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultadosEstudiantes.Clases
{
    public class TrabajoPractico
    {
        public int TrabajoPracticoID { get; set; }
        public int EstudianteMateriaID { get; set; }
        public int NumeroTP { get; set; }
        public DateTime Fecha { get; set; }
    }

}
