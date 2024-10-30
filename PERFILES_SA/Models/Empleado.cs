using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PERFILES_SA.Models
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }
        public string Nombres { get; set; }
        public string DPI { get; set; }

        public DateTime FechaNacimiento { get; set; }
        public Char Genero { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int Edad { get; set; }
        public string Direccion { get; set; }
        public string NIT { get; set; }
        public Departamento Departamento { get; set; }
 
    }
}