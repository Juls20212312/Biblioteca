using Biblioteca.Models;

namespace Biblioteca.Services;

public class BibliotecaService
{
    private List<Libro> libros = new List<Libro>();
    private List<Usuario> usuarios = new List<Usuario>();
    private List<Prestamo> prestamos = new List<Prestamo>();

    public void RegistrarLibro(Libro libro)
    {
        if (libros.Any(l => l.Codigo == libro.Codigo))
        {
            throw new Exception("Ya existe un libro con ese código.");
        }

        libros.Add(libro);
    }

    public void RegistrarUsuario(Usuario usuario)
    {
        if (usuarios.Any(u => u.Id == usuario.Id))
        {
            throw new Exception("Ya existe un usuario con ese ID.");
        }

        usuarios.Add(usuario);
    }

    public List<Libro> ObtenerLibros()
    {
        return libros;
    }

    public List<Usuario> ObtenerUsuarios()
    {
        return usuarios;
    }

    public List<Prestamo> ObtenerPrestamos()
    {
        return prestamos;
    }
    public void EliminarLibro(Libro libro)
    {
        libros.Remove(libro);
    }

    public void RegistrarPrestamo(int codigoLibro, int idUsuario)
    {
    Libro? libro = libros.FirstOrDefault(l => l.Codigo == codigoLibro);

    if (libro == null)
    {
        throw new Exception("El libro no existe.");
    }

    if (!libro.Disponible)
    {
        throw new Exception("El libro no está disponible.");
    }

    Usuario? usuario = usuarios.FirstOrDefault(u => u.Id == idUsuario);

    if (usuario == null)
    {
        throw new Exception("El usuario no existe.");
    }

    Prestamo prestamo = new Prestamo(
        codigoLibro,
        idUsuario,
        DateTime.Now,
        null
    );

    prestamos.Add(prestamo);

    libro.Prestar();
    }

    public void RegistrarDevolucion(int codigoLibro)
    {
    Libro? libro = libros.FirstOrDefault(l => l.Codigo == codigoLibro);

    if (libro == null)
    {
        throw new Exception("El libro no existe.");
    }

    Prestamo? prestamo = prestamos
        .FirstOrDefault(p => p.CodigoLibro == codigoLibro && p.FechaDevolucion == null);

    if (prestamo == null)
    {
        throw new Exception("No existe un préstamo activo para este libro.");
    }

    int posicion = prestamos.IndexOf(prestamo);

    prestamos[posicion] = prestamo with
    {
        FechaDevolucion = DateTime.Now
    };

    libro.Devolver();
    }
    public List<Libro> ObtenerLibrosDisponibles()
    {
    return libros
        .Where(l => l.Disponible)
        .ToList();
    }
    public List<Libro> ObtenerLibrosOrdenados()
    {
    return libros
        .OrderBy(l => l.Titulo)
        .ToList();
    }
    public List<Libro> BuscarPorAutorOCategoria(string texto)
    {
    return libros
        .Where(l =>
            l.Autor.Contains(texto, StringComparison.OrdinalIgnoreCase) ||
            l.Categoria.Contains(texto, StringComparison.OrdinalIgnoreCase))
        .ToList();
    }
    public Libro? BuscarLibroPorCodigo(int codigo)
    {
    return libros.FirstOrDefault(l => l.Codigo == codigo);
    }
    public List<Prestamo> ObtenerPrestamosActivos()
    {
    return prestamos
        .Where(p => p.FechaDevolucion == null)
        .ToList();
    }
    
    public List<string> ObtenerDatosPrestamosActivos()
    {
    return prestamos
        .Where(p => p.FechaDevolucion == null)
        .Select(p => $"Libro: {p.CodigoLibro} | Usuario: {p.IdUsuario} | Fecha: {p.FechaPrestamo}")
        .ToList();
    }
}