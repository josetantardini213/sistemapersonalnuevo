using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;
namespace BDE
{
    public class EmpleadoBde
    {
        public List<Empleado> consultaEmpleados()
        {
            try
            {
                EmpleadosDB empleadosDB = new EmpleadosDB();
                List<Empleado> listaEmpleados = empleadosDB.findAll();
                return listaEmpleados;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public void save(Empleado empleado)
        {
            try
            {
                EmpleadosDB empleadosDB = new EmpleadosDB();
                empleadosDB.save(empleado);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void delete(Empleado empleado)
        {
            try
            {
                EmpleadosDB empleadosDB = new EmpleadosDB();
                empleadosDB.delete(empleado);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

    }
}
