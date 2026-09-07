using Biblioteca.Interfaces;
namespace Biblioteca.Models;

public class Libro : IPrestable
{
    public int Codigo { get; set; }
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public string Categoria { get; set; }
    public bool Disponible { get; set; }

    public Libro(int codigo, string titulo, string autor, string categoria)
    {
        Codigo = codigo;
        Titulo = titulo;
        Autor = autor;
        Categoria = categoria;
        Disponible = true;
    }
    public void Prestar()
    {
    if (!Disponible)
    {
        throw new Exception("El libro no está disponible.");
    }

    Disponible = false;
    }

    public void Devolver()
    {
    if (Disponible)
    {
        throw new Exception("El libro ya está disponible.");
    }

    Disponible = true;
    }
}