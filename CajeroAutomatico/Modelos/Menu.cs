using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroAutomatico.Modelos
{
    class Menu
    {
        // ARREGLOS CON ELEMENTOS DE MENU
        string[] menuGerente = new string[] { "(1)-NUEVO CLIENTE", "(2)-VER CLIENTE", "(3)-LISTA CLIENTES", "(4)-CERRAR SESIÓN" };
        string[] menuCajero = new string[] { "(1)-DEPOSITAR", "(2)-RETIRAR", "(3)-SALDO CLIENTE", "(4)-CERRAR SESIÓN" };
        string[] menuServicio = new string[] { "(1)-DOTAR CAJERO", "(2)-CANTIDAD DE DINERO EN CAJERO", "(3)- CERRAR SESIÓN" };
        string[] menuCliente = new string[] { "(1)-DEPOSITAR", "(2)-RETIRAR", "(3)-CAMBIO NIP", "(4)-SALDO", "(5)-CERRAR SESIÓN" };

        // MENU GERENTE - EN UN BUCLE FOR RECORRO LAS OPCIONES Y LAS MUESTRO, ESTE METODO ME RETORNA EL VALOR (ENTERO) ELEGIDO
        public int MenuGerente()
        {
            Console.WriteLine("----------------SECCION GERENTE----------------"); // TITULO
            for (int i = 0; i < menuGerente.Length; i++)
            { // ciclo para mostrar el menu, una opcion por cada vuelta
                Console.WriteLine(menuGerente[i]); // muestro el menu
            }
            int.TryParse(Console.ReadLine(), out int opcionesGerente); // capturo lo que el usuario ingreso
            return opcionesGerente; // y lo devuelvo
        }

        // MENU CAJERO - EN UN BUCLE FOR RECORRO LAS OPCIONES Y LAS MUESTRO, ESTE METODO ME RETORNA EL VALOR (ENTERO) ELEGIDO
        public int MenuCajero()
        {
            Console.WriteLine("----------------SECCION CAJERO----------------"); // TITULO
            for (int i = 0; i < menuCajero.Length; i++)
            { // ciclo para mostrar el menu, una opcion por cada vuelta
                Console.WriteLine(menuCajero[i]); // muestro el menu
            }
            int.TryParse(Console.ReadLine(), out int opcionesCajero); // capturo lo que el usuario ingreso
            return opcionesCajero; // y lo devuelvo
        }

        // MENU SERVICIO - EN UN BUCLE FOR RECORRO LAS OPCIONES Y LAS MUESTRO, ESTE METODO ME RETORNA EL VALOR (ENTERO) ELEGIDO
        public int MenuServicio()
        {
            Console.WriteLine("----------------SECCION SERVICIO----------------"); // TITULO
            for (int i = 0; i < menuServicio.Length; i++)
            { // ciclo para mostrar el menu, una opcion por cada vuelta
                Console.WriteLine(menuServicio[i]); // muestro el menu
            }
            int.TryParse(Console.ReadLine(), out int opcionesServicio); // capturo lo que el usuario ingreso
            return opcionesServicio; // y lo devuelvo
        }

        // MENU CLIENTE - EN UN BUCLE FOR RECORRO LAS OPCIONES Y LAS MUESTRO, ESTE METODO ME RETORNA EL VALOR (ENTERO) ELEGIDO
        public int MenuCliente()
        {
            Console.WriteLine("----------------SECCION CLIENTE----------------"); // TITULO
            for (int i = 0; i < menuCliente.Length; i++)
            { // ciclo para mostrar el menu, una opcion por cada vuelta
                Console.WriteLine(menuCliente[i]); // muestro el menu
            }
            int.TryParse(Console.ReadLine(), out int opcionesCliente); // capturo lo que el usuario ingreso
            return opcionesCliente; // y lo devuelvo
        }
    }
}
