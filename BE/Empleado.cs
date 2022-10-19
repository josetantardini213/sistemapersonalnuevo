using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
namespace BE
{
    public class Empleado
    {
        public int empleado_id { get; set; }

        public string nombre { get; set; }

        public string apellido { get; set; }

        public int edad { get; set; }

        public long dni { get; set; }

        public long sueldo { get; set; }

        public Categoria categoria { get; set; }

        public Profesion profesion { get; set; }

        public Area area { get; set; }

        public string supervisor { get; set; }

        //to string
        public override string ToString()
        {
            return "Empleado: " + empleado_id + " " + nombre + " " + apellido + " " + edad + " " + dni + " " + sueldo + " " + categoria + " " + profesion + " " + area + " " + supervisor;
        }
    }
}
