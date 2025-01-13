// Clase que representa una asignatura
class Asignatura
{
    // Propiedad que almacena el nombre de la asignatura
    public string Nombre { get; set; }

    // Constructor de la clase Asignatura
    public Asignatura(string nombre)
    {
        Nombre = nombre;
    }
}

// Clase que representa un curso
class Curso
{
    // Lista que almacena las asignaturas del curso
    private List<Asignatura> asignaturas;

    // Constructor de la clase Curso
    public Curso()
    {
        asignaturas = new List<Asignatura>(); // Inicializa la lista de asignaturas
    }

    // Método para agregar una nueva asignatura al curso
    public void AgregarAsignatura(Asignatura asignatura)
    {
        asignaturas.Add(asignatura); // Agrega la asignatura a la lista
    }

    // Método para mostrar las asignaturas del curso
    public void MostrarAsignaturas()
    {
        foreach (var asignatura in asignaturas) // Recorre cada asignatura en la lista
        {
            Console.WriteLine($"Yo estudio {asignatura.Nombre}."); // Muestra el mensaje con el nombre de la asignatura
        }
    }
}

// Clase principal que contiene el método Main
class Program
{
    static void Main(string[] args)
    {
        Curso curso = new Curso(); // Crea una nueva instancia de Curso

        // Agrega algunas asignaturas al curso
        curso.AgregarAsignatura(new Asignatura("Matemáticas"));
        curso.AgregarAsignatura(new Asignatura("Física"));
        curso.AgregarAsignatura(new Asignatura("Química"));
        curso.AgregarAsignatura(new Asignatura("Historia"));
        curso.AgregarAsignatura(new Asignatura("Lengua"));

        // Muestra las asignaturas del curso
        curso.MostrarAsignaturas();
        
        // Espera a que el usuario presione una tecla antes de cerrar
        Console.WriteLine("Presione cualquier tecla para salir...");
        Console.ReadKey();
    }
}