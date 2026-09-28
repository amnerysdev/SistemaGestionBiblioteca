using System;

namespace SistemaGestionBiblioteca
{
    public class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public string Autor { get; set; }
        public string ISBN { get; set; }
        public int AñoPublicacion { get; set; }
        public int NumeroPaginas { get; set; }
        public bool Disponible { get; set; } = true;

        public Libro(int id, string titulo, string genero, string autor, string isbn, int añoPublicacion, int numeroPaginas)
        {
            Id = id;
            Titulo = titulo;
            Genero = genero;
            Autor = autor;
            ISBN = isbn;
            AñoPublicacion = añoPublicacion;
            NumeroPaginas = numeroPaginas;
        }

        public override string ToString()
        {
            return $"Id: {Id} | Título: {Titulo} | Autor: {Autor} | ISBN: {ISBN} | Año: {AñoPublicacion} | Disponible: {(Disponible ? "Sí" : "No")}";
        }
    }
}