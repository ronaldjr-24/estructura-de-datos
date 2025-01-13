using System; // Importa el espacio de nombres System para utilizar funcionalidades básicas
using System.Collections.Generic; // Importa el espacio de nombres para utilizar listas genéricas

class Program
{
    static void Main(string[] args)
    {
        // Crea una lista de enteros para almacenar los números del 1 al 10
        List<int> numeros = new List<int>();

        // Bucle para agregar los números del 1 al 10 a la lista
        for (int i = 1; i <= 10; i++)
        {
            numeros.Add(i); // Agrega el número actual a la lista
        }

        // Muestra los números en orden inverso separados por comas
        Console.WriteLine("Números del 1 al 10 en orden inverso:");

        // Utiliza un bucle for para iterar sobre la lista en orden inverso
        for (int i = numeros.Count - 1; i >= 0; i--) // Comienza desde el último índice hasta el primero
        {
            // Imprime el número actual. Si no es el primer número, agrega una coma antes.
            if (i < numeros.Count - 1)
            {
                Console.Write(", "); // Agrega una coma antes de imprimir si no es el primer número
            }
            Console.Write(numeros[i]); // Imprime el número actual
        }

        // Salto de línea después de mostrar los números
        Console.WriteLine(); 

        // Espera a que el usuario presione una tecla antes de cerrar la consola
        Console.WriteLine("Presione cualquier tecla para salir...");
        Console.ReadKey();
    }
}
