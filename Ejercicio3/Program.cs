using System; // Importa el espacio de nombres System para utilizar funcionalidades básicas
using System.Collections.Generic; // Importa el espacio de nombres para utilizar listas genéricas

class Program
{
    static void Main(string[] args)
    {
        // Crea una lista de cadenas para almacenar las asignaturas
        List<string> asignaturas = new List<string>
        {
            "Matemáticas",
            "Física",
            "Química",
            "Historia",
            "Lengua"
        };

        // Crea un diccionario para almacenar las notas correspondientes a cada asignatura
        Dictionary<string, double> notas = new Dictionary<string, double>();

        // Pregunta al usuario la nota para cada asignatura
        foreach (var asignatura in asignaturas) // Itera sobre cada asignatura en la lista
        {
            Console.Write($"¿Qué nota has sacado en {asignatura}? "); // Solicita la nota al usuario
            string entradaNota = Console.ReadLine(); // Lee la entrada del usuario

            // Intenta convertir la entrada a un número decimal
            if (double.TryParse(entradaNota, out double nota))
            {
                notas[asignatura] = nota; // Almacena la nota en el diccionario con la asignatura como clave
            }
            else
            {
                Console.WriteLine("Entrada no válida. Se almacenará la nota como 0."); // Mensaje de error si la entrada no es válida
                notas[asignatura] = 0; // Almacena 0 si la entrada es inválida
            }
        }

        // Muestra las asignaturas y sus respectivas notas
        Console.WriteLine("\nResultados:");
        foreach (var asignatura in asignaturas) // Itera sobre cada asignatura nuevamente
        {
            if (notas.TryGetValue(asignatura, out double nota)) // Intenta obtener la nota del diccionario
            {
                Console.WriteLine($"En {asignatura} has sacado {nota}."); // Imprime el resultado
            }
        }

        // Espera a que el usuario presione una tecla antes de cerrar la consola
        Console.WriteLine("\nPresione cualquier tecla para salir...");
        Console.ReadKey();
    }
}
