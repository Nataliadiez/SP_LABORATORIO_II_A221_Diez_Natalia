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

namespace TallerFrankyUi
{
    public partial class FrmReparacion : Form
    {
        Taller tallerEnReparacion;
        public FrmReparacion(Taller taller)
        {
            InitializeComponent();
            this.tallerEnReparacion = taller;
            //tallerEnReparacion.Reparar(taller);
            //ver si puede reparar todos los barcos
        }

        private void FrmReparacion_Load(object sender, EventArgs e)
        {
            lstTaller.DataSource = tallerEnReparacion.Barcos;
        }

    }
}
