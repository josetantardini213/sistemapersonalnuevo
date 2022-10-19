using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;
namespace BDE
{
    public class ProfesionesBde
    {
        public List<Profesion> consultaProfesiones()
        {
            try
            {
                ProfesioneDB profesiondb = new ProfesioneDB();
                List<Profesion> listaprofesiones = profesiondb.consultaProfesiones();


                return listaprofesiones;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

    }
}
