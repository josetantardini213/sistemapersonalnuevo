using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BE;
using System.Data;

namespace DAL
{
    public class EmpleadosDB
    {
        Conexion conexion = new Conexion();


        

        public void save(Empleado empleado)
        {
            try
            {
                string sql = "INSERT INTO empleados (nombre, apellido, edad, dni, sueldo, id_categoria, id_profesion, id_areas, supervisor) VALUES (@nombre, @apellido, @edad, @dni, @sueldo, @id_categoria, @id_profesion, @id_areas, @supervisor)";

                SqlCommand cmd = new SqlCommand(sql, conexion.conectar());
                cmd.Parameters.AddWithValue("@nombre", empleado.nombre);
                cmd.Parameters.AddWithValue("@apellido", empleado.apellido);
                cmd.Parameters.AddWithValue("@edad", empleado.edad);
                cmd.Parameters.AddWithValue("@dni", empleado.dni);
                cmd.Parameters.AddWithValue("@sueldo", empleado.sueldo);
                cmd.Parameters.AddWithValue("@id_categoria", empleado.categoria.getid_categoria());
                cmd.Parameters.AddWithValue("@id_profesion", empleado.profesion.getId_profesion());
                cmd.Parameters.AddWithValue("@id_areas", empleado.area.getId_area());
                cmd.Parameters.AddWithValue("@supervisor", empleado.supervisor);
                cmd.ExecuteNonQuery();
               
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
                string sql = "DELETE FROM empleados WHERE empleado_id = @empleado_id";

                SqlCommand cmd = new SqlCommand(sql, conexion.conectar());
                cmd.Parameters.AddWithValue("@empleado_id", empleado.empleado_id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        
        public List<Empleado> findAll()
        {
            try
            {
                //consultar DATOS A UNA VISTA

                String sql = "SELECT e.empleado_id,e.nombre,e.apellido,e.dni,e.edad,e.sueldo,e.supervisor,c.id_categoria,c.nombre as nombre_cat,p.id_profesion,p.nombre as nombre_prof,a.id_areas,a.nombre AS nombre_are FROM empleados AS e INNER JOIN categorias AS c ON e.id_categoria = c.id_categoria INNER JOIN profesiones AS p ON e.id_profesion = p.id_profesion INNER JOIN areas AS a ON e.id_areas = a.id_areas";
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand(sql, conexion.conectar());
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);

                List<Empleado> empleados = new List<Empleado>();

                foreach (DataRow row in dt.Rows)
                {
                    Empleado empleado = new Empleado();
                    empleado.empleado_id = Convert.ToInt32(row["empleado_id"]);
                    empleado.nombre = row["nombre"].ToString();
                    empleado.apellido = row["apellido"].ToString();
                    empleado.edad = Convert.ToInt32(row["edad"]);
                    empleado.dni = Convert.ToInt64(row["dni"]);
                    empleado.sueldo = Convert.ToInt64(row["sueldo"]);
                    empleado.supervisor = row["supervisor"].ToString();
                    Categoria categoria = new Categoria();
                    categoria.setId_categoria(Convert.ToInt32(row["id_categoria"]));
                    categoria.setNombre(row["nombre_cat"].ToString());
                    Profesion profesion = new Profesion();
                    profesion.setId_profesion(Convert.ToInt32(row["id_profesion"]));
                    profesion.setNombre(row["nombre_prof"].ToString());
                    Area area = new Area();
                    area.setIdarea(Convert.ToInt32(row["id_areas"]));
                    area.setNombre(row["nombre_are"].ToString());
                    empleado.profesion = profesion;
                    empleado.categoria = categoria;
                    empleado.area = area;

                    empleados.Add(empleado);
                }
                
                return empleados;

            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        

    }
}
