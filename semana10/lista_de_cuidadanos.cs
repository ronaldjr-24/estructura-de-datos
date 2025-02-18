using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // 1. Generar un conjunto ficticio de 500 ciudadanos
        List<string> ciudadanos = GenerarListaDeCiudadanos(500);

        // 2. Generar un conjunto ficticio de 75 ciudadanos vacunados con Pfizer
        List<string> vacunadosPfizer = SeleccionarAleatorios(ciudadanos, 75);

        // 3. Generar un conjunto ficticio de 75 ciudadanos vacunados con AstraZeneca
        // Asegurarse de que no se repitan con los vacunados de Pfizer
        List<string> ciudadanosRestantes = ciudadanos.Except(vacunadosPfizer).ToList();
        List<string> vacunadosAstraZeneca = SeleccionarAleatorios(ciudadanosRestantes, 75);

        // 4. Obtener el listado de ciudadanos que no se han vacunado
        List<string> noVacunados = ciudadanos.Except(vacunadosPfizer).Except(vacunadosAstraZeneca).ToList();

        // 5. Obtener el listado de ciudadanos que han recibido las dos vacunas
        // En este caso, como los grupos son disjuntos, no habrá ciudadanos con ambas vacunas
        List<string> vacunadosAmbas = vacunadosPfizer.Intersect(vacunadosAstraZeneca).ToList();

        // 6. Obtener el listado de ciudadanos que solo han recibido Pfizer
        List<string> soloPfizer = vacunadosPfizer.Except(vacunadosAstraZeneca).ToList();

        // 7. Obtener el listado de ciudadanos que solo han recibido AstraZeneca
        List<string> soloAstraZeneca = vacunadosAstraZeneca.Except(vacunadosPfizer).ToList();

        // 8. Mostrar los resultados en la consola
        MostrarResultadosEnConsola(noVacunados, vacunadosAmbas, soloPfizer, soloAstraZeneca);

        // 9. Generar un reporte en formato de texto
        GenerarReporte(noVacunados, vacunadosAmbas, soloPfizer, soloAstraZeneca);

        Console.WriteLine("\n¡Reporte generado con éxito! Revisa el archivo 'ReporteVacunacion.txt'.");
    }

    // Método para generar una lista de ciudadanos ficticios
    static List<string> GenerarListaDeCiudadanos(int cantidad)
    {
        List<string> ciudadanos = new List<string>();
        for (int i = 1; i <= cantidad; i++)
        {
            ciudadanos.Add($"Ciudadano {i}");
        }
        return ciudadanos;
    }

    // Método para seleccionar elementos aleatorios de una lista
    static List<string> SeleccionarAleatorios(List<string> lista, int cantidad)
    {
        Random random = new Random();
        return lista.OrderBy(x => random.Next()).Take(cantidad).ToList();
    }

    // Método para mostrar los resultados en la consola
    static void MostrarResultadosEnConsola(List<string> noVacunados, List<string> vacunadosAmbas, List<string> soloPfizer, List<string> soloAstraZeneca)
    {
        Console.WriteLine("=== Resultados de la Vacunación COVID-19 ===");
        Console.WriteLine();

        Console.WriteLine("Ciudadanos que NO se han vacunado:");
        foreach (var ciudadano in noVacunados)
        {
            Console.WriteLine(ciudadano);
        }
        Console.WriteLine();

        Console.WriteLine("Ciudadanos que han recibido AMBAS vacunas (Pfizer y AstraZeneca):");
        foreach (var ciudadano in vacunadosAmbas)
        {
            Console.WriteLine(ciudadano);
        }
        Console.WriteLine();

        Console.WriteLine("Ciudadanos que SOLO han recibido la vacuna de Pfizer:");
        foreach (var ciudadano in soloPfizer)
        {
            Console.WriteLine(ciudadano);
        }
        Console.WriteLine();

        Console.WriteLine("Ciudadanos que SOLO han recibido la vacuna de AstraZeneca:");
        foreach (var ciudadano in soloAstraZeneca)
        {
            Console.WriteLine(ciudadano);
        }
        Console.WriteLine();
    }

    // Método para generar un reporte en un archivo de texto
    static void GenerarReporte(List<string> noVacunados, List<string> vacunadosAmbas, List<string> soloPfizer, List<string> soloAstraZeneca)
    {
        using (StreamWriter writer = new StreamWriter("ReporteVacunacion.txt"))
        {
            writer.WriteLine("=== Reporte de Vacunación COVID-19 ===");
            writer.WriteLine();

            writer.WriteLine("Ciudadanos que NO se han vacunado:");
            foreach (var ciudadano in noVacunados)
            {
                writer.WriteLine(ciudadano);
            }
            writer.WriteLine();

            writer.WriteLine("Ciudadanos que han recibido AMBAS vacunas (Pfizer y AstraZeneca):");
            foreach (var ciudadano in vacunadosAmbas)
            {
                writer.WriteLine(ciudadano);
            }
            writer.WriteLine();

            writer.WriteLine("Ciudadanos que SOLO han recibido la vacuna de Pfizer:");
            foreach (var ciudadano in soloPfizer)
            {
                writer.WriteLine(ciudadano);
            }
            writer.WriteLine();

            writer.WriteLine("Ciudadanos que SOLO han recibido la vacuna de AstraZeneca:");
            foreach (var ciudadano in soloAstraZeneca)
            {
                writer.WriteLine(ciudadano);
            }
        }
    }
}