using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    // Diccionario que almacena las palabras en inglés como clave y su traducción en español como valor.
    static Dictionary<string, string> diccionario = new Dictionary<string, string>
    {
        {"time", "tiempo"},
        {"person", "persona"},
        {"year", "año"},
        {"way", "camino/forma"},
        {"day", "día"},
        {"thing", "cosa"},
        {"man", "hombre"},
        {"world", "mundo"},
        {"life", "vida"},
        {"hand", "mano"},
        {"part", "parte"},
        {"child", "niño/a"},
        {"eye", "ojo"},
        {"woman", "mujer"},
        {"place", "lugar"},
        {"work", "trabajo"},
        {"week", "semana"},
        {"case", "caso"},
        {"point", "punto/tema"},
        {"government", "gobierno"},
        {"company", "empresa/compañía"}
    };

    static void Main(string[] args)
    {
        // Mensaje de bienvenida con emojis.
        Console.WriteLine(" ¡Bienvenido al Diccionario de Inglés-Español! ");
        Console.WriteLine("=======================================================");

        // Bucle principal del programa que muestra el menú y procesa las opciones del usuario.
        while (true)
        {
            // Mostrar el menú de opciones.
            Console.WriteLine("\nMENU");
            Console.WriteLine("=======================================================");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Ingresar más palabras al diccionario");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            // Leer la opción seleccionada por el usuario.
            string opcion = Console.ReadLine() ?? ""; // Si es null, asigna una cadena vacía.

            // Procesar la opción seleccionada.
            if (opcion == "1")
            {
                // Si el usuario selecciona la opción 1, llamar a la función para traducir una frase.
                TraducirFrase();
            }
            else if (opcion == "2")
            {
                // Si el usuario selecciona la opción 2, llamar a la función para agregar una palabra al diccionario.
                AgregarPalabra();
            }
            else if (opcion == "0")
            {
                // Si el usuario selecciona la opción 0, salir del programa.
                Console.WriteLine("¡Gracias por usar el traductor! ¡Hasta luego!");
                break;
            }
            else
            {
                // Si el usuario ingresa una opción no válida, mostrar un mensaje de error.
                Console.WriteLine("Opción no válida. Intente de nuevo.");
            }
        }
    }

    static void TraducirFrase()
    {
        // Solicitar al usuario que ingrese una frase.
        Console.Write("Ingrese la frase: ");
        string frase = Console.ReadLine() ?? ""; // Si es null, asigna una cadena vacía.

        // Dividir la frase en palabras individuales usando el espacio como separador.
        // Se usa StringSplitOptions.RemoveEmptyEntries para evitar entradas vacías en el arreglo.
        string[] palabras = frase.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        // Variable para almacenar la frase traducida.
        string fraseTraducida = "";

        // Recorrer cada palabra de la frase.
        foreach (string palabra in palabras)
        {
            // Limpiar la palabra de caracteres especiales como puntos, comas, etc., y convertirla a minúsculas.
            string palabraLimpia = palabra.ToLower().Trim(new char[] { '.', ',', '!', '?' });

            // Verificar si la palabra está en el diccionario (inglés -> español).
            if (diccionario.ContainsKey(palabraLimpia))
            {
                // Si la palabra está en el diccionario, agregar su traducción a la frase traducida.
                fraseTraducida += diccionario[palabraLimpia] + " ";
            }
            // Verificar si la palabra es una traducción en español (español -> inglés).
            else if (diccionario.ContainsValue(palabraLimpia))
            {
                // Si la palabra es una traducción, buscar la clave correspondiente (inglés) y agregarla a la frase traducida.
                fraseTraducida += diccionario.FirstOrDefault(x => x.Value == palabraLimpia).Key + " ";
            }
            else
            {
                // Si la palabra no está en el diccionario, dejarla sin traducir.
                fraseTraducida += palabra + " ";
            }
        }

        // Mostrar la frase traducida al usuario.
        Console.WriteLine("Su frase traducida es: " + fraseTraducida.Trim());
    }

    static void AgregarPalabra()
    {
        // Solicitar al usuario que ingrese una palabra en inglés.
        Console.Write("Ingrese la palabra en inglés: ");
        string palabraIngles = Console.ReadLine()?.ToLower() ?? ""; // Si es null, asigna una cadena vacía.

        // Solicitar al usuario que ingrese la traducción en español.
        Console.Write("Ingrese la traducción en español: ");
        string palabraEspanol = Console.ReadLine()?.ToLower() ?? ""; // Si es null, asigna una cadena vacía.

        // Verificar si la palabra en inglés ya existe en el diccionario.
        if (!diccionario.ContainsKey(palabraIngles))
        {
            // Si no existe, agregar la palabra y su traducción al diccionario.
            diccionario.Add(palabraIngles, palabraEspanol);
            Console.WriteLine("Palabra agregada con éxito.");
        }
        else
        {
            // Si la palabra ya existe, mostrar un mensaje indicando que no se puede agregar.
            Console.WriteLine("La palabra ya existe en el diccionario.");
        }
    }
}