using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GaleriadeArte;

namespace GaleriadeArte
{
    public partial class FormAñadirPintura : Form
    {
        private readonly ApiService api;

        public FormAñadirPintura()
        {
            InitializeComponent();
            comboBox1.Items.Add("Activo");
            comboBox1.Items.Add("Inactivo");

            btnAñadir.MouseEnter += btnAñadir_MouseEnter;
            btnAñadir.MouseLeave += btnAñadir_MouseLeave;

            // ✅ Usa la URL correcta del backend
            api = new ApiService(); // Ya tiene base http://localhost:8090/ en tu clase
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

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

                // Crear el DTO en lugar de la entidad Pintura
                var requestDTO = new ObraArteRequest
                {
                    Titulo = txtTitulo.Text,
                    Autor = txtAutor.Text,
                    Precio = double.Parse(txtPrecio.Text),
                    Estado = comboBox1.SelectedItem?.ToString() ?? "Activo",
                    Tecnica = textTecnica.Text,
                    Textura = txtTextura.Text
                    // NOTA: No envíes FechaIngreso ni ID, se generan automáticamente
                };

                // ✅ Usar el método con DTO que valida el artista
                ObraArteResponse creada = await api.CrearPinturaConDTOAsync(requestDTO);

                MessageBox.Show($"✅ Pintura añadida con éxito:\nID: {creada.Id}\nTítulo: {creada.Titulo}\nArtista: {creada.Artista?.Nombre}");

                // Limpiar campos después de agregar
                LimpiarCampos();
            }
            catch (FormatException)
            {
                MessageBox.Show("❌ Error en el formato del precio (debe ser un número)");
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error al añadir pintura: " + ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            txtTitulo.Clear();
            txtAutor.Clear();
            txtPrecio.Clear();
            textTecnica.Clear();
            txtTextura.Clear();
            comboBox1.SelectedIndex = 0; // Volver al primer elemento
                                         // No limpies txtIdPintura porque el ID lo genera la base de datos
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

        private void txtIdPintura_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
