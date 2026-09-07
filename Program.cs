using Biblioteca.Models;
using Biblioteca.Services;

BibliotecaService biblioteca = new BibliotecaService();

bool continuar = true;

while (continuar)
{
    Console.Clear();

    
    Console.WriteLine("SISTEMA DE BIBLIOTECA");
    Console.WriteLine();
    Console.WriteLine("1. Registrar libro");
    Console.WriteLine("2. Registrar usuario");
    Console.WriteLine("3. Listar libros");
    Console.WriteLine("4. Buscar libro");
    Console.WriteLine("5. Eliminar libro");
    Console.WriteLine("6. Registrar préstamo");
    Console.WriteLine("7. Registrar devolución");
    Console.WriteLine("8. Ver libros disponibles");
    Console.WriteLine("9. Ver préstamos activos");
    Console.WriteLine("10. Ver libros ordenados");
    Console.WriteLine("11. Buscar por autor o categoría");
    Console.WriteLine("12. Salir");
    Console.WriteLine();
    Console.Write("Seleccione una opción: ");
    string? opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            RegistrarLibro();
            break;

        case "2":
            RegistrarUsuario();
            break;

        case "3":
            ListarLibros();
            break;

        case "4":
            BuscarLibro();
            break;

        case "5":
            EliminarLibro();
            break;

        case "6":
            RegistrarPrestamo();
            break;

        case "7":
            RegistrarDevolucion();
            break;

        case "8":
            ListarLibrosDisponibles();
            break;

        case "9":
            ListarPrestamosActivos();
            break;

        case "10":
            ListarLibrosOrdenados();
            break;

        case "11":
            BuscarPorAutorCategoria();
            break;

        case "12":
            continuar = false;
            Console.WriteLine("Saliendo del sistema...");
            break;

        default:
            Console.WriteLine("Opción no válida.");
            Console.WriteLine("Presione Enter para continuar.");
            Console.ReadLine();
            break;
    }
}

void RegistrarLibro()
{
    Console.Clear();

    Console.WriteLine("=== REGISTRAR LIBRO ===");

    try
    {
        Console.Write("Código: ");
        int codigo = int.Parse(Console.ReadLine()!);

        Console.Write("Título: ");
        string titulo = Console.ReadLine()!;

        Console.Write("Autor: ");
        string autor = Console.ReadLine()!;

        Console.Write("Categoría: ");
        string categoria = Console.ReadLine()!;

        Libro libro = new Libro(
            codigo,
            titulo,
            autor,
            categoria
        );

        biblioteca.RegistrarLibro(libro);

        Console.WriteLine();
        Console.WriteLine("Libro registrado correctamente.");
    }
    catch (Exception ex)
    {
        Console.WriteLine();
        Console.WriteLine($"Error: {ex.Message}");
    }

    Console.WriteLine();
    Console.WriteLine("Presione Enter para continuar.");
    Console.ReadLine();
}

void RegistrarUsuario()
{
    Console.Clear();

    Console.WriteLine("=== REGISTRAR USUARIO ===");

    try
    {
        Console.Write("ID: ");
        int id = int.Parse(Console.ReadLine()!);

        Console.Write("Nombre: ");
        string nombre = Console.ReadLine()!;

        Console.Write("Correo: ");
        string correo = Console.ReadLine()!;

        Usuario usuario = new Usuario(
            id,
            nombre,
            correo
        );

        biblioteca.RegistrarUsuario(usuario);

        Console.WriteLine();
        Console.WriteLine("Usuario registrado correctamente.");
    }
    catch (Exception ex)
    {
        Console.WriteLine();
        Console.WriteLine($"Error: {ex.Message}");
    }

    Console.WriteLine();
    Console.WriteLine("Presione Enter para continuar.");
    Console.ReadLine();
}

void ListarLibros()
{
    Console.Clear();

    Console.WriteLine("=== LISTA DE LIBROS ===");

    List<Libro> libros = biblioteca.ObtenerLibros();

    if (libros.Count == 0)
    {
        Console.WriteLine("No hay libros registrados.");
    }
    else
    {
        foreach (Libro libro in libros)
        {
            Console.WriteLine($"Código: {libro.Codigo}");
            Console.WriteLine($"Título: {libro.Titulo}");
            Console.WriteLine($"Autor: {libro.Autor}");
            Console.WriteLine($"Categoría: {libro.Categoria}");
            Console.WriteLine($"Disponible: {libro.Disponible}");
            Console.WriteLine("--------------------------------");
        }
    }

    Console.WriteLine();
    Console.WriteLine("Presione Enter para continuar.");
    Console.ReadLine();
}

void BuscarLibro()
{
    Console.Clear();

    Console.WriteLine("=== BUSCAR LIBRO ===");

    try
    {
        Console.Write("Ingrese el código del libro: ");
        int codigo = int.Parse(Console.ReadLine()!);

        Libro? libro = biblioteca.BuscarLibroPorCodigo(codigo);

        if (libro == null)
        {
            Console.WriteLine("No se encontró un libro con ese código.");
        }
        else
        {
            Console.WriteLine($"Código: {libro.Codigo}");
            Console.WriteLine($"Título: {libro.Titulo}");
            Console.WriteLine($"Autor: {libro.Autor}");
            Console.WriteLine($"Categoría: {libro.Categoria}");
            Console.WriteLine($"Disponible: {libro.Disponible}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }

    Console.WriteLine();
    Console.WriteLine("Presione Enter para continuar.");
    Console.ReadLine();
}

void EliminarLibro()
{
    Console.Clear();

    Console.WriteLine("=== ELIMINAR LIBRO ===");

    try
    {
        Console.Write("Ingrese el código del libro: ");
        int codigo = int.Parse(Console.ReadLine()!);

        Libro? libro = biblioteca.BuscarLibroPorCodigo(codigo);

        if (libro == null)
        {
            Console.WriteLine("No se encontró un libro con ese código.");
        }
        else
        {
            biblioteca.EliminarLibro(libro);
            Console.WriteLine("Libro eliminado correctamente.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }

    Console.WriteLine();
    Console.WriteLine("Presione Enter para continuar.");
    Console.ReadLine();
}

void RegistrarPrestamo()
{
    Console.Clear();

    Console.WriteLine("=== REGISTRAR PRÉSTAMO ===");

    try
    {
        Console.Write("Ingrese el código del libro: ");
        int codigoLibro = int.Parse(Console.ReadLine()!);

        Console.Write("Ingrese el ID del usuario: ");
        int idUsuario = int.Parse(Console.ReadLine()!);

        biblioteca.RegistrarPrestamo(codigoLibro, idUsuario);

        Console.WriteLine();
        Console.WriteLine("Préstamo registrado correctamente.");
    }
    catch (Exception ex)
    {
        Console.WriteLine();
        Console.WriteLine($"Error: {ex.Message}");
    }

    Console.WriteLine();
    Console.WriteLine("Presione Enter para continuar.");
    Console.ReadLine();
}

void RegistrarDevolucion()
{
    Console.Clear();

    Console.WriteLine("=== REGISTRAR DEVOLUCIÓN ===");

    try
    {
        Console.Write("Ingrese el código del libro: ");
        int codigoLibro = int.Parse(Console.ReadLine()!);

        biblioteca.RegistrarDevolucion(codigoLibro);

        Console.WriteLine();
        Console.WriteLine("Devolución registrada correctamente.");
    }
    catch (Exception ex)
    {
        Console.WriteLine();
        Console.WriteLine($"Error: {ex.Message}");
    }

    Console.WriteLine();
    Console.WriteLine("Presione Enter para continuar.");
    Console.ReadLine();
}

void ListarLibrosDisponibles()
{
    Console.Clear();

    Console.WriteLine("=== LIBROS DISPONIBLES ===");

    List<Libro> libros = biblioteca.ObtenerLibrosDisponibles();

    if (libros.Count == 0)
    {
        Console.WriteLine("No hay libros disponibles.");
    }
    else
    {
        foreach (Libro libro in libros)
        {
            Console.WriteLine(
                $"Código: {libro.Codigo} | " +
                $"Título: {libro.Titulo} | " +
                $"Autor: {libro.Autor}"
            );
        }
    }

    Console.WriteLine();
    Console.WriteLine("Presione Enter para continuar.");
    Console.ReadLine();
}

void ListarPrestamosActivos()
{
    Console.Clear();

    Console.WriteLine("=== PRÉSTAMOS ACTIVOS ===");

    List<string> prestamos = biblioteca.ObtenerDatosPrestamosActivos();

    if (prestamos.Count == 0)
    {
        Console.WriteLine("No hay préstamos activos.");
    }
    else
    {
        foreach (string prestamo in prestamos)
        {
            Console.WriteLine(prestamo);
        }
    }

    Console.WriteLine();
    Console.WriteLine("Presione Enter para continuar.");
    Console.ReadLine();
}

void ListarLibrosOrdenados()
{
    Console.Clear();

    Console.WriteLine("=== LIBROS ORDENADOS POR TÍTULO ===");

    List<Libro> libros = biblioteca.ObtenerLibrosOrdenados();

    if (libros.Count == 0)
    {
        Console.WriteLine("No hay libros registrados.");
    }
    else
    {
        foreach (Libro libro in libros)
        {
            Console.WriteLine(
                $"Código: {libro.Codigo} | " +
                $"Título: {libro.Titulo} | " +
                $"Autor: {libro.Autor}"
            );
        }
    }

    Console.WriteLine();
    Console.WriteLine("Presione Enter para continuar.");
    Console.ReadLine();
}

void BuscarPorAutorCategoria()
{
    Console.Clear();

    Console.WriteLine("=== BUSCAR POR AUTOR O CATEGORÍA ===");

    Console.Write("Ingrese autor o categoría: ");
    string texto = Console.ReadLine()!;

    List<Libro> libros = biblioteca.BuscarPorAutorOCategoria(texto);

    if (libros.Count == 0)
    {
        Console.WriteLine("No se encontraron libros.");
    }
    else
    {
        foreach (Libro libro in libros)
        {
            Console.WriteLine(
                $"Código: {libro.Codigo} | " +
                $"Título: {libro.Titulo} | " +
                $"Autor: {libro.Autor} | " +
                $"Categoría: {libro.Categoria}"
            );
        }
    }

    Console.WriteLine();
    Console.WriteLine("Presione Enter para continuar.");
    Console.ReadLine();
}