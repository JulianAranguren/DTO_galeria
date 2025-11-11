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
    public partial class FormPintura : Form
    {
        public FormPintura()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormAñadirPintura ventana = new FormAñadirPintura();
            ventana.Show();
        }

        private void btnBuscarPintura_Click(object sender, EventArgs e)
        {
            FormBuscarPintura ventana = new FormBuscarPintura();
            ventana.Show();
        }

        private void btnEliminarPintura_Click(object sender, EventArgs e)
        {
            FormEliminarPintura ventana = new FormEliminarPintura();
            ventana.Show();
        }

        private void btnListarPintura_Click(object sender, EventArgs e)
        {
            FormListarPinturas ventana = new FormListarPinturas();
            ventana.Show();
        }
    }
}
