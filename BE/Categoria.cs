using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Categoria
    {
        public int id_categoria { get; set; }
        public string nombre { get; set; }

        public void setId_categoria(int id)
        {
            id_categoria = id;
        }

        public int getid_categoria()
        {
            return id_categoria;
        }

        public void setNombre(String nom)
        {
            nombre = nom;
        }

        public String getNombre()
        {
            return nombre;
        }
        /*override
          public string ToString()
        {
            return nombre;
        }
        */

        //to string
        public override string ToString()
        {
            return nombre;
        }

    }
}
