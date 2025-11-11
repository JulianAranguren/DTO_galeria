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
    public partial class FormEliminar_Escultura : Form
    {
        private readonly ApiService api;

        public FormEliminar_Escultura()
        {
            InitializeComponent();
            btnEliminar.MouseEnter += btnEliminar_MouseEnter;
            btnEliminar.MouseLeave += btnEliminar_MouseLeave;
            api = new ApiService();
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtIdEscultura.Text))
                {
                    MessageBox.Show("Ingresa un ID para buscar.");
                    return;
                }

                int id = int.Parse(txtIdEscultura.Text);

                Escultura escultura = await api.BuscarEsculturaPorIdAsync(id);

                if (escultura == null)
                {
                    MessageBox.Show("No se encontró la escultura con ese ID.");
                    return;
                }

                // Rellenar los campos de la interfaz
                txtTitulo.Text = escultura.Titulo;
                txtAutor.Text = escultura.Autor;
                txtPrecio.Text = escultura.Precio.ToString();
                comboBox1.Text = escultura.Estado;
                dateTimePicker1.Value = escultura.FechaIngreso;
                txtMaterial.Text = escultura.Material;
                txtAltura.Text = escultura.Altura.ToString();
                txtVolumen.Text = escultura.Volumen.ToString();
                txtTipo.Text = escultura.Tipo;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar escultura: " + ex.Message);
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtIdEscultura.Text, out int id))
            {
                try
                {
                    await api.EliminarEsculturaAsync(id);
                    MessageBox.Show("✅ Pintura eliminada correctamente.");
                    txtIdEscultura.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("❌ Error eliminando pintura: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("⚠️ Ingresa un ID válido.");
            }
        }
        private void btnEliminar_MouseEnter(object sender, EventArgs e)
        {
            // Cambia el fondo del formulario al pasar el mouse
            this.BackgroundImage = Image.FromFile(@"Imagenes\Eliminar.png");
            this.BackgroundImageLayout = ImageLayout.Zoom; // para que se ajuste al tamaño
        }

        private void btnEliminar_MouseLeave(object sender, EventArgs e)
        {
            // Restaura el fondo original cuando sale el mouse
            this.BackgroundImage = Image.FromFile(@"Imagenes\background.png");
            // O si quieres otra imagen:
            // this.BackgroundImage = Image.FromFile(@"Imagenes\fondo_normal.jpg");
            this.BackgroundImageLayout = ImageLayout.Zoom;
        }

        private void txtIdEscultura_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormEliminar_Escultura_Load(object sender, EventArgs e)
        {

        }
    }
}
