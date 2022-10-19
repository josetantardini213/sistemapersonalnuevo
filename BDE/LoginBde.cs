using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;
namespace BDE
{
    public class LoginBde
    {
        public bool login(string usuario, string contrasena)
        {
            try
            {
                LoginDB loginDB = new LoginDB();
                Usuario usu = loginDB.consultaUsuario(usuario);
                
                if (usu != null)
                {
                    if (usu.contrasena == contrasena)
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }

                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
  