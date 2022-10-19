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
    public partial class Form1 : Form
    {
        LoginBde gestor = new LoginBde();
        public Form1()
        {
            InitializeComponent();
            


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0)
            {
               bool validacion = gestor.login(textBox1.Text, textBox2.Text);

                if (validacion)
                {
                    this.Hide();

                    Home frm = new Home();

                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos");
                }
            }
            else
            {
                MessageBox.Show("Ingrese usuario y contraseña");
            }
        }
    }
}
