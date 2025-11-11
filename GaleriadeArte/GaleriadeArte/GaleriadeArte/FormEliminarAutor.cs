using System;
using System.Windows.Forms;

namespace GaleriadeArte
{
    public partial class FormEliminarAutor : Form
    {
        private readonly ApiServiceAutores api;

        public FormEliminarAutor()
        {
            InitializeComponent();
            btnEliminar.MouseEnter += btnEliminar_MouseEnter;
            btnEliminar.MouseLeave += btnEliminar_MouseLeave;
            btnBuscar.MouseEnter += btnBuscar_MouseEnter;
            btnBuscar.MouseLeave += btnBuscar_MouseLeave;

            api = new ApiServiceAutores();
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtIdAutor.Text))
                {
                    MessageBox.Show("Ingresa un ID para buscar.");
                    return;
                }

                int id = int.Parse(txtIdAutor.Text);

                Autor autor = await api.BuscarAutorPorIdAsync(id);

                if (autor == null)
                {
                    MessageBox.Show("No se encontró el autor con ese ID.");
                    return;
                }

                // Rellenar los campos de la interfaz
                txtNombre.Text = autor.Nombre;
                txtNacionalidad.Text = autor.Nacionalidad;
                txtAñosExp.Text = autor.AñosExperiencia.ToString();
                txtEstilo.Text = autor.EstiloPrincipal;
                comboActivo.SelectedItem = autor.Activo ? "Activo" : "Inactivo";
                dateFechaNacimiento.Value = autor.FechaNacimiento;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar autor: " + ex.Message);
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtIdAutor.Text, out int id))
            {
                try
                {
                    await api.EliminarAutorAsync(id);
                    MessageBox.Show("? Autor eliminado correctamente.");
                    txtIdAutor.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("? Error eliminando autor: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("?? Ingresa un ID válido.");
            }
        }

        private void btnEliminar_MouseEnter(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile(@"Imagenes\Eliminar.png");
            this.BackgroundImageLayout = ImageLayout.Zoom;
        }

        private void btnEliminar_MouseLeave(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile(@"Imagenes\background.png");
            this.BackgroundImageLayout = ImageLayout.Zoom;
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
