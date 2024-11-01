using RegistroPacientes.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistroPacientes.forms
{
    public partial class Registro : Form
    {
        //iniciarlizar lista donde se guardara la info de los pacientes
        private List<Paciente> pacientesRegistrados = new List<Paciente>();
        public Registro()
        {
            InitializeComponent();

            //desactivar el tb de alergias
            tbAlergias.Enabled = false;

            //agregar elementos al cmb de selección del departamento médico
            cmbDepartamentoMed.Items.Add("Cardiología");
            cmbDepartamentoMed.Items.Add("Dermatología");
            cmbDepartamentoMed.Items.Add("Medicina Interna");
            cmbDepartamentoMed.Items.Add("Neurología");
            cmbDepartamentoMed.Items.Add("Ortopedia y Traumatología");
            cmbDepartamentoMed.Items.Add("Pediatría");
            cmbDepartamentoMed.Items.Add("Psiquiatría");
            cmbDepartamentoMed.Items.Add("Rehabilitación y Fisioterapia");
            cmbDepartamentoMed.Items.Add("Urgencias");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //recoger info
            string nombre = tbNombre.Text;
            string apellido = tbApellido.Text;
            DateTime fechaNacimiento = dtpFechaNac.Value;
            string genero = tbGenero.Text;
            bool siAlergias = chkSi.Checked;
            bool noAlergias = chkNo.Checked;
            string alergias = tbAlergias.Text;

            //obtener la info del cmb
            string sdepartamentoMedico = cmbDepartamentoMed.SelectedItem?.ToString();

            //validar que los tb no esten vacios
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) || string.IsNullOrEmpty(genero))
            {
                MessageBox.Show("Por favor, completa todos los campos obligatorios.");
                return;
            }

            //validar que se haya selecionado un departamento medico
            if (string.IsNullOrEmpty(sdepartamentoMedico))
            {
                MessageBox.Show("Por favor, selecciona un departamento médico.");
                return;
            }

            // validar si hay alergias seleccionadas
            if (siAlergias && string.IsNullOrWhiteSpace(alergias))
            {
                MessageBox.Show("Por favor, indique las alergias si ha seleccionado que tiene.");
                return;
            }

            //se crea un nuevo paciente
            Paciente nuevoPaciente = new Paciente
            {
                Nombre = nombre,
                Apellido = apellido,
                FechaNacimiento = fechaNacimiento,
                DepartamentoMed = sdepartamentoMedico,
                Genero = genero,
                SiAlergias = siAlergias,
                //en la siguiente línea, se hace uso de un operador ternario (más info buscar en "Varios")
                Alergias = siAlergias ? alergias : string.Empty // guardar alergias solo si aplica
                                                                //condicion,  valor a   , valor a mostrar 
                                                                //mostrar si     si falso
                                                                //Verdadero
            };

            //agregar el nuevo paciente a la lista
            pacientesRegistrados.Add(nuevoPaciente);

            MessageBox.Show("Paciente registrado exitosamente.");

        }

        private void btnGuardar_KeyPress(object sender, KeyPressEventArgs e)
        { }

        //-----------------------keypress para no permitir números---------------------------------------------------------------------------------
        private void tbNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo se permiten letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void tbApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo se permiten letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void tbGenero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo se permiten letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        //ignorar
        private void tbAlergias_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        //-----------------------------------------------------------------------------------------------------------------------------------

        private void chkSi_CheckedChanged(object sender, EventArgs e)
        {
            //se activará el tb de alergias si "Si" está marcado
            tbAlergias.Enabled = chkSi.Checked;
            if (!chkSi.Checked)
            {
                tbAlergias.Clear(); //limpiar el tb si se desmarca
            }
        }

        private void chkNo_CheckedChanged(object sender, EventArgs e)
        {
            //se desmarcará el chk "Sí" si "No" está marcado
            if (chkNo.Checked)
            {
                chkSi.Checked = false;
                tbAlergias.Enabled = false; //deshabilitar el tb de alergias
                tbAlergias.Clear(); //limpiar el TextBox
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LimpiarCampos()
        {
            //limpiar los tb
            tbNombre.Clear();
            tbApellido.Clear();
            tbGenero.Clear();

            //limpiar el cmb de departamento médico
            cmbDepartamentoMed.SelectedIndex = -1; //desmarcar la selección actual

            //limpiar el dtp de la fechaNac
            dtpFechaNac.Value = DateTime.Now; //se retablecerá a la fecha actual...

            //demarcar los chk
            chkSi.Checked = false;
            chkNo.Checked = false;

            //limpiar el tb de alergias (si aplica)
            tbAlergias.Clear();
            tbAlergias.Enabled = false; //se deshabilitará el tb de alergias al limpiar
        }
    }
}
