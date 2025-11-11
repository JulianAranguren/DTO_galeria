using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using GaleriadeArte;

namespace GaleriadeArte
{
    public partial class FormBuscarPintura : Form
    {
        private readonly ApiService api;

        public FormBuscarPintura()
        {
            InitializeComponent();

            btnBuscar.MouseEnter += btnBuscar_MouseEnter;
            btnBuscar.MouseLeave += btnBuscar_MouseLeave;

            // Usa el constructor correcto (ya tiene el puerto 8090 configurado dentro de ApiService)
            api = new ApiService();
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que haya un ID
                if (string.IsNullOrWhiteSpace(txtIdPintura.Text))
                {
                    MessageBox.Show("Ingresa un ID para buscar.");
                    return;
                }

                // Convertir el texto a entero
                if (!int.TryParse(txtIdPintura.Text, out int id))
                {
                    MessageBox.Show("El ID debe ser un número válido.");
                    return;
                }

                // Buscar pintura por ID (asegúrate que este método exista en ApiService)
                Pintura pintura = await api.BuscarPinturaPorIdAsync(id);

                if (pintura == null)
                {
                    MessageBox.Show("No se encontró ninguna pintura con ese ID.");
                    return;
                }

                // Rellenar los campos de la GUI
                txtIdPintura.Text = pintura.Id.ToString();
                txtTitulo.Text = pintura.Titulo;
                txtAutor.Text = pintura.Autor;
                txtPrecio.Text = pintura.Precio.ToString();
                comboBox1.Text = pintura.Estado;
                dateTimePicker1.Value = pintura.FechaIngreso;
                textTecnica.Text = pintura.Tecnica;
                txtTextura.Text = pintura.Textura;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar pintura: " + ex.Message);
            }
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar ID
                if (string.IsNullOrWhiteSpace(txtIdPintura.Text))
                {
                    MessageBox.Show("Primero busca una pintura para actualizar.");
                    return;
                }

                if (!int.TryParse(txtIdPintura.Text, out int id))
                {
                    MessageBox.Show("El ID debe ser un número válido.");
                    return;
                }

                // Crear el objeto con los valores actuales del formulario
                Pintura cambios = new Pintura
                {
                    Id = id,
                    Titulo = txtTitulo.Text,
                    Autor = txtAutor.Text,
                    Precio = double.TryParse(txtPrecio.Text, out double precio) ? precio : 0,
                    Estado = comboBox1.Text,
                    FechaIngreso = dateTimePicker1.Value,
                    Tecnica = textTecnica.Text,
                    Textura = txtTextura.Text
                };

                // Llamar al API para actualizar
                Pintura actualizada = await api.ActualizarPinturaAsync(id, cambios);

                // Confirmar resultado
                MessageBox.Show($"Pintura '{actualizada.Titulo}' actualizada correctamente.");

                // Refrescar los campos con la pintura actualizada
                txtTitulo.Text = actualizada.Titulo;
                txtAutor.Text = actualizada.Autor;
                txtPrecio.Text = actualizada.Precio.ToString();
                comboBox1.Text = actualizada.Estado;
                dateTimePicker1.Value = actualizada.FechaIngreso;
                textTecnica.Text = actualizada.Tecnica;
                txtTextura.Text = actualizada.Textura;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar pintura: " + ex.Message);
            }
        }


        private void btnBuscar_MouseEnter(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile(@"Imagenes\Buscar.png");
            this.BackgroundImageLayout = ImageLayout.Zoom;
        }

        private void btnBuscar_MouseLeave(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile(@"Imagenes\background.png");
            this.BackgroundImageLayout = ImageLayout.Zoom;
        }
    }
}
