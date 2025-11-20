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
    public partial class FormAñadirEscultura : Form
    {
        private readonly ApiService api;

        public FormAñadirEscultura()
        {
            InitializeComponent();
            comboEstado.Items.Add("Activo");
            comboEstado.Items.Add("Inactivo");
            btnAñadir.MouseEnter += btnAñadir_MouseEnter;
            btnAñadir.MouseLeave += btnAñadir_MouseLeave;
            api = new ApiService();
        }

        private async void btnAñadir_Click(object sender, EventArgs e)
        {
            try
            {
                // Validaciones básicas
                if (string.IsNullOrWhiteSpace(txtTitulo.Text) || string.IsNullOrWhiteSpace(txtAutor.Text))
                {
                    MessageBox.Show("❌ El título y el autor son obligatorios");
                    return;
                }

                // Crear el DTO en lugar de la entidad Escultura
                var requestDTO = new ObraArteRequest
                {
                    Titulo = txtTitulo.Text,
                    Autor = txtAutor.Text,
                    Precio = double.Parse(txtPrecio.Text),
                    Estado = comboEstado.SelectedItem?.ToString() ?? "Activo",
                    Altura = double.Parse(txtAltura.Text), // Asumo que tienes txtAltura
                    Volumen = double.Parse(txtVolumen.Text),
                    Material = txtMaterial.Text,
                    TipoEscultura = textBox2.Text // Considera renombrar textBox2 a txtTipoEscultura
                };

                // Usar el método con DTO que valida el artista
                ObraArteResponse creada = await api.CrearEsculturaConDTOAsync(requestDTO);

                MessageBox.Show($"✅ Escultura añadida con éxito:\nID: {creada.Id}\nTítulo: {creada.Titulo}\nArtista: {creada.Artista?.Nombre}");

                // Limpiar campos después de agregar
                LimpiarCampos();
            }
            catch (FormatException)
            {
                MessageBox.Show("❌ Error en el formato de los números (precio, altura, volumen)");
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error al añadir escultura: " + ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            txtTitulo.Clear();
            txtAutor.Clear();
            txtPrecio.Clear();
            txtAltura.Clear(); // Asumo que tienes este campo
            txtVolumen.Clear();
            txtMaterial.Clear();
            textBox2.Clear(); // Considera renombrar a txtTipoEscultura
            comboEstado.SelectedIndex = 0; // Volver al primer elemento
        }

        private void btnAñadir_MouseEnter(object sender, EventArgs e)
        {
            // Cambia el fondo del formulario al pasar el mouse
            this.BackgroundImage = Image.FromFile(@"Imagenes\Agregar.png");
            this.BackgroundImageLayout = ImageLayout.Zoom; // para que se ajuste al tamaño
        }

        private void btnAñadir_MouseLeave(object sender, EventArgs e)
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

        private void txtTitulo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAutor_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textTecnica_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTextura_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEscultura_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
