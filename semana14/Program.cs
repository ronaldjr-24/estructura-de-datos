using System;

// Clase que representa un nodo del árbol binario
class Node
{
    public int Value; // Valor almacenado en el nodo
    public Node Left, Right; // Referencias a los nodos hijos izquierdo y derecho

    // Constructor para inicializar un nodo con un valor
    public Node(int value)
    {
        Value = value;
        Left = Right = null; // Inicialmente, no tiene hijos
    }
}

// Clase que representa el Árbol Binario de Búsqueda (BST)
class BinaryTree
{
    private Node root; // Raíz del árbol

    // Método para insertar un valor en el árbol
    public void Insert(int value)
    {
        root = InsertRec(root, value); // Llama al método recursivo para insertar
    }

    // Método recursivo para insertar un valor en el árbol
    private Node InsertRec(Node node, int value)
    {
        // Si el nodo actual es nulo, se crea un nuevo nodo con el valor
        if (node == null)
            return new Node(value);

        // Si el valor es menor que el valor del nodo actual, se inserta en el subárbol izquierdo
        if (value < node.Value)
            node.Left = InsertRec(node.Left, value);
        // Si el valor es mayor, se inserta en el subárbol derecho
        else
            node.Right = InsertRec(node.Right, value);

        return node; // Retorna el nodo actual
    }

    // Método para buscar un valor en el árbol
    public bool Search(int value)
    {
        return SearchRec(root, value); // Llama al método recursivo para buscar
    }

    // Método recursivo para buscar un valor en el árbol
    private bool SearchRec(Node node, int value)
    {
        // Si el nodo actual es nulo, el valor no se encuentra en el árbol
        if (node == null)
            return false;

        // Si el valor del nodo actual es igual al valor buscado, se ha encontrado
        if (node.Value == value)
            return true;

        // Si el valor es menor que el valor del nodo actual, se busca en el subárbol izquierdo
        if (value < node.Value)
            return SearchRec(node.Left, value);
        // Si el valor es mayor, se busca en el subárbol derecho
        else
            return SearchRec(node.Right, value);
    }

    // Método para recorrer el árbol en inorden (izquierdo, raíz, derecho)
    public void InOrderTraversal()
    {
        InOrderRec(root); // Llama al método recursivo para recorrer en inorden
        Console.WriteLine(); // Salto de línea al final del recorrido
    }

    // Método recursivo para recorrer el árbol en inorden
    private void InOrderRec(Node node)
    {
        if (node != null)
        {
            InOrderRec(node.Left); // Recorre el subárbol izquierdo
            Console.Write(node.Value + " "); // Visita la raíz (imprime el valor)
            InOrderRec(node.Right); // Recorre el subárbol derecho
        }
    }

    // Método para eliminar un nodo del árbol
    public void Delete(int value)
    {
        root = DeleteRec(root, value); // Llama al método recursivo para eliminar
    }

    // Método recursivo para eliminar un nodo del árbol
    private Node DeleteRec(Node node, int value)
    {
        // Si el nodo actual es nulo, no hay nada que eliminar
        if (node == null)
            return node;

        // Si el valor es menor que el valor del nodo actual, se busca en el subárbol izquierdo
        if (value < node.Value)
            node.Left = DeleteRec(node.Left, value);
        // Si el valor es mayor, se busca en el subárbol derecho
        else if (value > node.Value)
            node.Right = DeleteRec(node.Right, value);
        else
        {
            // Caso 1: El nodo no tiene hijos o tiene un solo hijo
            if (node.Left == null)
                return node.Right; // Retorna el hijo derecho
            else if (node.Right == null)
                return node.Left; // Retorna el hijo izquierdo

            // Caso 2: El nodo tiene dos hijos, se busca el sucesor inorden (el menor del subárbol derecho)
            Node temp = MinValueNode(node.Right);
            node.Value = temp.Value; // Reemplaza el valor del nodo con el valor del sucesor
            node.Right = DeleteRec(node.Right, temp.Value); // Elimina el sucesor
        }
        return node; // Retorna el nodo actual
    }

    // Método auxiliar para encontrar el nodo con el menor valor en un subárbol
    private Node MinValueNode(Node node)
    {
        Node current = node;
        while (current.Left != null) // Recorre hacia la izquierda hasta encontrar el valor mínimo
            current = current.Left;
        return current; // Retorna el nodo con el valor mínimo
    }
}

// Clase principal con menú interactivo
class Program
{
    static void Main()
    {
        // Carátula institucional
        Console.WriteLine("===================================================================\n");
        Console.WriteLine("              UNIVERSIDAD ESTATAL AMAZÓNICA           ");
        Console.WriteLine("===================================================================\n");
        Console.WriteLine("              Materia: Estructura de Datos          ");
        Console.WriteLine("              Docente: Ing. Delfin Ortega");
        Console.WriteLine("              Estudiante: Salazar Ajon Ronald Javier");
        Console.WriteLine("===================================================================\n");
        Console.WriteLine("===================================================================\n");
        Console.WriteLine("              Paralelo C                ");
        Console.WriteLine("===================================================================\n");

        BinaryTree tree = new BinaryTree(); // Crear un nuevo árbol binario
        while (true)
        {
            // Menú interactivo
            Console.WriteLine("1. Insertar nodo");
            Console.WriteLine("2. Buscar nodo");
            Console.WriteLine("3. Recorrido inorden");
            Console.WriteLine("4. Eliminar nodo");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine(); // Leer la opción del usuario
            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese el valor a insertar: ");
                    tree.Insert(int.Parse(Console.ReadLine())); // Insertar un valor en el árbol
                    break;
                case "2":
                    Console.Write("Ingrese el valor a buscar: ");
                    Console.WriteLine(tree.Search(int.Parse(Console.ReadLine())) ? "Encontrado" : "No encontrado"); // Buscar un valor en el árbol
                    break;
                case "3":
                    Console.Write("Recorrido inorden: ");
                    tree.InOrderTraversal(); // Recorrer el árbol en inorden
                    break;
                case "4":
                    Console.Write("Ingrese el valor a eliminar: ");
                    tree.Delete(int.Parse(Console.ReadLine())); // Eliminar un valor del árbol
                    Console.WriteLine("Nodo eliminado.");
                    break;
                case "5":
                    return; // Salir del programa
                default:
                    Console.WriteLine("Opción no válida."); // Opción no válida
                    break;
            }
        }
    }
}