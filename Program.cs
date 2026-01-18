

using System;

namespace ListasEnlazadas
{
    // Clase Nodo
    class Nodo
    {
        public int Dato;
        public Nodo Siguiente;

        public Nodo(int dato)
        {
            Dato = dato;
            Siguiente = null;
        }
    }

    // Clase Lista Enlazada
    class ListaEnlazada
    {
        private Nodo cabeza;

        // Insertar al final
        public void Insertar(int dato)
        {
            Nodo nuevo = new Nodo(dato);

            if (cabeza == null)
            {
                cabeza = nuevo;
            }
            else
            {
                Nodo actual = cabeza;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevo;
            }
        }

        // Mostrar lista
        public void Mostrar()
        {
            Nodo actual = cabeza;
            while (actual != null)
            {
                Console.Write(actual.Dato + " -> ");
                actual = actual.Siguiente;
            }
            Console.WriteLine("null");
        }

        // EJERCICIO 1: Método de búsqueda
        public int Buscar(int valor)
        {
            Nodo actual = cabeza;
            int contador = 0;

            while (actual != null)
            {
                if (actual.Dato == valor)
                {
                    contador++;
                }
                actual = actual.Siguiente;
            }

            if (contador == 0)
            {
                Console.WriteLine("El dato no fue encontrado en la lista.");
            }

            return contador;
        }

        // EJERCICIO 2: Eliminar nodos fuera de un rango
        public void EliminarFueraDeRango(int min, int max)
        {
            // Eliminar nodos al inicio
            while (cabeza != null && (cabeza.Dato < min || cabeza.Dato > max))
            {
                cabeza = cabeza.Siguiente;
            }

            Nodo actual = cabeza;

            while (actual != null && actual.Siguiente != null)
            {
                if (actual.Siguiente.Dato < min || actual.Siguiente.Dato > max)
                {
                    actual.Siguiente = actual.Siguiente.Siguiente;
                }
                else
                {
                    actual = actual.Siguiente;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ListaEnlazada lista = new ListaEnlazada();
            Random random = new Random();

            // EJERCICIO 2: Crear lista con 50 números aleatorios
            for (int i = 0; i < 50; i++)
            {
                lista.Insertar(random.Next(1, 1000));
            }

            Console.WriteLine("Lista original:");
            lista.Mostrar();

            // Ingreso de rango
            Console.Write("\nIngrese valor mínimo: ");
            int min = int.Parse(Console.ReadLine());

            Console.Write("Ingrese valor máximo: ");
            int max = int.Parse(Console.ReadLine());

            lista.EliminarFueraDeRango(min, max);

            Console.WriteLine("\nLista después de eliminar valores fuera del rango:");
            lista.Mostrar();

            // EJERCICIO 1: Búsqueda
            Console.Write("\nIngrese el valor a buscar: ");
            int buscar = int.Parse(Console.ReadLine());

            int veces = lista.Buscar(buscar);
            if (veces > 0)
            {
                Console.WriteLine($"El valor {buscar} se encontró {veces} veces.");
            }

            Console.ReadKey();
        }
    }
}




