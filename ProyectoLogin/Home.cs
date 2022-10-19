using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BDE;
namespace ProyectoLogin
{
    public partial class Home : Form
    {
        CategoriaBde categoriaBDE = new CategoriaBde();
        AreaBde area = new AreaBde();
        ProfesionesBde profesionesBde = new ProfesionesBde();
        public Home()
        {
            InitializeComponent();
         

            //LLAMAR CONSULTA DE CATEGORIAS Y INSERTARLO EN EL COMBO
            List<Categoria> listaCategorias = categoriaBDE.consultaCategorias();
            //manejando getter and setter de la clase categoria
            cmbCategoria.DataSource = listaCategorias;
            cmbCategoria.DisplayMember = "nombre";
            cmbCategoria.ValueMember = "id_categoria";

            List<Area> listaareas = area.consultaAreas();
            //manejando getter and setter de la clase categoria
            cmbArea.DataSource = listaareas;
            cmbArea.DisplayMember = "nombre";
            cmbArea.ValueMember = "id_area";

            List<Profesion> listaprofesiones = profesionesBde.consultaProfesiones();
            //manejando getter and setter de la clase categoria
            cmbProfesion.DataSource = listaprofesiones;
            cmbProfesion.DisplayMember = "nombre";
            cmbProfesion.ValueMember = "id_profesion";

            EmpleadoBde empleadoBde = new EmpleadoBde();
            dataGridView1.DataSource = empleadoBde.consultaEmpleados();
            

        }

        private void btnCargaTotal_Click(object sender, EventArgs e)
        {
            Categoria cat = (Categoria)cmbCategoria.SelectedItem;
            Profesion profe = (Profesion)cmbProfesion.SelectedItem;
            Area area = (Area)cmbArea.SelectedItem;

            Empleado emple = new Empleado();
            //validar que los campos no esten vacios
            if (txtNombre.Text == "" || txtApellido.Text == "" || txtEdad.Text == "" || txtDni.Text == "" || txtSueldo.Text == "")
            {
                MessageBox.Show("Debe completar todos los campos");
            }
            else
            {
                EmpleadoBde empleadoBde = new EmpleadoBde();

                emple.nombre = txtNombre.Text;
                emple.apellido = txtApellido.Text;
                emple.edad = Convert.ToInt32(txtEdad.Text);
                emple.dni = Convert.ToInt32(txtDni.Text);
                emple.sueldo = Convert.ToInt32(txtSueldo.Text);
                emple.categoria = cat;
                emple.profesion = profe;
                emple.area = area;
                emple.supervisor = txtSupervisor.Text;
                

                empleadoBde.save(emple);
                dataGridView1.DataSource = empleadoBde.consultaEmpleados();
                MessageBox.Show("Empleado cargado con exito");

            }


        }

        private void cmbCategoria_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void cmbProfesion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //al seleccionar una fila del datagridview, se cargan los datos en los textbox
            txtNombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtApellido.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtEdad.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtDni.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtSueldo.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtSupervisor.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            cmbCategoria.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            cmbProfesion.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            cmbArea.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //eliminar item seleccionado
            EmpleadoBde empleadoBde = new EmpleadoBde();
            Empleado emplead = new Empleado();
            emplead.empleado_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            empleadoBde.delete(emplead);
            dataGridView1.DataSource = empleadoBde.consultaEmpleados();
            MessageBox.Show("Empleado eliminado con exito");
        }
    }
}
