using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BE;
namespace DAL
{
    public class ProfesioneDB
    {
        Conexion conexion = new Conexion();

        public List<Profesion> consultaProfesiones()
        {
            try
            {
                List<Profesion> listaProfesiones = new List<Profesion>();

                string sql = "SELECT * FROM profesiones";

                SqlCommand cmd = new SqlCommand(sql, conexion.conectar());
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Profesion cat = new Profesion();
                    cat.setId_profesion(Convert.ToInt32(dr["id_profesion"]));
                    cat.setNombre(dr["nombre"].ToString());
                    listaProfesiones.Add(cat);

                }

                conexion.desconectar();

                //validar si el usuario existe
                return listaProfesiones;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
