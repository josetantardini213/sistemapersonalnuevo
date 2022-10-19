using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;
namespace BDE
{
    public class CategoriaBde
    {

        public List<Categoria> consultaCategorias()
        {
            try
            {
                CategoriaDB categoriaDB = new CategoriaDB();
                List<Categoria> listaCategorias = categoriaDB.consultaCategorias();

            
                return listaCategorias;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

    }
}
