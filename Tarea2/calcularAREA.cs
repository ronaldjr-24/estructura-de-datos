using System;

namespace FigurasGeometricas
{
    // Clase que representa un círculo
    public class Circulo
    {
        // Propiedad que almacena el radio del círculo
        public double Radio { get; set; }

        // Constructor que inicializa el radio del círculo
        public Circulo(double radio)
        {
            Radio = radio;
        }

        // Método para calcular el área del círculo
        // CalcularArea es una función que devuelve un valor double,
        // se utiliza para calcular el área de un círculo, requiere como argumento el radio del círculo
        public double CalcularArea()
        {
            return Math.PI * Radio * Radio;
        }

        // Método para calcular el perímetro del círculo
        // CalcularPerimetro es una función que devuelve un valor double,
        // se utiliza para calcular el perímetro de un círculo, requiere como argumento el radio del círculo
        public double CalcularPerimetro()
        {
            return 2 * Math.PI * Radio;
        }
    }

    // Clase que representa un cuadrado
    public class Cuadrado
    {
        // Propiedad que almacena el lado del cuadrado
        public double Lado { get; set; }

        // Constructor que inicializa el lado del cuadrado
        public Cuadrado(double lado)
        {
            Lado = lado;
        }

        // Método para calcular el área del cuadrado
        // CalcularArea es una función que devuelve un valor double,
        // se utiliza para calcular el área de un cuadrado, requiere como argumento el lado del cuadrado
        public double CalcularArea()
        {
            return Lado * Lado;
        }

        // Método para calcular el perímetro del cuadrado
        // CalcularPerimetro es una función que devuelve un valor double,
        // se utiliza para calcular el perímetro de un cuadrado, requiere como argumento el lado del cuadrado
        public double CalcularPerimetro()
        {
            return 4 * Lado;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Crear una instancia de Circulo con radio 5
            Circulo circulo = new Circulo(5);
            Console.WriteLine($"Área del círculo: {circulo.CalcularArea()}");
            Console.WriteLine($"Perímetro del círculo: {circulo.CalcularPerimetro()}");

            // Crear una instancia de Cuadrado con lado 4
            Cuadrado cuadrado = new Cuadrado(4);
            Console.WriteLine($"Área del cuadrado: {cuadrado.CalcularArea()}");
            Console.WriteLine($"Perímetro del cuadrado: {cuadrado.CalcularPerimetro()}");
        }
    }
}