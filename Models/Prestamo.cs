namespace Biblioteca.Models;

public record Prestamo(
    int CodigoLibro,
    int IdUsuario,
    DateTime FechaPrestamo,
    DateTime? FechaDevolucion
);