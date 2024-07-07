using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using MySqlX.XDevAPI.Relational;

namespace TallerFrankyUi
{
    public partial class FrmReparacion : Form
    {
        Taller tallerEnReparacion;  // Taller de barcos que se está reparando

        // Constructor del formulario que recibe un taller como parámetro
        public FrmReparacion(Taller taller)
        {
            InitializeComponent();
            this.tallerEnReparacion = taller;
        }

        // Método que se ejecuta al cargar el formulario
        private void FrmReparacion_Load(object sender, EventArgs e)
        {
            // Cargar la lista de barcos del taller en el ListBox al cargar el formulario
            lstTaller.DataSource = tallerEnReparacion.Barcos;
        }

        // Método que se ejecuta al hacer clic en el botón de reparar
        private void btnReparar_Click(object sender, EventArgs e)
        {
            // Preguntar al usuario si desea reparar todos los barcos del taller
            DialogResult reparar = MessageBox.Show("¿Desea reparar todos los barcos?", "Reparar barcos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (reparar == DialogResult.Yes)
            {
                // Llamar al método Reparar del taller y actualizar la lista de barcos en el ListBox
                tallerEnReparacion.Reparar(tallerEnReparacion);
                lstTaller.DataSource = null;
                lstTaller.DataSource = tallerEnReparacion.Barcos;
            }
        }
    }
}
