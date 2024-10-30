using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PERFILES_SA.Models
{
    public class Departamento
    {
        public int IdDepartamento { get; set; }

        public string Nombre { get; set; }

        public bool Estado { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}