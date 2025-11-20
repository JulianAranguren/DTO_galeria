using System;

namespace GaleriadeArte
{
    public class Pintura
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public double Precio { get; set; }
        public string Estado { get; set; }
        public DateTime FechaIngreso { get; set; }

        public string Tecnica { get; set; }
        public string Textura { get; set; }
        public string Tipo { get; set; }
    }
}
