using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Area
    {
        //constructor

        public Area()
        {

        }


        public int id_area { get; set; }
        public string nombre { get; set; }

        public void setIdarea(int id)
        {
            id_area = id;
        }

        public int getId_area()
        {
            return id_area;
        }

        public void setNombre(String nom)
        {
            nombre = nom;
        }

        public String getNombre()
        {
            return nombre;
        }

        //to string
        public override string ToString()
        {
            return nombre;
        }
    }
}
