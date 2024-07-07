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

namespace TallerFrankyUi
{
    public partial class FrmPrincipal : Form
    {
        Taller taller1;
        XmlManager xmlManager;
        public FrmPrincipal()
        {
            InitializeComponent();
            this.taller1 = new Taller();
            this.xmlManager = new XmlManager();
        }


        private void btnCargarBarco_Click(object sender, EventArgs e)
        {
            FrmBarco frmBarco = new FrmBarco();

            if (frmBarco.ShowDialog() == DialogResult.OK)
            {
                this.taller1 = this.taller1.IngresarBarco(frmBarco.BarcoNuevo);
                MessageBox.Show("Barco agregado exitosamente!\n" + frmBarco.BarcoNuevo.ToString());
            }
        }

        private void btnReparar_Click(object sender, EventArgs e)
        {
            
        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            //TODO: Preguntarle al usuario si esta seguro de salir del formulario
            DialogResult salir = MessageBox.Show("¿Desea salir?", "Salir de la app", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (salir == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //TODO: Utilizar la clase XmlManager para guardar el archivo xml
            //cambiar ruta al final
            if (this.xmlManager.Guardar("C:\\Users\\SPL2_1C2024-main\\taller.xml", this.taller1))
            {
                MessageBox.Show("Archivo xml generado!");
            }
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            string path = "C:\\Users\\PC\\Documents\\barcos.xml";

            if (File.Exists(path))
            {
                this.taller1.Barcos = this.xmlManager.Leer(path);
            }
            else
            {
                Console.WriteLine("El archivo no existe.");
            }
            
        }
    }
}
