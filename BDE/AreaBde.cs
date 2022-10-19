using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;
namespace BDE
{
    public class AreaBde
    {
        public List<Area> consultaAreas()
        {
            try
            {
                AreasDB areasDB = new AreasDB();
                List<Area> listaareas = areasDB.consultaAreas();
                

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
