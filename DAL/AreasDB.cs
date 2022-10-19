using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BE;
namespace DAL
{
    public class AreasDB
    {
        Conexion conexion = new Conexion();
        public List<Area> consultaAreas()
        {
            try
            {
                List<Area> listaareas = new List<Area>();
                
                string sql = "SELECT * FROM areas";

                SqlCommand cmd = new SqlCommand(sql, conexion.conectar());
                SqlDataReader dr = cmd.ExecuteReader();
                
                while (dr.Read())
                {
                    Area cat = new Area();
                    cat.setIdarea(Convert.ToInt32(dr["id_areas"]));
                    cat.setNombre(dr["nombre"].ToString());
                    listaareas.Add(cat);

                }

                conexion.desconectar();

                //validar si el usuario existe
                return listaareas;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
