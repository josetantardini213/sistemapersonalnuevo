using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BE;

namespace DAL
{
    public class CategoriaDB
    {
        Conexion conexion = new Conexion();
        public List<Categoria> consultaCategorias()
        {
            try
            {
                List<Categoria> listaCategorias = new List<Categoria>();

                string sql = "SELECT * FROM categorias";

                SqlCommand cmd = new SqlCommand(sql, conexion.conectar());
                SqlDataReader dr = cmd.ExecuteReader();
                DataSet ds = new DataSet();
                
                while (dr.Read())
                {
                    Categoria cat = new Categoria();
                    cat.setId_categoria(Convert.ToInt32(dr["id_categoria"]));
                    cat.setNombre(dr["nombre"].ToString());
                    listaCategorias.Add(cat);

                }
        
                

                conexion.desconectar();

                //validar si el usuario existe
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
