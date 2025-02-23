using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Generar lista de 500 ciudadanos
        List<string> ciudadanos = GenerarCiudadanos(500);

        // Seleccionar 75 ciudadanos vacunados con Pfizer
        List<string> vacunadosPfizer = SeleccionarAleatorios(ciudadanos, 75);

        // Seleccionar 75 ciudadanos vacunados con AstraZeneca (sin repetir con Pfizer)
        List<string> ciudadanosRestantes = ciudadanos.Except(vacunadosPfizer).ToList();
        List<string> vacunadosAstraZeneca = SeleccionarAleatorios(ciudadanosRestantes, 75);

        // Obtener listas según su estado de vacunación
        List<string> noVacunados = ciudadanos.Except(vacunadosPfizer).Except(vacunadosAstraZeneca).ToList();
        List<string> vacunadosAmbas = vacunadosPfizer.Intersect(vacunadosAstraZeneca).ToList();
        List<string> soloPfizer = vacunadosPfizer.Except(vacunadosAstraZeneca).ToList();
        List<string> soloAstraZeneca = vacunadosAstraZeneca.Except(vacunadosPfizer).ToList();

        // Mostrar resultados en la consola
        MostrarResultados(noVacunados, vacunadosAmbas, soloPfizer, soloAstraZeneca);
    }

    static List<string> GenerarCiudadanos(int cantidad)
    {
        return Enumerable.Range(1, cantidad).Select(i => $"Ciudadano {i}").ToList();
    }

    static List<string> SeleccionarAleatorios(List<string> lista, int cantidad)
    {
        return lista.OrderBy(_ => Guid.NewGuid()).Take(cantidad).ToList();
    }

    static void MostrarResultados(List<string> noVacunados, List<string> vacunadosAmbas, List<string> soloPfizer, List<string> soloAstraZeneca)
    {
        Console.WriteLine("=== Resultados de la Vacunación COVID-19 ===\n");

        MostrarLista("Ciudadanos que NO se han vacunado", noVacunados);
        MostrarLista("Ciudadanos que han recibido AMBAS vacunas (Pfizer y AstraZeneca)", vacunadosAmbas);
        MostrarLista("Ciudadanos que SOLO han recibido la vacuna de Pfizer", soloPfizer);
        MostrarLista("Ciudadanos que SOLO han recibido la vacuna de AstraZeneca", soloAstraZeneca);

        Console.WriteLine("\n¡Proceso finalizado!");
    }

    static void MostrarLista(string titulo, List<string> lista)
    {
        Console.WriteLine($"{titulo}: {lista.Count} personas");
        foreach (var ciudadano in lista) Console.WriteLine($" - {ciudadano}");
        Console.WriteLine();
    }
}
