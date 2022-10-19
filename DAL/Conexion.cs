using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class Conexion
    {

        public SqlConnection con;
        public SqlConnection conectar()
        {
            con = new SqlConnection("SERVER=JOSE;DATABASE=productos;Integrated security=true");
            con.Open();
            
          
            return con;
        }

        public SqlConnection desconectar()
        {
            con.Close();
            return con;
        }
    }
}
