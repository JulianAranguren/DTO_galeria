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
    public partial class FormListarEsculturas : Form
    {
        private readonly ApiService api;

        public FormListarEsculturas()
        {
            InitializeComponent();
            btnListar.MouseEnter += btnListar_MouseEnter;
            btnListar.MouseLeave += btnListar_MouseLeave;
            api = new ApiService();
        }

        private async void btnListar_Click(object sender, EventArgs e)
        {
            try
            {
                var esculturas = await api.GetEsculturasAsync(); // Usa tu método en ApiService
                listaCompleta = esculturas; // 🔹 Guardamos la lista para filtrar luego


                if (esculturas == null || esculturas.Count == 0)
                {
                    MessageBox.Show("ℹ No hay esculturas registradas.");
                }
                else
                {
                    dataGridViewEsculturas.AutoGenerateColumns = true; // ✅ Mostrar todas las propiedades
                    dataGridViewEsculturas.DataSource = null;
                    dataGridViewEsculturas.DataSource = esculturas;

                    // ✅ Cambiar títulos de columnas para que se vean mejor
                    dataGridViewEsculturas.Columns[nameof(Escultura.Id)].HeaderText = "Código";
                    dataGridViewEsculturas.Columns[nameof(Escultura.Titulo)].HeaderText = "Título";
                    dataGridViewEsculturas.Columns[nameof(Escultura.Autor)].HeaderText = "Autor";
                    dataGridViewEsculturas.Columns[nameof(Escultura.Precio)].HeaderText = "Precio ($)";
                    dataGridViewEsculturas.Columns[nameof(Escultura.Estado)].HeaderText = "Estado";
                    dataGridViewEsculturas.Columns[nameof(Escultura.Tipo)].HeaderText = "Tipo";
                    dataGridViewEsculturas.Columns[nameof(Escultura.Altura)].HeaderText = "Altura";
                    dataGridViewEsculturas.Columns[nameof(Escultura.Volumen)].HeaderText = "Volumen";
                    dataGridViewEsculturas.Columns[nameof(Escultura.Material)].HeaderText = "Material";
                    dataGridViewEsculturas.Columns[nameof(Escultura.FechaIngreso)].HeaderText = "Fecha de Ingreso";

                    // ✅ Formatear Precio y Fecha
                    dataGridViewEsculturas.Columns[nameof(Escultura.Precio)].DefaultCellStyle.Format = "C2"; // Moneda
                    dataGridViewEsculturas.Columns[nameof(Escultura.FechaIngreso)].DefaultCellStyle.Format = "dd/MM/yyyy"; // Fecha

                    MessageBox.Show($"✅ Se cargaron {esculturas.Count} esculturas.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error al listar esculturas: " + ex.Message);
            }
        }

        // 🔹 Guardar la lista completa para poder filtrar sin volver a llamar la API
        private List<Escultura> listaCompleta = new List<Escultura>();

        // 🔹 Método auxiliar para aplicar filtro
        private void FiltrarEsculturas(string texto)
        {
            if (listaCompleta == null || listaCompleta.Count == 0)
                return;

            string filtro = texto.ToLower();

            // LINQ para buscar coincidencias
            var filtradas = listaCompleta.Where(e =>
                (!string.IsNullOrEmpty(e.Titulo) && e.Titulo.ToLower().Contains(filtro)) ||
                (!string.IsNullOrEmpty(e.Autor) && e.Autor.ToLower().Contains(filtro)) ||
                (!string.IsNullOrEmpty(e.Material) && e.Material.ToLower().Contains(filtro)) ||
                (!string.IsNullOrEmpty(e.Tipo) && e.Tipo.ToLower().Contains(filtro)) ||
                (!string.IsNullOrEmpty(e.Estado) && e.Estado.ToLower().Contains(filtro))
            ).ToList();

            // Actualizar el DataGridView
            dataGridViewEsculturas.DataSource = null;
            dataGridViewEsculturas.DataSource = filtradas;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            FiltrarEsculturas(txtFiltro.Text.Trim());
        }

        private void btnListar_MouseEnter(object sender, EventArgs e)
        {
            // Cambia el fondo del formulario al pasar el mouse
            this.BackgroundImage = Image.FromFile(@"Imagenes\Listar.png");
            this.BackgroundImageLayout = ImageLayout.Zoom; // para que se ajuste al tamaño
        }

        private void btnListar_MouseLeave(object sender, EventArgs e)
        {
            // Restaura el fondo original cuando sale el mouse
            this.BackgroundImage = Image.FromFile(@"Imagenes\background.png");
            // O si quieres otra imagen:
            // this.BackgroundImage = Image.FromFile(@"Imagenes\fondo_normal.jpg");
            this.BackgroundImageLayout = ImageLayout.Zoom;
        }
    }
}
