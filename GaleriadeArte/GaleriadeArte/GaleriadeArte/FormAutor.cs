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
    public partial class FormAutor : Form
    {
        public FormAutor()
        {
            InitializeComponent();
        }

        private void btnAñadirAutor_Click(object sender, EventArgs e)
        {
            FormAñadirAutor ventana = new FormAñadirAutor();
            ventana.Show();
        }

        private void btnBuscarAutor_Click(object sender, EventArgs e)
        {
            FormBuscarAutor ventana = new FormBuscarAutor();
            ventana.Show();
        }

       

        private void btnListarAutor_Click(object sender, EventArgs e)
        {
            FormListarAutores ventana = new FormListarAutores();
            ventana.Show();
        }
    }
}
