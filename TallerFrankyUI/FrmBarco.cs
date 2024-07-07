using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TallerFrankyUi
{
    /// <summary>
    /// Formulario para agregar o modificar barcos.
    /// </summary>
    public partial class FrmBarco : Form
    {
        Barco barcoNuevo;
        int indiceRegistroAModificar;
        List<Barco> listaDeBarcosDB;
        Barco barcoAModificar;

        /// <summary>
        /// Propiedad que obtiene o establece el barco nuevo.
        /// </summary>
        public Barco BarcoNuevo
        {
            get => this.barcoNuevo;
            set => this.barcoNuevo = value;
        }

        /// <summary>
        /// Propiedad que obtiene o establece el barco a modificar.
        /// </summary>
        public Barco BarcoAModificar
        {
            get => this.barcoAModificar;
            set => this.barcoAModificar = value;
        }

        /// <summary>
        /// Propiedad que obtiene el índice del registro a modificar.
        /// </summary>
        public int IndiceRegistroAModificar
        {
            get => this.indiceRegistroAModificar;
        }

        /// <summary>
        /// Constructor por defecto del formulario.
        /// </summary>
        public FrmBarco()
        {
            InitializeComponent();
            cmbTipo.Items.Add(ETipoBarco.Pirata);
            cmbTipo.Items.Add(ETipoBarco.Marina);
            foreach (Entidades.EOperacion operacionEnum in Enum.GetValues(typeof(Entidades.EOperacion)))
            {
                cmbOperacion.Items.Add(operacionEnum);
            }
            this.indiceRegistroAModificar = -5;
            listaDeBarcosDB = AccesoDatos.SeleccionarBarcos();
        }

        /// <summary>
        /// Constructor del formulario que recibe un índice de registro a modificar.
        /// </summary>
        /// <param name="indiceRegistro">Índice del registro a modificar.</param>
        public FrmBarco(int indiceRegistro) : this()
        {
            this.indiceRegistroAModificar = indiceRegistro;
        }

        /// <summary>
        /// Método que se ejecuta al cargar el formulario.
        /// </summary>
        private void FrmVehiculo_Load(object sender, EventArgs e)
        {
            cmbTipo.SelectedIndex = 0;
            cmbOperacion.SelectedIndex = 0;
            if (this.indiceRegistroAModificar != -5)
            {
                barcoAModificar = this.listaDeBarcosDB[indiceRegistroAModificar];
                txtNombre.Text = barcoAModificar.Nombre;
                cmbTipo.Enabled = false;
                cmbOperacion.Text = barcoAModificar.Operacion.ToString();
                txtCosto.Text = barcoAModificar.Costo.ToString();
                txtTripulacion.Text = barcoAModificar.Tripulacion.ToString();
                btnCargar.Text = "Modificar";
            }
        }

        /// <summary>
        /// Método que se ejecuta al hacer clic en el botón de cargar.
        /// </summary>
        private void btnCargar_Click(object sender, EventArgs e)
        {
            if (this.indiceRegistroAModificar != -5)
            {
                // Modificar barco existente
                try
                {
                    barcoAModificar.Nombre = txtNombre.Text;
                    barcoAModificar.Operacion = (EOperacion)Enum.Parse(typeof(EOperacion), cmbOperacion.Text);

                    if (float.TryParse(txtCosto.Text, out float costo))
                    {
                        barcoAModificar.Costo = costo;
                    }
                    else
                    {
                        throw new FormatException("El valor del costo no tiene el formato correcto.");
                    }

                    if (int.TryParse(txtTripulacion.Text, out int tripulacion))
                    {
                        barcoAModificar.Tripulacion = tripulacion;
                    }
                    else
                    {
                        throw new FormatException("El valor de la tripulación no tiene el formato correcto.");
                    }

                    AccesoDatos.ModificarBarcos(barcoAModificar);
                    MessageBox.Show("Barco modificado con éxito!");
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                // Agregar nuevo barco
                try
                {
                    this.barcoNuevo = null;
                    string nombre = txtNombre.Text;
                    string tipo = cmbTipo.Text;
                    string operacion = cmbOperacion.Text;
                    float costo = float.Parse(txtCosto.Text);
                    int tripulacion = int.Parse(txtTripulacion.Text);

                    Enum.TryParse(operacion, out Entidades.EOperacion operacionEnum);
                    if (tipo == "Pirata")
                    {
                        this.barcoNuevo = new Pirata(costo, false, nombre, operacionEnum, tripulacion);
                    }
                    else if (tipo == "Marina")
                    {
                        this.barcoNuevo = new Marina(costo, false, nombre, operacionEnum, tripulacion);
                    }

                    if (AccesoDatos.GuardarBarcos(this.barcoNuevo))
                    {
                        MessageBox.Show("Barco agregado exitosamente a la base de datos.");
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Error al agregar el barco a la base de datos.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("El barco no fue agregado. No puede haber campos vacíos" + ex.Message);
                }
            }
        }
    }
}
