using SistemaGestionBiblioteca;

Biblioteca biblioteca = new Biblioteca();

void CargarDatosIniciales()
{
    biblioteca.AgregarLibro(new Libro(0, "El Hobbit", "Fantasía", "J.R.R. Tolkien", "978-0547928227", 1937, 310));
    biblioteca.AgregarLibro(new Libro(0, "La Sombra del Viento", "Misterio", "Carlos Ruiz Zafón", "978-8408172174", 2001, 565));
    biblioteca.AgregarLibro(new Libro(0, "El Código Da Vinci", "Thriller", "Dan Brown", "978-0307474278", 2003, 489));
    biblioteca.AgregarLibro(new Libro(0, "Orgullo y Prejuicio", "Romance", "Jane Austen", "978-1503290563", 1813, 279));
    biblioteca.AgregarLibro(new Libro(0, "Matar a un Ruiseñor", "Drama", "Harper Lee", "978-0061120084", 1960, 281));
    biblioteca.AgregarLibro(new Libro(0, "Rayuela", "Novela", "Julio Cortázar", "978-8437604572", 1963, 736));
    biblioteca.AgregarLibro(new Libro(0, "La Casa de los Espíritus", "Novela", "Isabel Allende", "978-0525433454", 1982, 448));
    biblioteca.AgregarLibro(new Libro(0, "Fahrenheit 451", "Ciencia Ficción", "Ray Bradbury", "978-1451673319", 1953, 256));
    biblioteca.AgregarLibro(new Libro(0, "El Túnel", "Novela", "Ernesto Sábato", "978-8432217580", 1948, 152));
    biblioteca.AgregarLibro(new Libro(0, "Pedro Páramo", "Novela", "Juan Rulfo", "978-0802133908", 1955, 124));
}

CargarDatosIniciales();
int opcion;

do
{
    Console.WriteLine("\n====== SISTEMA DE BIBLIOTECA ======");
    Console.WriteLine("1. Agregar libro");
    Console.WriteLine("2. Listar libros");
    Console.WriteLine("3. Buscar libro por ID");
    Console.WriteLine("4. Actualizar libro");
    Console.WriteLine("5. Eliminar libro");
    Console.WriteLine("0. Salir");
    Console.Write("\nSeleccione una opción: ");

    string entrada = Console.ReadLine();

    if (!int.TryParse(entrada, out opcion))
    {
        Console.WriteLine("Opción inválida. Ingrese un número.");
        continue;
    }

    switch (opcion)
    {
        case 1:
            AgregarLibro();
            break;
        case 2:
            biblioteca.ListarLibros();
            break;
        case 3:
            BuscarLibro();
            break;
        case 4:
            ActualizarLibro();
            break;
        case 5:
            EliminarLibro();
            break;
        case 0:
            Console.WriteLine("Saliendo del sistema...");
            break;
        default:
            Console.WriteLine("Opción no válida. Intente de nuevo.");
            break;
    }

} while (opcion != 0);

void AgregarLibro()
{
    if (biblioteca.CantidadLibros >= biblioteca.CapacidadMaxima)
    {
        Console.WriteLine("No se puede agregar el libro: el catálogo alcanzó su capacidad máxima (20 libros).");
        return;
    }

    Console.Write("Título: ");
    string titulo = Console.ReadLine();
    Console.Write("Género: ");
    string genero = Console.ReadLine();
    Console.Write("Autor: ");
    string autor = Console.ReadLine();
    Console.Write("ISBN: ");
    string isbn = Console.ReadLine();
    Console.Write("Año de publicación: ");
    int año = int.Parse(Console.ReadLine());
    Console.Write("Número de páginas: ");
    int paginas = int.Parse(Console.ReadLine());

    Libro nuevoLibro = new Libro(0, titulo, genero, autor, isbn, año, paginas);
    biblioteca.AgregarLibro(nuevoLibro);
    Console.WriteLine($"¡Libro agregado exitosamente! '{nuevoLibro.Titulo}' ha sido registrado con el ID {nuevoLibro.Id}.");
}

void BuscarLibro()
{
    Console.Write("Ingrese el Id del libro a buscar: ");
    int id = int.Parse(Console.ReadLine());
    biblioteca.BuscarLibroPorId(id);
}

void ActualizarLibro()
{
    Console.Write("Ingrese el Id del libro a actualizar: ");
    int id = int.Parse(Console.ReadLine());

    Libro existente = biblioteca.BuscarLibroPorId(id);
    if (existente == null) return;

    Console.Write("Nuevo título: ");
    string titulo = Console.ReadLine();
    Console.Write("Nuevo género: ");
    string genero = Console.ReadLine();
    Console.Write("Nuevo autor: ");
    string autor = Console.ReadLine();
    Console.Write("Nuevo ISBN: ");
    string isbn = Console.ReadLine();
    Console.Write("Nuevo año de publicación: ");
    int año = int.Parse(Console.ReadLine());
    Console.Write("Nuevo número de páginas: ");
    int paginas = int.Parse(Console.ReadLine());
    Console.Write("¿Disponible? (s/n): ");
    bool disponible = Console.ReadLine().Trim().ToLower() == "s";

    biblioteca.ActualizarLibro(id, titulo, genero, autor, isbn, año, paginas, disponible);
}

void EliminarLibro()
{
    Console.Write("Ingrese el Id del libro a eliminar: ");
    int id = int.Parse(Console.ReadLine());
    biblioteca.EliminarLibro(id);
}