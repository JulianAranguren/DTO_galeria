using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GaleriadeArte
{
    public partial class FormArtista : Form
    {
        public FormArtista()
        {
            InitializeComponent();
        }

        private void btnAñadirArtista_Click(object sender, EventArgs e)
        {
            FormAñadirArtista ventana = new FormAñadirArtista();
            ventana.Show();
        }

        private void btnBuscarArtista_Click(object sender, EventArgs e)
        {
            FormBuscarArtistas ventana = new FormBuscarArtistas();
            ventana.Show();
        }

        private void btnListarArtista_Click(object sender, EventArgs e)
        {
            FormListarArtistas ventana = new FormListarArtistas();
            ventana.Show();
        }

        private void btnGestionarEstados_Click(object sender, EventArgs e)
        {
            FormEliminarArtista ventana = new FormEliminarArtista();
            ventana.Show();
        }
    }
}
