using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Universidad Estatal Amazónica");
        Console.WriteLine("Estructura de Datos");
        Console.WriteLine("Ronald Salazar");
        Console.WriteLine();
        Console.WriteLine("=================== Diccionario ===================");

        // Diccionario con palabras en inglés-español y español-inglés
        Dictionary<string, string> traductor = new Dictionary<string, string>
        {
            {"time", "tiempo"}, {"tiempo", "time"},
            {"person", "persona"}, {"persona", "person"},
            {"year", "año"}, {"año", "year"},
            {"way", "camino"}, {"camino", "way"},
            {"day", "día"}, {"día", "day"},
            {"thing", "cosa"}, {"cosa", "thing"},
            {"man", "hombre"}, {"hombre", "man"},
            {"world", "mundo"}, {"mundo", "world"},
            {"life", "vida"}, {"vida", "life"},
            {"hand", "mano"}, {"mano", "hand"},
            {"part", "parte"}, {"parte", "part"},
            {"child", "niño"}, {"niño", "child"}, {"niña", "child"},
            {"eye", "ojo"}, {"ojo", "eye"},
            {"woman", "mujer"}, {"mujer", "woman"},
            {"place", "lugar"}, {"lugar", "place"},
            {"work", "trabajo"}, {"trabajo", "work"},
            {"week", "semana"}, {"semana", "week"},
            {"case", "caso"}, {"caso", "case"},
            {"point", "punto"}, {"punto", "point"},
            {"government", "gobierno"}, {"gobierno", "government"},
            {"company", "empresa"}, {"empresa", "company"}, {"compañía", "company"}
        };

        int opcion;
        do
        {
            Console.WriteLine("\nMenú:");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Ingresar más palabras al diccionario");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    TraducirFrase(traductor);
                    break;
                case 2:
                    AgregarPalabras(traductor);
                    break;
                case 0:
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
            }

        } while (opcion != 0);
    }

    // Método para traducir una frase
    static void TraducirFrase(Dictionary<string, string> traductor)
    {
        Console.Write("\nIngrese la frase: ");
        string frase = Console.ReadLine().ToLower();

        // Reemplazar signos de puntuación por espacios
        string[] palabras = frase.Split(new char[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

        Console.Write("\nSu frase traducida es: ");
        foreach (var palabra in palabras)
        {
            if (traductor.ContainsKey(palabra))
            {
                Console.Write(traductor[palabra] + " ");
            }
            else
            {
                Console.Write(palabra + " ");
            }
        }
        Console.WriteLine();
    }

    // Método para agregar palabras al diccionario
    static void AgregarPalabras(Dictionary<string, string> traductor)
    {
        Console.Write("\nIngrese la palabra en español: ");
        string palabraEsp = Console.ReadLine().ToLower();

        Console.Write("Ingrese la traducción en inglés: ");
        string palabraIng = Console.ReadLine().ToLower();

        if (!traductor.ContainsKey(palabraEsp))
        {
            traductor.Add(palabraEsp, palabraIng);
            traductor.Add(palabraIng, palabraEsp); // Agrega la traducción en ambos sentidos
            Console.WriteLine("Palabra agregada correctamente.");
        }
        else
        {
            Console.WriteLine("La palabra ya existe en el diccionario.");
        }
    }
}


