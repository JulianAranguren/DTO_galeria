using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GaleriadeArte
{
    public partial class FormListarAutores : Form
    {
        private readonly ApiServiceAutores api;

        public FormListarAutores()
        {
            InitializeComponent();

            api = new ApiServiceAutores();
        }

        private async void btnListar_Click(object sender, EventArgs e)
        {
            try
            {
                var autores = await api.GetAutoresAsync();
                listaCompleta = autores; // Guardamos la lista para filtrar luego

                if (autores == null || autores.Count == 0)
                {
                    MessageBox.Show("? No hay autores registrados.");
                }
                else
                {
                    dataGridViewAutores.AutoGenerateColumns = true;
                    dataGridViewAutores.DataSource = null;
                    dataGridViewAutores.DataSource = autores;

                    // Cambiar títulos de columnas
                    dataGridViewAutores.Columns[nameof(Autor.Id)].HeaderText = "Código";
                    dataGridViewAutores.Columns[nameof(Autor.Nombre)].HeaderText = "Nombre";
                    dataGridViewAutores.Columns[nameof(Autor.Nacionalidad)].HeaderText = "Nacionalidad";
                    dataGridViewAutores.Columns[nameof(Autor.FechaNacimiento)].HeaderText = "Fecha Nacimiento";
                    dataGridViewAutores.Columns[nameof(Autor.AñosExperiencia)].HeaderText = "Años de Experiencia";
                    dataGridViewAutores.Columns[nameof(Autor.EstiloPrincipal)].HeaderText = "Estilo Principal";
                    dataGridViewAutores.Columns[nameof(Autor.Activo)].HeaderText = "Activo";

                    // Formatear fecha
                    dataGridViewAutores.Columns[nameof(Autor.FechaNacimiento)].DefaultCellStyle.Format = "dd/MM/yyyy";

                    MessageBox.Show($"? Se cargaron {autores.Count} autores.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("? Error al listar autores: " + ex.Message);
            }
        }

        // Guardar la lista completa para poder filtrar sin volver a llamar la API
        private List<Autor> listaCompleta = new List<Autor>();

        // Método auxiliar para aplicar filtro
        private void FiltrarAutores(string texto)
        {
            if (listaCompleta == null || listaCompleta.Count == 0)
                return;

            string filtro = texto.ToLower();

            var filtrados = listaCompleta.Where(a =>
                (!string.IsNullOrEmpty(a.Nombre) && a.Nombre.ToLower().Contains(filtro)) ||
                (!string.IsNullOrEmpty(a.Nacionalidad) && a.Nacionalidad.ToLower().Contains(filtro)) ||
                (!string.IsNullOrEmpty(a.EstiloPrincipal) && a.EstiloPrincipal.ToLower().Contains(filtro)) ||
                (a.AñosExperiencia.ToString().Contains(filtro)) ||
                (a.Activo.ToString().ToLower().Contains(filtro))
            ).ToList();

            dataGridViewAutores.DataSource = null;
            dataGridViewAutores.DataSource = filtrados;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            FiltrarAutores(txtFiltro.Text.Trim());
        }

    }
}
