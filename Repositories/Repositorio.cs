namespace Biblioteca.Repositories;

using Biblioteca.Interfaces;

public class Repositorio<T> : IRepositorio<T>
{
    private List<T> elementos = new List<T>();

    public void Agregar(T elemento)
    {
        elementos.Add(elemento);
    }

    public void Eliminar(T elemento)
    {
        elementos.Remove(elemento);
    }

    public List<T> ObtenerTodos()
    {
        return elementos;
    }
}