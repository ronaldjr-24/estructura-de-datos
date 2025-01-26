using System;
using System.Collections.Generic;

class Program
{
    // Método para verificar si la expresión está balanceada
    static bool VerificarBalance(string expresion)
    {
        // Crear una pila para almacenar los caracteres de apertura
        Stack<char> pila = new Stack<char>();

        // Recorrer cada carácter de la expresión
        foreach (char c in expresion)
        {
            // Si encontramos un carácter de apertura, lo agregamos a la pila
            if (c == '{' || c == '(' || c == '[')
            {
                pila.Push(c);
            }
            // Si encontramos un carácter de cierre
            else if (c == '}' || c == ')' || c == ']')
            {
                // Verificamos si la pila está vacía (no hay apertura correspondiente)
                if (pila.Count == 0)
                {
                    return false;
                }

                // Sacamos el último carácter de la pila
                char apertura = pila.Pop();

                // Verificamos si el carácter de cierre corresponde al de apertura
                if (!EsPar(apertura, c))
                {
                    return false;
                }
            }
        }

        // Si la pila está vacía al final, la expresión está balanceada
        return pila.Count == 0;
    }

    // Método para verificar si los caracteres de apertura y cierre son pares
    static bool EsPar(char apertura, char cierre)
    {
        return (apertura == '{' && cierre == '}') ||
               (apertura == '(' && cierre == ')') ||
               (apertura == '[' && cierre == ']');
    }

    static void Main(string[] args)
    {
        string expresion = "{7+(8*5)-[(9-7)+(4+1)]}";

        // Verificamos si la expresión está balanceada
        if (VerificarBalance(expresion))
        {
            Console.WriteLine("La expresión está balanceada.");
        }
        else
        {
            Console.WriteLine("La expresión no está balanceada.");
        }
    }
}