using System;

namespace GaleriadeArte
{
    public class ObraArteRequest
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public double Precio { get; set; }
        public string Estado { get; set; }

        // Campos específicos para Pintura
        public string Tecnica { get; set; }
        public string Textura { get; set; }

        // Campos específicos para Escultura
        public double? Altura { get; set; }
        public double? Volumen { get; set; }
        public string Material { get; set; }
        public string TipoEscultura { get; set; }
    }
}