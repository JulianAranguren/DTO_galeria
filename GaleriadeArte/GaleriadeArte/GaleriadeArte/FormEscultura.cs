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
    public partial class FormEscultura : Form
    {
        public FormEscultura()
        {
            InitializeComponent();
        }

        private void btnAgregarEscultura_Click(object sender, EventArgs e)
        {
            FormAñadirEscultura ventana = new FormAñadirEscultura();
            ventana.Show();
        }

        private void btnBuscarEscultura_Click(object sender, EventArgs e)
        {
            FormBuscarEscultura ventana = new FormBuscarEscultura();
            ventana.Show();
        }

        private void btnEliminarEscultura_Click(object sender, EventArgs e)
        {
            FormEliminar_Escultura ventana = new FormEliminar_Escultura();
            ventana.Show();
        }

        private void btnListarEscultura_Click(object sender, EventArgs e)
        {
            FormListarEsculturas ventana = new FormListarEsculturas();
            ventana.Show();
        }
    }
}
