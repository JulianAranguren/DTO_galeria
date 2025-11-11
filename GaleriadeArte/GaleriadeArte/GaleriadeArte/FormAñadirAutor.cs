using System;
using System.Windows.Forms;

namespace GaleriadeArte
{
    public partial class FormAñadirAutor : Form
    {
        private readonly ApiServiceAutores api; // Nueva clase para autores

        public FormAñadirAutor()
        {
            InitializeComponent();

            // ComboBox para estado activo/inactivo
            comboActivo.Items.Add("Activo");
            comboActivo.Items.Add("Inactivo");
            comboActivo.SelectedIndex = 0; // Por defecto activo

           // btnAñadir.MouseEnter += btnAñadir_MouseEnter;
            //btnAñadir.MouseLeave += btnAñadir_MouseLeave;

            api = new ApiServiceAutores();
        }

        private async void btnAñadir_Click(object sender, EventArgs e)
        {
            try
            {
                Autor nuevo = new Autor
                {
                    // Id lo puede manejar la BD automáticamente, opcionalmente puedes dejarlo 0
                    Nombre = txtNombre.Text,
                    Nacionalidad = txtNacionalidad.Text,
                    FechaNacimiento = dateFechaNacimiento.Value,
                    AñosExperiencia = double.Parse(txtAñosExp.Text),
                    EstiloPrincipal = txtEstilo.Text,
                    Activo = comboActivo.SelectedItem?.ToString() == "Activo"
                };

                Autor creado = await api.CrearAutorAsync(nuevo);

                MessageBox.Show($"? Autor añadido con éxito:\nID: {creado.Id}\nNombre: {creado.Nombre}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("? Error al añadir autor: " + ex.Message);
            }
        }

        //private void btnAñadir_MouseEnter(object sender, EventArgs e)
        //{
          //  this.BackgroundImage = Image.FromFile(@"Imagenes\Agregar.png");
           // this.BackgroundImageLayout = ImageLayout.Zoom;
        //}

        //private void btnAñadir_MouseLeave(object sender, EventArgs e)
        //{
          //  this.BackgroundImage = Image.FromFile(@"Imagenes\background.png");
            //this.BackgroundImageLayout = ImageLayout.Zoom;
        //}
    }
}
