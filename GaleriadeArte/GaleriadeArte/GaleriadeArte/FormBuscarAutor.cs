using System;
using System.Windows.Forms;

namespace GaleriadeArte
{
    public partial class FormBuscarAutor : Form
    {
        private readonly ApiServiceAutores api;

        public FormBuscarAutor()
        {
            InitializeComponent();
            

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

                Autor autor = await api.GetAutorAsync(id);

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

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtIdAutor.Text))
                {
                    MessageBox.Show("Primero busca un autor para actualizar.");
                    return;
                }

                int id = int.Parse(txtIdAutor.Text);

                Autor cambios = new Autor
                {
                    Id = id,
                    Nombre = txtNombre.Text,
                    Nacionalidad = txtNacionalidad.Text,
                    FechaNacimiento = dateFechaNacimiento.Value,
                    AñosExperiencia = double.TryParse(txtAñosExp.Text, out double años) ? años : 0,
                    EstiloPrincipal = txtEstilo.Text,
                    Activo = comboActivo.SelectedItem?.ToString() == "Activo"
                };

                Autor actualizado = await api.ActualizarAutorAsync(id, cambios);

                MessageBox.Show($"? Autor actualizado:\nID: {actualizado.Id}\nNombre: {actualizado.Nombre}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("? Error al actualizar autor: " + ex.Message);
            }
        }

        
    }
}
