using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using TallerFrankyUi;

namespace Parcial.WindowsForm
{
    /// <summary>
    /// Formulario para mostrar, modificar y eliminar barcos.
    /// </summary>
    public partial class FrmMostrar : Form
    {
        List<Barco> listaDeBarcos;
        int indiceRegistro;

        /// <summary>
        /// Constructor del formulario.
        /// </summary>
        public FrmMostrar()
        {
            InitializeComponent();
            listaDeBarcos = AccesoDatos.SeleccionarBarcos();
        }

        /// <summary>
        /// Método que se ejecuta al cargar el formulario.
        /// </summary>
        private void FrmMostrar_Load(object sender, EventArgs e)
        {
            dgMostrarBarcos.DataSource = listaDeBarcos;
        }

        /// <summary>
        /// Método que se ejecuta al hacer clic en el botón de modificar.
        /// </summary>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            // Crear y mostrar el formulario FrmBarco para modificar el barco seleccionado
            FrmBarco frmBarco = new FrmBarco(indiceRegistro);
            frmBarco.ShowDialog();

            // Actualizar la lista de barcos y el DataGridView después de la modificación
            listaDeBarcos = AccesoDatos.SeleccionarBarcos();
            dgMostrarBarcos.DataSource = listaDeBarcos;
        }

        /// <summary>
        /// Método que se ejecuta al cambiar la selección en el DataGridView.
        /// </summary>
        private void dgMostrarBarcos_SelectionChanged(object sender, EventArgs e)
        {
            this.indiceRegistro = dgMostrarBarcos.CurrentRow.Index;
        }

        /// <summary>
        /// Método que se ejecuta al hacer clic en el botón de eliminar.
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Confirmar la eliminación del registro seleccionado
            DialogResult eliminarRegistro = MessageBox.Show("¿Está seguro de que desea eliminar el registro?",
                "Eliminar registro de la base de datos", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

            if (eliminarRegistro == DialogResult.Yes)
            {
                // Obtener el nombre del barco seleccionado y eliminarlo de la base de datos
                string nombreBarco = this.listaDeBarcos[this.indiceRegistro].Nombre;
                AccesoDatos.EliminarBarco(nombreBarco);

                // Mostrar mensaje de éxito y actualizar la lista de barcos y el DataGridView
                MessageBox.Show("Barco eliminado exitosamente!\n" + listaDeBarcos[indiceRegistro].ToString());
                listaDeBarcos = AccesoDatos.SeleccionarBarcos();
                dgMostrarBarcos.DataSource = listaDeBarcos;
            }
        }
    }
}
