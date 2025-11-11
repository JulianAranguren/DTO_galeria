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
    public partial class FormBuscarEscultura : Form
    {
        private readonly ApiService api;

        public FormBuscarEscultura()
        {
            InitializeComponent();
            btnBuscar.MouseEnter += btnBuscar_MouseEnter;
            btnBuscar.MouseLeave += btnBuscar_MouseLeave;
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


        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar ID
                if (string.IsNullOrWhiteSpace(txtIdEscultura.Text))
                {
                    MessageBox.Show("Primero busca una escultura para actualizar.");
                    return;
                }

                int id = int.Parse(txtIdEscultura.Text);

                // Crear el objeto con los nuevos valores
                Escultura cambios = new Escultura
                {
                    Id = id,
                    Titulo = txtTitulo.Text,
                    Autor = txtAutor.Text,
                    Precio = double.TryParse(txtPrecio.Text, out double precio) ? precio : 0,
                    Estado = comboBox1.Text,
                    FechaIngreso = dateTimePicker1.Value,
                    Material = txtMaterial.Text,
                    Altura = double.TryParse(txtAltura.Text, out double altura) ? altura : 0,
                    Volumen = double.TryParse(txtVolumen.Text, out double volumen) ? volumen : 0,
                    Tipo = txtTipo.Text
                };

                // Llamar al API
                Escultura actualizada = await api.ActualizarEsculturaAsync(id, cambios);

                // Mostrar confirmación
                MessageBox.Show($"Escultura '{actualizada.Titulo}' actualizada correctamente.");

                // Refrescar los campos con los datos devueltos del servidor
                txtTitulo.Text = actualizada.Titulo;
                txtAutor.Text = actualizada.Autor;
                txtPrecio.Text = actualizada.Precio.ToString();
                comboBox1.Text = actualizada.Estado;
                dateTimePicker1.Value = actualizada.FechaIngreso;
                txtMaterial.Text = actualizada.Material;
                txtAltura.Text = actualizada.Altura.ToString();
                txtVolumen.Text = actualizada.Volumen.ToString();
                txtTipo.Text = actualizada.Tipo;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message);
            }
        }



        private void btnBuscar_MouseEnter(object sender, EventArgs e)
        {
            // Cambia el fondo del formulario al pasar el mouse
            this.BackgroundImage = Image.FromFile(@"Imagenes\Buscar.png");
            this.BackgroundImageLayout = ImageLayout.Zoom; // para que se ajuste al tamaño
        }

        private void btnBuscar_MouseLeave(object sender, EventArgs e)
        {
            // Restaura el fondo original cuando sale el mouse
            this.BackgroundImage = Image.FromFile(@"Imagenes\background.png");
            // O si quieres otra imagen:
            // this.BackgroundImage = Image.FromFile(@"Imagenes\fondo_normal.jpg");
            this.BackgroundImageLayout = ImageLayout.Zoom;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
