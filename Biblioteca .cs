using System;

namespace SistemaGestionBiblioteca
{
    public class Biblioteca
    {
        private const int CAPACIDAD_MAXIMA = 20;

        private Libro[] libros;

        private int cantidadLibros;

        private int siguienteId;

        public Biblioteca()
        {
            libros = new Libro[CAPACIDAD_MAXIMA];
            cantidadLibros = 0;
            siguienteId = 1;
        }

        // ---------------------------------------------------------
        // 1. Agregar un libro
        // Complejidad: O(1) -- se inserta directamente en la
        // siguiente posición libre, sin recorrer el arreglo.
        // ---------------------------------------------------------
        public bool AgregarLibro(Libro nuevoLibro)
        {
            if (cantidadLibros >= CAPACIDAD_MAXIMA)
            {
                Console.WriteLine("¡Llegaste al límite de tu biblioteca! Tu catálogo ya tiene el máximo permitido de 20 libros. Para agregar uno nuevo, elimina alguno que ya no necesites.");
                return false;
            }

            nuevoLibro.Id = siguienteId;
            siguienteId++;

            libros[cantidadLibros] = nuevoLibro;
            cantidadLibros++;
            Console.WriteLine($"¡Libro agregado exitosamente! '{nuevoLibro.Titulo}' ha sido registrado con el ID {nuevoLibro.Id}.");
            return true;
        }

        // ---------------------------------------------------------
        // 2. Listar los libros
        // Complejidad: O(n) -- se debe recorrer todo el arreglo
        // de posiciones ocupadas para mostrarlas.
        // ---------------------------------------------------------
        public void ListarLibros()
        {
            if (cantidadLibros == 0)
            {
                Console.WriteLine("El catálogo está vacío. Aún no se han registrado libros.");
                return;
            }

            Console.WriteLine($"\n----- CATÁLOGO DE LIBROS ({cantidadLibros}/{CAPACIDAD_MAXIMA}) -----");
            for (int i = 0; i < cantidadLibros; i++)
            {
                Console.WriteLine(libros[i]);
            }
        }

        // ---------------------------------------------------------
        // Método auxiliar interno: busca el índice de un libro por Id.
        // Es reutilizado por Buscar, Actualizar y Eliminar.
        // Complejidad: O(n)
        // ---------------------------------------------------------
        private int BuscarIndicePorId(int id)
        {
            for (int i = 0; i < cantidadLibros; i++)
            {
                if (libros[i].Id == id)
                {
                    return i;
                }
            }
            return -1;
        }

        // ---------------------------------------------------------
        // 3. Buscar un libro por ID
        // Complejidad: O(n) -- en el peor caso recorre todo el arreglo.
        // ---------------------------------------------------------
        public Libro BuscarLibroPorId(int id)
        {
            int indice = BuscarIndicePorId(id);

            if (indice == -1)
            {
                Console.WriteLine($"No se encontró ningún libro con el Id {id}.");
                return null;
            }

            Console.WriteLine("¡Libro encontrado!");
            Console.WriteLine(libros[indice]);
            return libros[indice];
        }

        // ---------------------------------------------------------
        // 4. Actualizar un libro
        // Complejidad: O(n) -- primero se busca el libro (O(n)) y
        // luego la modificación de sus datos es O(1).
        // ---------------------------------------------------------
        public bool ActualizarLibro(int id, string titulo, string genero, string autor, string isbn, int añoPublicacion, int numeroPaginas, bool disponible)
        {
            int indice = BuscarIndicePorId(id);

            if (indice == -1)
            {
                Console.WriteLine($"No se encontró ningún libro con el Id {id}.");
                return false;
            }

            libros[indice].Titulo = titulo;
            libros[indice].Genero = genero;
            libros[indice].Autor = autor;
            libros[indice].ISBN = isbn;
            libros[indice].AñoPublicacion = añoPublicacion;
            libros[indice].NumeroPaginas = numeroPaginas;
            libros[indice].Disponible = disponible;

            Console.WriteLine("¡Libro actualizado correctamente!");
            return true;
        }

        // ---------------------------------------------------------
        // 5. Eliminar un libro
        // Complejidad: O(n) -- buscar el libro es O(n) y, además,
        // desplazar los elementos posteriores para cerrar el hueco
        // también es O(n).
        // ---------------------------------------------------------
        public bool EliminarLibro(int id)
        {
            int indice = BuscarIndicePorId(id);

            if (indice == -1)
            {
                Console.WriteLine($"No se puede eliminar: no existe un libro con el Id {id}.");
                return false;
            }

            for (int i = indice; i < cantidadLibros - 1; i++)
            {
                libros[i] = libros[i + 1];
            }

            libros[cantidadLibros - 1] = null; 
            cantidadLibros--;

            Console.WriteLine("Libro eliminado correctamente :)");
            return true;
        }
    }
}