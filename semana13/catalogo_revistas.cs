class Nodo
{
    public string Titulo; // Título de la revista (clave)
    public Nodo Izquierdo; // Subárbol izquierdo
    public Nodo Derecho; // Subárbol derecho

    // Constructor para crear un nodo
    public Nodo(string titulo)
    {
        Titulo = titulo;
        Izquierdo = null;
        Derecho = null;
    }
}

class ArbolBinarioBusqueda
{
    private Nodo raiz; // Raíz del árbol

    // Constructor
    public ArbolBinarioBusqueda()
    {
        raiz = null;
    }

    // Método público para insertar un título en el árbol
    public void Insertar(string titulo)
    {
        raiz = InsertarRecursivo(raiz, titulo);
    }

    // Método privado para insertar un título de manera recursiva
    private Nodo InsertarRecursivo(Nodo nodo, string titulo)
    {
        // Si el nodo es nulo, creamos un nuevo nodo
        if (nodo == null)
        {
            return new Nodo(titulo);
        }

        // Si el título es menor, lo insertamos en el subárbol izquierdo
        if (string.Compare(titulo, nodo.Titulo, StringComparison.OrdinalIgnoreCase) < 0)
        {
            nodo.Izquierdo = InsertarRecursivo(nodo.Izquierdo, titulo);
        }
        // Si el título es mayor, lo insertamos en el subárbol derecho
        else if (string.Compare(titulo, nodo.Titulo, StringComparison.OrdinalIgnoreCase) > 0)
        {
            nodo.Derecho = InsertarRecursivo(nodo.Derecho, titulo);
        }

        return nodo;
    }

    // Método público para buscar un título de manera recursiva
    public bool BuscarRecursivo(string titulo)
    {
        return BuscarRecursivo(raiz, titulo);
    }

    // Método privado para buscar un título de manera recursiva
    private bool BuscarRecursivo(Nodo nodo, string titulo)
    {
        // Si el nodo es nulo, el título no existe en el árbol
        if (nodo == null)
        {
            return false;
        }

        // Si el título es igual, lo hemos encontrado
        if (string.Compare(titulo, nodo.Titulo, StringComparison.OrdinalIgnoreCase) == 0)
        {
            return true;
        }

        // Si el título es menor, buscamos en el subárbol izquierdo
        if (string.Compare(titulo, nodo.Titulo, StringComparison.OrdinalIgnoreCase) < 0)
        {
            return BuscarRecursivo(nodo.Izquierdo, titulo);
        }

        // Si el título es mayor, buscamos en el subárbol derecho
        return BuscarRecursivo(nodo.Derecho, titulo);
    }

    // Método público para buscar un título de manera iterativa
    public bool BuscarIterativo(string titulo)
    {
        Nodo actual = raiz;

        // Mientras el nodo actual no sea nulo
        while (actual != null)
        {
            // Si el título es igual, lo hemos encontrado
            if (string.Compare(titulo, actual.Titulo, StringComparison.OrdinalIgnoreCase) == 0)
            {
                return true;
            }

            // Si el título es menor, nos movemos al subárbol izquierdo
            if (string.Compare(titulo, actual.Titulo, StringComparison.OrdinalIgnoreCase) < 0)
            {
                actual = actual.Izquierdo;
            }
            // Si el título es mayor, nos movemos al subárbol derecho
            else
            {
                actual = actual.Derecho;
            }
        }

        // Si llegamos aquí, el título no existe en el árbol
        return false;
    }

    // Método público para mostrar todos los títulos en orden (inorden)
    public void MostrarCatalogo()
    {
        MostrarCatalogo(raiz);
    }

    // Método privado para mostrar los títulos en orden (inorden)
    private void MostrarCatalogo(Nodo nodo)
    {
        if (nodo != null)
        {
            MostrarCatalogo(nodo.Izquierdo); // Recorrer subárbol izquierdo
            Console.WriteLine("- " + nodo.Titulo); // Mostrar título actual
            MostrarCatalogo(nodo.Derecho); // Recorrer subárbol derecho
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Crear un árbol binario de búsqueda
        ArbolBinarioBusqueda arbol = new ArbolBinarioBusqueda();

        // Insertar 10 títulos de revistas en el árbol
        string[] titulos = {
            "National Geographic ", "Muy Interesante", "Hola", "Qué Leer",
            "GQ España", "Vogue España", "PC Actual", "Mente Sana",
            "Fotogramas", "Historia y Vida"
        };

        foreach (string titulo in titulos)
        {
            arbol.Insertar(titulo);
        }

        // Menú interactivo
        while (true)
        {
            Console.Clear();
            Console.WriteLine("       Universidad Estatal Amazonica  \n    ");
            Console.WriteLine("       Asignatura: Estructura de Datos  \n  ");
            Console.WriteLine("       Nombre : Ronald salazar \n      ");
            Console.WriteLine("      CATÁLOGO DE REVISTAS \n");
            Console.WriteLine("1. Buscar título (Búsqueda Recursiva) \n");
            Console.WriteLine("2. Buscar título (Búsqueda Iterativa)\n");
            Console.WriteLine("3. Mostrar todos los títulos \n");
            Console.WriteLine("4. Salir\n");
            Console.Write("Seleccione una opción:  ");

            string opcion = Console.ReadLine();

            if (opcion == "4") break;

            switch (opcion)
            {
                case "1":
                case "2":
                    Console.Write("Ingrese el título de la revista a buscar: ");
                    string titulo = Console.ReadLine();

                    bool encontrado = opcion == "1" ? arbol.BuscarRecursivo(titulo) : arbol.BuscarIterativo(titulo);

                    // Mostrar el resultado de la búsqueda
                    Console.WriteLine(encontrado ? " Título encontrado" : " Título no encontrado");
                    break;

                case "3":
                    Console.WriteLine("\n📚 Lista de revistas disponibles:");
                    arbol.MostrarCatalogo();
                    break;

                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}