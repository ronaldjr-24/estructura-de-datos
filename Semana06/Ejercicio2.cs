
namespace RegistroEstudiantes
{
    // Clase que representa un estudiante
    public class Estudiante
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public double NotaDefinitiva { get; set; }
        public Estudiante Siguiente { get; set; } // Puntero al siguiente estudiante

        // Constructor
        public Estudiante(string cedula, string nombre, string apellido, string correo, double notaDefinitiva)
        {
            Cedula = cedula;
            Nombre = nombre;
            Apellido = apellido;
            Correo = correo;
            NotaDefinitiva = notaDefinitiva;
            Siguiente = null;
        }
    }

    // Clase que representa la lista enlazada de estudiantes
    public class ListaEstudiantes
    {
        private Estudiante cabeza;

        // Agregar estudiante a la lista
        public void AgregarEstudiante(Estudiante estudiante)
        {
            if (estudiante.NotaDefinitiva >= 6) // Aprobado
            {
                // Insertar al inicio
                estudiante.Siguiente = cabeza;
                cabeza = estudiante;
            }
            else // Reprobado
            {
                // Insertar al final
                if (cabeza == null)
                {
                    cabeza = estudiante;
                }
                else
                {
                    Estudiante actual = cabeza;
                    while (actual.Siguiente != null)
                    {
                        actual = actual.Siguiente;
                    }
                    actual.Siguiente = estudiante;
                }
            }
        }

        // Buscar estudiante por cédula
        public Estudiante BuscarEstudiante(string cedula)
        {
            Estudiante actual = cabeza;
            while (actual != null)
            {
                if (actual.Cedula == cedula)
                {
                    return actual;
                }
                actual = actual.Siguiente;
            }
            return null; // No encontrado
        }

        // Eliminar un estudiante por cédula
        public bool EliminarEstudiante(string cedula)
        {
            if (cabeza == null) return false;

            if (cabeza.Cedula == cedula) // Si es el primero
            {
                cabeza = cabeza.Siguiente;
                return true;
            }

            Estudiante actual = cabeza;
            while (actual.Siguiente != null)
            {
                if (actual.Siguiente.Cedula == cedula)
                {
                    actual.Siguiente = actual.Siguiente.Siguiente; // Eliminar
                    return true;
                }
                actual = actual.Siguiente;
            }
            return false; // No encontrado
        }

        // Contar estudiantes aprobados
        public int TotalAprobados()
        {
            int count = 0;
            Estudiante actual = cabeza;

            while (actual != null)
            {
                if (actual.NotaDefinitiva >= 6)
                {
                    count++;
                }
                actual = actual.Siguiente;
            }
            return count;
        }

        // Contar estudiantes reprobados
        public int TotalReprobados()
        {
            int count = 0;
            Estudiante actual = cabeza;

            while (actual != null)
            {
                if (actual.NotaDefinitiva < 6)
                {
                    count++;
                }
                actual = actual.Siguiente;
            }
            return count;
        }

        // Método para mostrar todos los estudiantes (opcional)
        public void MostrarEstudiantes()
        {
            Estudiante actual = cabeza;
            while (actual != null)
            {
                Console.WriteLine($"Cédula: {actual.Cedula}, Nombre: {actual.Nombre}, Apellido: {actual.Apellido}, Correo: {actual.Correo}, Nota: {actual.NotaDefinitiva}");
                actual = actual.Siguiente;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ListaEstudiantes listaEstudiantes = new ListaEstudiantes();

            // Ejemplo de uso del programa:
            
            listaEstudiantes.AgregarEstudiante(new Estudiante("12345678", "Juan", "Pérez", "juan.perez@example.com", 8.5));
            listaEstudiantes.AgregarEstudiante(new Estudiante("87654321", "Ana", "García", "ana.garcia@example.com", 5.0));
            
            Console.WriteLine("Total Aprobados: " + listaEstudiantes.TotalAprobados());
            Console.WriteLine("Total Reprobados: " + listaEstudiantes.TotalReprobados());

            listaEstudiantes.MostrarEstudiantes();
            
            var buscado = listaEstudiantes.BuscarEstudiante("12345678");
            if (buscado != null)
                Console.WriteLine($"Estudiante encontrado: {buscado.Nombre} {buscado.Apellido}");
            
            listaEstudiantes.EliminarEstudiante("12345678");
            
            Console.WriteLine("Después de eliminar:");
            listaEstudiantes.MostrarEstudiantes();
            
            Console.ReadKey();
        }
    }
}
