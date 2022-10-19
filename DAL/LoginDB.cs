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
    public class LoginDB
    {
        Conexion conexion = new Conexion();
        public Usuario consultaUsuario(string usuario)
        {
            try
            {
               
                Usuario _usuario = new Usuario();
                string sql = "SELECT * FROM usuarios WHERE usuario = @usuario";

                SqlCommand cmd = new SqlCommand(sql, conexion.conectar());
                cmd.Parameters.AddWithValue("@usuario", usuario);
                SqlDataReader dr = cmd.ExecuteReader();
                

                if (dr.Read())
                {
                    _usuario.usuario = dr["usuario"].ToString();
                    _usuario.contrasena = dr["contrasena"].ToString();
                    _usuario.id = Convert.ToInt32(dr["id"]);
                }
                else
                {
                    _usuario = null;
                }


                conexion.desconectar();

                //validar si el usuario existe

                if (_usuario.usuario == null)
                {
                    return null;
                }
                else
                {
                    return _usuario;
                }
                
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        //consultar usuario 2
     
    }
}
