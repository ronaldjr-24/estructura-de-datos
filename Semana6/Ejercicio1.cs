namespace RegistroVehiculos
{
    // Clase que representa un vehículo
    public class Vehiculo
    {
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Anio { get; set; }
        public decimal Precio { get; set; }
        public Vehiculo Siguiente { get; set; } // Puntero al siguiente vehículo

        // Constructor
        public Vehiculo(string placa, string marca, string modelo, int anio, decimal precio)
        {
            Placa = placa;
            Marca = marca;
            Modelo = modelo;
            Anio = anio;
            Precio = precio;
            Siguiente = null;
        }
    }

    // Clase que representa la lista enlazada de vehículos
    public class ListaVehiculos
    {
        private Vehiculo cabeza;

        // Agregar vehículo a la lista
        public void AgregarVehiculo(Vehiculo vehiculo)
        {
            vehiculo.Siguiente = cabeza;
            cabeza = vehiculo;
        }

        // Buscar vehículo por placa
        public Vehiculo BuscarVehiculo(string placa)
        {
            Vehiculo actual = cabeza;
            while (actual != null)
            {
                if (actual.Placa.Equals(placa, StringComparison.OrdinalIgnoreCase))
                {
                    return actual; // Vehículo encontrado
                }
                actual = actual.Siguiente;
            }
            return null; // No encontrado
        }

        // Ver vehículos por año
        public List<Vehiculo> VerVehiculosPorAnio(int anio)
        {
            List<Vehiculo> vehiculosPorAnio = new List<Vehiculo>();
            Vehiculo actual = cabeza;

            while (actual != null)
            {
                if (actual.Anio == anio)
                {
                    vehiculosPorAnio.Add(actual);
                }
                actual = actual.Siguiente;
            }

            return vehiculosPorAnio;
        }

        // Ver todos los vehículos registrados
        public void MostrarTodosLosVehiculos()
        {
            Vehiculo actual = cabeza;
            if (actual == null)
            {
                Console.WriteLine("No hay vehículos registrados.");
                return;
            }

            while (actual != null)
            {
                Console.WriteLine($"Placa: {actual.Placa}, Marca: {actual.Marca}, Modelo: {actual.Modelo}, Año: {actual.Anio}, Precio: {actual.Precio:C}");
                actual = actual.Siguiente;
            }
        }

        // Eliminar vehículo registrado por placa
        public bool EliminarVehiculo(string placa)
        {
            if (cabeza == null) return false;

            if (cabeza.Placa.Equals(placa, StringComparison.OrdinalIgnoreCase)) // Si es el primero
            {
                cabeza = cabeza.Siguiente;
                return true;
            }

            Vehiculo actual = cabeza;
            while (actual.Siguiente != null)
            {
                if (actual.Siguiente.Placa.Equals(placa, StringComparison.OrdinalIgnoreCase))
                {
                    actual.Siguiente = actual.Siguiente.Siguiente; // Eliminar
                    return true;
                }
                actual = actual.Siguiente;
            }
            return false; // No encontrado
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ListaVehiculos listaVehiculos = new ListaVehiculos();

            // Ejemplo de uso del programa:
            
            listaVehiculos.AgregarVehiculo(new Vehiculo("ABC123", "Toyota", "Corolla", 2020, 15000));
            listaVehiculos.AgregarVehiculo(new Vehiculo("XYZ789", "Ford", "Fiesta", 2019, 12000));
            listaVehiculos.AgregarVehiculo(new Vehiculo("LMN456", "Honda", "Civic", 2020, 18000));
            
            Console.WriteLine("Lista de todos los vehículos registrados:");
            listaVehiculos.MostrarTodosLosVehiculos();

            Console.WriteLine("\nBuscando vehículo con placa 'ABC123':");
            var buscado = listaVehiculos.BuscarVehiculo("ABC123");
            
            if (buscado != null)
                Console.WriteLine($"Vehículo encontrado: {buscado.Marca} {buscado.Modelo}, Año: {buscado.Anio}, Precio: {buscado.Precio:C}");
            else
                Console.WriteLine("Vehículo no encontrado.");

            Console.WriteLine("\nVer vehículos del año 2020:");
            var vehiculos2020 = listaVehiculos.VerVehiculosPorAnio(2020);
            
            foreach (var v in vehiculos2020)
                Console.WriteLine($"Placa: {v.Placa}, Marca: {v.Marca}, Modelo: {v.Modelo}, Precio: {v.Precio:C}");

            Console.WriteLine("\nEliminando vehículo con placa 'XYZ789':");
            bool eliminado = listaVehiculos.EliminarVehiculo("XYZ789");
            
            if (eliminado)
                Console.WriteLine("Vehículo eliminado.");
            else
                Console.WriteLine("No se pudo eliminar el vehículo.");

            Console.WriteLine("\nLista de todos los vehículos después de la eliminación:");
            listaVehiculos.MostrarTodosLosVehiculos();

            Console.ReadKey();
        }
    }
}
