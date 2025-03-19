class Campaña_de_Vacunación
{
    static void Main()
    {
        // Llamada al método para mostrar la portada
        MostrarPortada();

        // Lista de nombres para asignar a los ciudadanos
        List<string> nombres = new List<string>
        {
            "Juan Pérez", "María López", "Carlos Gómez", "Ana Torres", "Luis Ramírez",
            "Sofía Herrera", "Pedro Castillo", "Gabriela Muñoz", "Ricardo Vargas", "Elena Ríos",
            "José Navarro", "Marta Castro", "Daniel Salazar", "Carmen Ortega", "Fernando Méndez",
            "Laura Acosta", "Alejandro Paredes", "Paola Serrano", "Miguel Espinoza", "Johnny Grefa"
        };

        // Creación de un diccionario que almacena los ciudadanos con un identificador único
        Dictionary<int, string> ciudadanos = new Dictionary<int, string>();
        for (int i = 1; i <= 500; i++)
        {
            string nombre = nombres[i % nombres.Count] + $" #{i}"; // Se asigna un nombre repetido con un número único
            ciudadanos.Add(i, nombre);
        }

        // Conjunto de ciudadanos vacunados con Pfizer
        HashSet<int> vacunadosPfizer = new HashSet<int>(Enumerable.Range(1, 75));

        // Conjunto de ciudadanos vacunados con AstraZeneca (algunos coinciden con Pfizer)
        HashSet<int> vacunadosAstraZeneca = new HashSet<int>(Enumerable.Range(50, 75));

        // Clasificación de ciudadanos según su estado de vacunación
        Dictionary<string, List<int>> categorias = new Dictionary<string, List<int>>
        {
            { "No vacunados", ciudadanos.Keys.Except(vacunadosPfizer).Except(vacunadosAstraZeneca).ToList() },
            { "Vacunados con ambas dosis", vacunadosPfizer.Intersect(vacunadosAstraZeneca).ToList() },
            { "Solo vacunados con Pfizer", vacunadosPfizer.Except(vacunadosAstraZeneca).ToList() },
            { "Solo vacunados con AstraZeneca", vacunadosAstraZeneca.Except(vacunadosPfizer).ToList() }
        };

        // Mostrar el número total de ciudadanos registrados
        Console.WriteLine("================================================================\n");
        Console.WriteLine($"TOTAL DE CIUDADANOS REGISTRADOS: {ciudadanos.Count}");
        Console.WriteLine("================================================================\n");

        // Mostrar información detallada de cada categoría
        foreach (var categoria in categorias)
        {
            MostrarCantidadCiudadanos(categoria.Key, categoria.Value.Count);
            MostrarPrimerosDiez(categoria.Key, categoria.Value, ciudadanos);
        }
    }

    // Método para mostrar la portada con los detalles de la actividad
    static void MostrarPortada()
    {
        Console.WriteLine("===================================================================\n ");
        Console.WriteLine("              UNIVERSIDAD ESTATAL AMAZÓNICA           ");
        Console.WriteLine("===================================================================\n ");
        Console.WriteLine("              Materia: Estructura de Datos          ");
        Console.WriteLine("              Docente: ing Delfin Ortega");
        Console.WriteLine("              Estudiante: salazar ajon ronald javier");
        Console.WriteLine("===================================================================\n ");
        Console.WriteLine("             Análisis sobre la Campaña de Vacunación COVID-19");
        Console.WriteLine("             Facultad de Ciencias de la Vida       ");
        Console.WriteLine("             Fecha: 18 de Marzo de 2025         ");
        Console.WriteLine("===================================================================\n");
        Console.WriteLine("              Paralelo C                ");
        Console.WriteLine("===================================================================\n");
    }

    // Método para mostrar cuántos ciudadanos pertenecen a cada categoría
    static void MostrarCantidadCiudadanos(string categoria, int cantidad)
    {
        Console.WriteLine($"{categoria}: {cantidad} ciudadanos\n");
    }

    // Método que muestra los primeros 10 ciudadanos de cada grupo con su nombre
    static void MostrarPrimerosDiez(string categoria, List<int> lista, Dictionary<int, string> ciudadanos)
    {
        Console.WriteLine($"\nPrimeros 10 ciudadanos en la categoría '{categoria}':");
        foreach (var id in lista.Take(10))
        {
            Console.WriteLine($"ID: {id}, Nombre: {ciudadanos[id]}");
        }
        Console.WriteLine("------------------------------------------------------\n");
    }
}
