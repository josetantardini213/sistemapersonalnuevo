using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Profesion
    {
        //constructor



        public int id_profesion { get; set; }
        public string nombre { get; set; }

        public void setId_profesion(int id)
        {
            id_profesion = id;
        }

        public int getId_profesion()
        {
            return id_profesion;
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
