using System;

namespace GaleriadeArte
{
    public class ObraArteResponse
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public double Precio { get; set; }
        public string Estado { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Tipo { get; set; }
        public Artista Artista { get; set; }

        // Campos específicos de Pintura
        public string Tecnica { get; set; }
        public string Textura { get; set; }

        // Campos específicos de Escultura
        public double? Altura { get; set; }
        public double? Volumen { get; set; }
        public string Material { get; set; }
        public string TipoEscultura { get; set; }
    }
}