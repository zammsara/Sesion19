using RegistroPacientes.forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistroPacientes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            //ocultar form actual
            this.Hide();
            Registro frm = new Registro();
            frm.ShowDialog();

            frm = null;
            this.Show();
        }
    }
}
