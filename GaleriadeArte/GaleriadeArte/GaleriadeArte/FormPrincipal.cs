using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace GaleriadeArte
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            // 🔗 Conectar eventos del botón
            btnEscultura.MouseEnter += btnEscultura_MouseEnter;
            btnEscultura.MouseLeave += btnEscultura_MouseLeave;
            btnPintura.MouseEnter += btnPintura_MouseEnter;
            btnPintura.MouseLeave += btnPintura_MouseLeave;
            btnAcercaDe.MouseEnter += btnAcercaDe_MouseEnter;
            btnAcercaDe.MouseLeave += btnAcercaDe_MouseLeave;

            // (opcional) anclar el botón para que se estire al redimensionar
            btnEscultura.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
        private void btnEscultura_MouseEnter(object sender, EventArgs e)
        {
            // Cambia el fondo del formulario al pasar el mouse
            this.BackgroundImage = Image.FromFile(@"Imagenes\Background dedo.png");
            this.BackgroundImageLayout = ImageLayout.Zoom; // para que se ajuste al tamaño
        }

        private void btnEscultura_MouseLeave(object sender, EventArgs e)
        {
            // Restaura el fondo original cuando sale el mouse
            this.BackgroundImage = Image.FromFile(@"Imagenes\background.png");
            // O si quieres otra imagen:
            // this.BackgroundImage = Image.FromFile(@"Imagenes\fondo_normal.jpg");
            this.BackgroundImageLayout = ImageLayout.Zoom;
        }


        private void btnEscultura_Click(object sender, EventArgs e){
            FormEscultura ventana = new FormEscultura(); 
            ventana.Show(); 

        }

        private void btnPintura_MouseEnter(object sender, EventArgs e)
        {
            // Cambia el fondo del formulario al pasar el mouse
            this.BackgroundImage = Image.FromFile(@"Imagenes\Background dedo derecha.png");
            this.BackgroundImageLayout = ImageLayout.Zoom; // para que se ajuste al tamaño
        }

        private void btnPintura_MouseLeave(object sender, EventArgs e)
        {
            // Restaura el fondo original cuando sale el mouse
            this.BackgroundImage = Image.FromFile(@"Imagenes\background.png");
            // O si quieres otra imagen:
            // this.BackgroundImage = Image.FromFile(@"Imagenes\fondo_normal.jpg");
            this.BackgroundImageLayout = ImageLayout.Zoom;
        }


        private void btnPintura_Click(object sender, EventArgs e)
        {
            FormPintura ventana = new FormPintura();
            ventana.Show();
        }

        private void btnAutor_Click(object sender, EventArgs e)
        {
            FormAutor ventana = new FormAutor();
            ventana.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            txtBienvenida1.TabStop = false;  // que no se pueda enfocar con Tab
            txtBienvenida1.Cursor = Cursors.Arrow; // que no salga el cursor de texto
        }

        private void btnAcercaDe_Click(object sender, EventArgs e)
        {
            FormAcercaDe ventana = new FormAcercaDe();
            ventana.Show();
        }
        private void btnAcercaDe_MouseEnter(object sender, EventArgs e)
        {
            // Cambia el fondo del formulario al pasar el mouse
            this.BackgroundImage = Image.FromFile(@"Imagenes\Acerca de.png");
            this.BackgroundImageLayout = ImageLayout.Zoom; // para que se ajuste al tamaño
        }

        private void btnAcercaDe_MouseLeave(object sender, EventArgs e)
        {
            // Restaura el fondo original cuando sale el mouse
            this.BackgroundImage = Image.FromFile(@"Imagenes\background.png");
            // O si quieres otra imagen:
            // this.BackgroundImage = Image.FromFile(@"Imagenes\fondo_normal.jpg");
            this.BackgroundImageLayout = ImageLayout.Zoom;
        }
    }
}
