using System;

class TorresDeHanoi
{
    // Método recursivo para resolver el problema de las Torres de Hanoi
    static void ResolverTorres(int n, char origen, char destino, char auxiliar)
    {
        // Caso base: si solo hay un disco, lo movemos directamente
        if (n == 1)
        {
            Console.WriteLine($"Mover disco 1 de {origen} a {destino}");
            return;
        }

        // Mover n-1 discos de origen a auxiliar
        ResolverTorres(n - 1, origen, auxiliar, destino);

        // Mover el disco restante de origen a destino
        Console.WriteLine($"Mover disco {n} de {origen} a {destino}");

        // Mover los n-1 discos de auxiliar a destino
        ResolverTorres(n - 1, auxiliar, destino, origen);
    }

    static void Main(string[] args)
    {
        int numeroDeDiscos = 3; // Puedes cambiar el número de discos

        Console.WriteLine($"Resolviendo las Torres de Hanoi para {numeroDeDiscos} discos:");
        ResolverTorres(numeroDeDiscos, 'A', 'C', 'B'); // A, B y C son los nombres de las torres
    }
}