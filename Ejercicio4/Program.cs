using System; // Importa el espacio de nombres System para utilizar funcionalidades básicas
using System.Collections.Generic; // Importa el espacio de nombres para utilizar listas genéricas

class Program
{
    static void Main(string[] args)
    {
        // Crea una lista de enteros para almacenar los números ganadores
        List<int> numerosGanadores = new List<int>();
        string entrada; // Variable para almacenar la entrada del usuario

        // Pregunta al usuario cuántos números desea ingresar
        Console.Write("¿Cuántos números ganadores desea ingresar? ");
        int cantidadNumeros;

        // Intenta convertir la entrada a un número entero
        while (!int.TryParse(Console.ReadLine(), out cantidadNumeros) || cantidadNumeros <= 0)
        {
            Console.WriteLine("Por favor, ingrese un número válido mayor que 0.");
        }

        // Bucle para ingresar los números ganadores
        for (int i = 0; i < cantidadNumeros; i++)
        {
            Console.Write($"Ingrese el número ganador #{i + 1}: "); // Solicita el número al usuario
            entrada = Console.ReadLine(); // Lee la entrada del usuario

            // Intenta convertir la entrada a un número entero
            if (int.TryParse(entrada, out int numero))
            {
                numerosGanadores.Add(numero); // Agrega el número a la lista
            }
            else
            {
                Console.WriteLine("Entrada no válida. Se ignorará este número."); // Mensaje de error si la entrada no es válida
                i--; // Decrementa el contador para volver a pedir el número
            }
        }

        // Ordena la lista de números ganadores de menor a mayor
        numerosGanadores.Sort();

        // Muestra los números ganadores ordenados por pantalla
        Console.WriteLine("\nNúmeros ganadores ordenados:");
        foreach (var numero in numerosGanadores) // Itera sobre cada número en la lista
        {
            Console.WriteLine(numero); // Imprime el número actual
        }

        // Espera a que el usuario presione una tecla antes de cerrar la consola
        Console.WriteLine("\nPresione cualquier tecla para salir...");
        Console.ReadKey();
    }
}
