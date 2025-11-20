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
    public partial class FormListarPinturas : Form
    {
        private readonly ApiService api;

        public FormListarPinturas()
        {
            InitializeComponent(); // siempre primero

            btnListar.MouseEnter += btnListar_MouseEnter;
            btnListar.MouseLeave += btnListar_MouseLeave;

            api = new ApiService();
        }

        private async void btnListar_Click(object sender, EventArgs e)
        {
            try
            {
                var pinturas = await api.GetPinturasAsync(); // usa el método correcto
                listaCompleta = pinturas;

                if (pinturas == null || pinturas.Count == 0)
                {
                    MessageBox.Show("ℹ No hay pinturas registradas.");
                }
                else
                {
                    dataGridView1.AutoGenerateColumns = true; // ✅ Mostrar todas las propiedades
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = pinturas;

                    // ✅ Cambiar títulos de columnas para que se vean mejor
                    dataGridView1.Columns[nameof(Pintura.Id)].HeaderText = "Código";
                    dataGridView1.Columns[nameof(Pintura.Titulo)].HeaderText = "Título";
                    dataGridView1.Columns[nameof(Pintura.Autor)].HeaderText = "Autor";
                    dataGridView1.Columns[nameof(Pintura.Precio)].HeaderText = "Precio ($)";
                    dataGridView1.Columns[nameof(Pintura.Estado)].HeaderText = "Estado";
                    dataGridView1.Columns[nameof(Pintura.Tecnica)].HeaderText = "Técnica";
                    dataGridView1.Columns[nameof(Pintura.Textura)].HeaderText = "Textura";
                    dataGridView1.Columns[nameof(Pintura.FechaIngreso)].HeaderText = "Fecha de Ingreso";

                    // ✅ Formatear Precio y Fecha
                    dataGridView1.Columns[nameof(Pintura.Precio)].DefaultCellStyle.Format = "C2"; // Moneda
                    dataGridView1.Columns[nameof(Pintura.FechaIngreso)].DefaultCellStyle.Format = "dd/MM/yyyy"; // Fecha

                    MessageBox.Show($"✅ Se cargaron {pinturas.Count} pinturas.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error al listar: " + ex.Message);
            }
        }

        private List<Pintura> listaCompleta = new List<Pintura>();

        // 🔹 Método auxiliar para aplicar filtro
        private void FiltrarPinturas(string texto)
        {
            if (listaCompleta == null || listaCompleta.Count == 0)
                return;

            string filtro = texto.ToLower();

            // LINQ para buscar coincidencias
            var filtradas = listaCompleta.Where(e =>
                (!string.IsNullOrEmpty(e.Titulo) && e.Titulo.ToLower().Contains(filtro)) ||
                (!string.IsNullOrEmpty(e.Autor) && e.Autor.ToLower().Contains(filtro)) ||
                (!string.IsNullOrEmpty(e.Tipo) && e.Tipo.ToLower().Contains(filtro)) ||
                (!string.IsNullOrEmpty(e.Estado) && e.Estado.ToLower().Contains(filtro))
            ).ToList();

            // Actualizar el DataGridView
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = filtradas;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            FiltrarPinturas(txtFiltro.Text.Trim());
        }


        private void btnListar_MouseEnter(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile(@"Imagenes\Listar.png");
            this.BackgroundImageLayout = ImageLayout.Zoom;
        }

        private void btnListar_MouseLeave(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile(@"Imagenes\background.png");
            this.BackgroundImageLayout = ImageLayout.Zoom;
        }
    }
}
