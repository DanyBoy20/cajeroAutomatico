using CajeroAutomatico.Modelos;
using System;

namespace CajeroAutomatico
{
    class Program
    {
        static void Main(string[] args)
        {
            var cajero = new ATM(); // instancia de clase
            string[] menu = new string[] { "(1)-ADMINISTRACION", "(2)-CLIENTES", "(3)-SALIR" }; // arreglo con opciones del menu principal
            bool seguir = true; // variable boleana para determinar si el programa sigue ejecutandose
            while (seguir) // si la variable SEGUIR es verdadera en su valor
            {
                Console.WriteLine("EVIDENCIA UNIDAD 2 - DANIEL HERNANDEZ PARRILLA");   // mensaje de titulo 
                Console.WriteLine("----------------------------------------------");
                for (int i = 0; i < menu.Length; i++) // recorro el arreglo con las opciones de menu y las muestro
                {
                    Console.WriteLine(menu[i]); // muestro en cada vuelta una opcion del menu
                }
                Console.WriteLine("");
                Console.Write("SELECCIONE UNA OPCION: "); // mensaje
                // ** int.TryPArse es la mejor manera de validar y convertir un dato a otro tipo de dato en una sola linea
                // lo que hago aqui es leer/recibir lo que el usuario escribe con teclado y a su vez lo asigno (out)
                // a una variable (llamada "opt" en este caso) del tipo que deseo convertir
                int.TryParse(Console.ReadLine(), out int opt);
                switch (opt) // la variable que va a ser revisada segun su valor
                {
                    case 1: // si la variable vale 1
                        cajero.SeccionEmpleados(); // ejecuta el metodo 
                        break;
                    case 2: // si la variable vale 1
                        cajero.SeccionClientes();  // ejecuta el metodo
                        break;
                    case 3: // si la variable vale 1
                        seguir = false; // cambio el valor de la variable para salir del programa
                        break;
                    default: // si la variable vale 1
                        Console.Clear(); // limpio pantalla
                        Console.WriteLine("----Opcion invalida, presione una tecla para intentar nuevamente----"); // mensaje
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
