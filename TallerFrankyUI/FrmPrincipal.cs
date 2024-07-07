using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Parcial.WindowsForm;

namespace TallerFrankyUi
{
    public partial class FrmPrincipal : Form
    {
        Taller taller1;         // Instancia del taller de barcos
        XmlManager xmlManager;   // Manejador para operaciones XML
        string path;             // Ruta del archivo XML

        // Propiedad para acceder al taller de barcos
        public Taller Taller1
        {
            get => this.taller1;
            set => this.taller1 = value;
        }

        // Constructor del formulario principal
        public FrmPrincipal()
        {
            InitializeComponent();

            // Inicialización del taller, XmlManager y la ruta del archivo XML
            this.taller1 = new Taller();
            this.xmlManager = new XmlManager();
            this.path = "C:\\Users\\PC\\Downloads\\SPL2_1C2024-main\\Archivos Xml\\barcos.xml"; // Cambiar esta ruta según sea necesario
        }

        // Método que se ejecuta al hacer clic en el botón de cargar barco
        private void btnCargarBarco_Click(object sender, EventArgs e)
        {
            FrmBarco frmBarco = new FrmBarco();

            // Abrir el formulario FrmBarco para agregar un nuevo barco al taller
            if (frmBarco.ShowDialog() == DialogResult.OK)
            {
                this.taller1 = this.taller1.IngresarBarco(frmBarco.BarcoNuevo);
                MessageBox.Show("Barco agregado exitosamente!\n" + frmBarco.BarcoNuevo.ToString());
            }
        }

        // Método que se ejecuta al hacer clic en el botón de reparar
        private void btnReparar_Click(object sender, EventArgs e)
        {
            // Abrir el formulario FrmReparacion para reparar los barcos del taller
            FrmReparacion formReparacion = new FrmReparacion(taller1);
            formReparacion.ShowDialog();
        }

        // Método que se ejecuta al cerrar el formulario principal
        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Preguntar al usuario si está seguro de salir de la aplicación
            DialogResult salir = MessageBox.Show("¿Desea salir?", "Salir de la app", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (salir == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        // Método que se ejecuta al hacer clic en el botón de guardar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Utilizar XmlManager para guardar el taller de barcos en un archivo XML
            if (this.xmlManager.Guardar(path, this.taller1))
            {
                MessageBox.Show("Archivo XML generado correctamente!");
            }
            else
            {
                MessageBox.Show("No se pudo crear el archivo XML.");
            }
        }

        // Método que se ejecuta al cargar el formulario principal
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            // Cargar los barcos desde el archivo XML si existe
            if (File.Exists(path))
            {
                this.taller1.Barcos = this.xmlManager.Leer(path);
            }
        }

        // Método que se ejecuta al hacer clic en el botón de mostrar barcos
        private void btnMostrarBarcos_Click(object sender, EventArgs e)
        {
            // Abrir el formulario FrmMostrar para mostrar los barcos del taller
            FrmMostrar frmMostrar = new FrmMostrar();
            frmMostrar.ShowDialog();
        }
    }
}
