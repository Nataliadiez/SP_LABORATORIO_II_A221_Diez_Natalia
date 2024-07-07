using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TallerFrankyUi
{
    public partial class FrmBarco : Form
    {
        Barco barcoNuevo;

        public Barco BarcoNuevo
        {
            get => this.barcoNuevo;
            set => this.barcoNuevo = value;
        }

        public FrmBarco()
        {
            InitializeComponent();
            cmbTipo.Items.Add(ETipoBarco.Pirata);
            cmbTipo.Items.Add(ETipoBarco.Marina);
            foreach (Entidades.EOperacion operacionEnum in Enum.GetValues(typeof(Entidades.EOperacion)))
            {
                cmbOperacion.Items.Add(operacionEnum);
            }
        }

        private void FrmVehiculo_Load(object sender, EventArgs e)
        {
            cmbTipo.SelectedIndex = 0;
            cmbOperacion.SelectedIndex = 0;
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            //TODO:Validar si el barco es pirata o marina y lo instancio
            // retornar DialogResult OK y cerrar el formulario
            try
            {
                this.barcoNuevo = null;
                string nombre = txtNombre.Text; //Validar que el nombre no esté vacío
                string tipo = cmbTipo.Text;
                string operacion = cmbOperacion.Text;
                Enum.TryParse(operacion, out Entidades.EOperacion operacionEnum);
                if (tipo == "Pirata")
                {
                    this.barcoNuevo = new Pirata(0, false, nombre, operacionEnum, 5);
                }
                else if (tipo == "Marina")
                {
                    this.barcoNuevo = new Marina(0, false, nombre, operacionEnum, 5);
                }

                this.DialogResult = DialogResult.OK;
            }
            catch(Exception ex)
            {
                MessageBox.Show("El barco no fue agregado." + ex.Message);
            }
            
        }

    }
}
