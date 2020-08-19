using CajeroAutomatico.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroAutomatico.Modelos
{
    class CajeroAutomatico
    {
        // ------------ INSTANCIAS DE CLASE Y ASIGNO VALORES A VARIABLES (Y ARREGLOS) -------------------//

        // MENUS - INSTANCIA DE CLASE PARA LLAMAR A LOS MENUS CUANDO SE NECESITEN
        Menu menu = new Menu();

        int dineroEnCaja = 5000; // variable para contener la cantidad de dinero existente en cajero

        List<NumeroCuenta> Cuentas = new List<NumeroCuenta>(); // Lista para guardar a los clientes

        // lista inicializada para los empleados, agregue 3: gerente, cajero y servicio
        List<Empleado> Empleados = new List<Empleado>()
        {
         new Empleado { Id = 1, Nombre = "Daniel", Apellido = "Hernandez", Nip = 1234, Tipo = "Gerente" },
         new Empleado { Id = 2, Nombre = "Cajero01", Apellido = "Sucursal01", Nip = 1234, Tipo = "Cajero" },
         new Empleado { Id = 3, Nombre = "Servicio 01", Apellido = "CajeroAutomatico01", Nip = 1234, Tipo = "Servicio" }
         };

        // ---------- METODO VALIDAR EL ACCESO A LOS EMPLEADOS (gerente, cajero y servicio) - Y MOSTRAR SU MENU CORRESPONDIENTE ---------//
        public void SeccionEmpleados()
        {
            Console.Clear(); // limpio pantalla
            Console.Write("Ingrese numero de identificación: "); // mensaje pidiendo datos
            int.TryParse(Console.ReadLine(), out int numeroID);
            var identificador = Empleados.FirstOrDefault(a => a.Id == numeroID);
            // si la busqueda de la cuenta es diferente de null, es decir, encontro un valor y lo asigno a variable cuenta
            if (identificador != null)
            {
                int contra = identificador.Nip; // si encontro el valor, el nip que corresponde al valor que devolvio lo asigno a una variable, en este caso el NIP
                Console.Write("Ingrese su contraseña: "); // mensaje pidiendo datos
                int.TryParse(Console.ReadLine(), out int contrasenia);
                if (contra == contrasenia) // si la contraseña correcta
                {
                    string tipo = identificador.Tipo;
                    Console.Clear();
                    if (tipo == "Gerente") // si el tipo es gerente
                    {
                        bool seguir = true;
                        while (seguir)
                        {
                            int opt = menu.MenuGerente(); // asigno lo que devuelve el metodo a la variable
                            switch (opt) // la variable que va a ser revisada segun su valor
                            {
                                case 1: // si la variable vale 1
                                    Console.Clear();
                                    NuevaCuenta();
                                    break;
                                case 2: // si la variable vale 1
                                    Console.Clear();
                                    MostrarCliente(); // mensaje
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                case 3: // si la variable vale 1
                                    Console.Clear();
                                    MostrarClientes(); // mensaje
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                case 4:
                                    Console.Clear();
                                    Console.WriteLine("Sesión Cerrada"); // mensaje
                                    seguir = false;
                                    Console.ReadKey();
                                    Console.Clear();
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
                    else if (tipo == "Cajero") // si tipo es cajero
                    {
                        bool seguir = true;
                        while (seguir)
                        {
                            int opt = menu.MenuCajero(); // asigno lo que devuelve el metodo a la variable
                            switch (opt) // la variable que va a ser revisada segun su valor
                            {
                                case 1: // si la variable vale 1
                                    Console.Clear();
                                    Depositar();
                                    break;
                                case 2: // si la variable vale 1
                                    Console.Clear();
                                    Retirar(); // mensaje
                                    Console.ReadKey();
                                    break;
                                case 3: // si la variable vale 1
                                    Console.Clear();
                                    MostrarCliente(); // mensaje
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                case 4:
                                    Console.Clear();
                                    Console.WriteLine("Sesión Cerrada"); // mensaje
                                    seguir = false;
                                    Console.ReadKey();
                                    Console.Clear();
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
                    else // si el tipo no fue gerente o cajero, entonces fue servicio
                    {
                        bool seguir = true;
                        while (seguir)
                        {
                            int opt = menu.MenuServicio(); // asigno lo que devuelve el metodo a la variable
                            switch (opt) // la variable que va a ser revisada segun su valor
                            {
                                case 1: // si la variable vale 1
                                    Console.Clear();
                                    DotarCajero();
                                    Console.Clear();
                                    break;
                                case 2: // si la variable vale 1
                                    Console.Clear();
                                    VerCajero();
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                case 3:
                                    Console.Clear();
                                    Console.WriteLine("Sesión Cerrada"); // mensaje
                                    seguir = false;
                                    Console.ReadKey();
                                    Console.Clear();
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
                else
                {
                    Console.Clear(); // limpio pantalla
                    Console.WriteLine("Contraseña incorrecta, presione una tecla para continuar"); // mensaje de error
                    Console.ReadKey(); // espero que el usuario presione una tecla, lo ocupo solo como una breve pausa y se pueda leer la pantalla
                    Console.Clear(); // limpio pantalla
                }
            }
            else
            {
                Console.Clear(); // limpio pantalla
                Console.WriteLine("La cuenta ingresada no existe, presione una tecla para continuar"); // mensaje de error
                Console.ReadKey(); // espero que el usuario presione una tecla, lo ocupo solo como una breve pausa y se pueda leer la pantalla
                Console.Clear(); // limpio pantalla
            }
        }

        // ------------------------------ METODO VALIDAR ACCESO AL CLIENTE Y MOSTRAR SU MENU -----------------------------//
        public void SeccionClientes()
        {
            Console.Clear(); // limpio pantalla
            Console.Write("Ingrese numero de cuenta: "); // mensaje pidiendo datos
            int.TryParse(Console.ReadLine(), out int numeroID);
            var identificador = Cuentas.FirstOrDefault(a => a.Id == numeroID);
            // si la busqueda de la cuenta es diferente de null, es decir, encontro un valor y lo asigno a variable cuenta
            if (identificador != null)
            {
                int contra = identificador.Nip; // si encontro el valor, el nip que corresponde al valor que devolvio lo asigno a una variable, en este caso el NIP
                Console.Write("Ingrese su NIP: "); // mensaje pidiendo datos
                int.TryParse(Console.ReadLine(), out int contrasenia);
                if (contra == contrasenia) // si la contraseña correcta
                {
                    Console.Clear();
                    bool seguir = true;
                    while (seguir)
                    {
                        int opt = menu.MenuCliente(); // asigno lo que devuelve el metodo a la variable
                        switch (opt) // la variable que va a ser revisada segun su valor
                        {
                            case 1: // si la variable vale 1
                                Console.Clear();
                                Depositar();
                                break;
                            case 2: // si la variable vale 1
                                Console.Clear();
                                Retirar(); // mensaje
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case 3: // si la variable vale 1
                                Console.Clear();
                                CambioNip(); // mensaje
                                seguir = false;
                                Console.Clear();
                                break;
                            case 4:
                                Console.Clear();
                                MostrarCliente();  // mensaje
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case 5:
                                Console.Clear();
                                Console.WriteLine("Sesión Cerrada"); // mensaje
                                seguir = false;
                                Console.ReadKey();
                                Console.Clear();
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
                else
                {
                    Console.Clear(); // limpio pantalla
                    Console.WriteLine("Contraseña incorrecta, presione una tecla para continuar"); // mensaje de error
                    Console.ReadKey(); // espero que el usuario presione una tecla, lo ocupo solo como una breve pausa y se pueda leer la pantalla
                    Console.Clear(); // limpio pantalla
                }
            }
            else
            {
                Console.Clear(); // limpio pantalla
                Console.WriteLine("La cuenta ingresada no existe, presione una tecla para continuar"); // mensaje de error
                Console.ReadKey(); // espero que el usuario presione una tecla, lo ocupo solo como una breve pausa y se pueda leer la pantalla
                Console.Clear(); // limpio pantalla
            }
        }

        // ------------------------------------------ METODOS PARA OPERAR EL CAJERO ------------------------------------------- //

        // METODO PARA ABRIR UNA NUEVA CUENTA BANCARIA DE CLIENTE
        public void NuevaCuenta()
        {
            // instancia (objeto) de la clase NumeroCuenta
            var cuenta = new NumeroCuenta();
            Console.Clear(); // me servira para limpiar pantalla
            Console.WriteLine("CREAR CUENTA BANCARIA"); // mensaje en pantalla
            Console.WriteLine("---------------------"); // es solo estetico, para darle una vista organizada, puede eliminarse sin repercutir en codigo
            Console.Write("Escribe su nombre: "); // mensaje pidiendo datos
            cuenta.Nombre = Console.ReadLine(); // capturo lo que el usuario escribe con teclado y lo asigno a variable Nombre
            Console.Write("Escribe tu apellido: "); // mensaje pidiendo datos
            cuenta.Apellido = Console.ReadLine(); // capturo lo que el usuario escribe con teclado y lo asigno a variable 
            Console.Write("Genere y escriba Nip: "); // mensaje pidiendo datos
            cuenta.Nip = int.Parse(Console.ReadLine()); // capturo lo que el usuario escribe con teclado y lo asigno a variable 
            cuenta.Tipo = "Cliente";
            cuenta.SaldoActual = 0.0; // asigno el saldo inicial
            cuenta.Id = Cuentas.Count + 1; // asigno un numero a la cuenta
            Cuentas.Add(cuenta); // añado toda la informacion a la lista
            Console.Clear(); // limpio pantalla
            Console.WriteLine("Cuenta creada, presione cualquier tecla para continuar"); // mensaje en pantalla
            Console.ReadKey(); // espero que el usuario presione una tecla, lo ocupo solo como una breve pausa y se pueda leer la pantalla
            Console.Clear();// limpio pantalla
        }

        // METODO VER UN SOLO CLIENTE
        public void MostrarCliente()
        {
            Console.Clear(); // limpio pantalla
            Console.Write("NUMERO DE CUENTA: "); // mensaje pidiendo datos
            int.TryParse(Console.ReadLine(), out int numeroCuenta);
            var cuenta = Cuentas.FirstOrDefault(a => a.Id == numeroCuenta);
            // si la busqueda de la cuenta es diferente de null, es decir, encontro un valor y lo asigno a variable cuenta
            if (cuenta != null) // si devolvio un valor
            {
                Console.WriteLine("Cuenta: " + cuenta.Id + " | Nombre: " + cuenta.Nombre + " | Apellido: " + cuenta.Apellido + " | Saldo Actual: " + cuenta.SaldoActual);
            }
            else
            {
                Console.Clear(); // limpio pantalla
                Console.WriteLine("La cuenta ingresada no existe, presione una tecla para continuar"); // mensaje de error
                Console.ReadKey(); // espero que el usuario presione una tecla, lo ocupo solo como una breve pausa y se pueda leer la pantalla
                Console.Clear(); // limpio pantalla
            }
        }

        // METODO VER TODOS LOS CLIENTES
        public void MostrarClientes()
        {
            var clientes = new NumeroCuenta();
            Console.Clear();
            Console.WriteLine("Cuenta        Nombre             Apellido          Saldo Actual     ");
            foreach (NumeroCuenta todosClientes in Cuentas) // en un ciclo for muestro los clientes
            {
                Console.WriteLine("   " + todosClientes.Id + "          " + todosClientes.Nombre + "                " + todosClientes.Apellido + "              " + todosClientes.SaldoActual);
            }
        }

        // METODO DEPOSITAR
        public void Depositar()
        {
            Console.Clear(); // limpio pantalla
            Console.Write("NUMERO DE CUENTA A DEPOSITAR: "); // mensaje pidiendo datos
            int.TryParse(Console.ReadLine(), out int numeroCuenta);
            var cuenta = Cuentas.FirstOrDefault(a => a.Id == numeroCuenta);
            // si la busqueda de la cuenta es diferente de null, es decir, encontro un valor y lo asigno a variable cuenta
            if (cuenta != null)
            {
                Console.Write("Inserte la cantidad a depositar: "); // mensaje pidiendo datos
                double.TryParse(Console.ReadLine(), out double saldo);
                Console.Clear(); // limpio pantalla
                Console.WriteLine("Saldo anterior: ${0}", cuenta.SaldoActual); // mensaje mostrando el saldo anterior
                Console.WriteLine("Deposito: ${0}", saldo);// mensaje mostrando cuanto se deposito
                cuenta.SaldoActual += saldo; // agrego al saldo actual lo que el usuario deposito
                Console.WriteLine("saldo actual: ${0}", cuenta.SaldoActual);// mensaje mostrando el saldo actual
                Console.WriteLine("--------------------"); // es solo estetico, para darle una vista organizada, puede eliminarse sin repercutir en codigo
                Console.WriteLine(); // un espacio en blanco
                Console.WriteLine("Presione una tecla para continuar"); // mensaje en pantalla
                Console.ReadKey(); // espero que el usuario presione una tecla, lo ocupo solo como una breve pausa y se pueda leer la pantalla
                Console.Clear(); // limpio pantalla
            }
            else
            {
                Console.Clear(); // limpio pantalla
                Console.WriteLine("La cuenta ingresada no existe, presione una tecla para continuar"); // mensaje de error
                Console.ReadKey(); // espero que el usuario presione una tecla, lo ocupo solo como una breve pausa y se pueda leer la pantalla
                Console.Clear(); // limpio pantalla
            }
        }

        // METODO PARA RETIRAR
        public void Retirar()
        {
            Console.Clear(); // limpio pantalla
            Console.Write("NUMERO DE CUENTA DE DONDE RETIRA: "); // mensaje pidiendo datos
            int.TryParse(Console.ReadLine(), out int numeroCuenta);
            var cuenta = Cuentas.FirstOrDefault(a => a.Id == numeroCuenta);
            // si la busqueda de la cuenta es diferente de null, es decir, encontro un valor y lo asigno a variable cuenta
            if (cuenta != null)
            {
                Console.Write("Ingrese la cantidad a retirar: "); // mensaje pidiendo datos
                double.TryParse(Console.ReadLine(), out double saldo);
                Console.Clear(); // limpio pantalla
                if (saldo > cuenta.SaldoActual) // si lo que deseo retirar es mayor al saldo actual
                {
                    Console.Write("ESTA INTENTANDO RETIRAR UN MONTO MAYOR AL DISPONIBLE"); // mensaje pidiendo datos
                }
                else if (saldo == cuenta.SaldoActual) // si lo que deseo retirar es igual al saldo actual
                {
                    Console.Write("NO PUEDE DEJAR LA CUENTA EN CERO"); // mensaje pidiendo datos
                }
                else
                {
                    Console.WriteLine("Saldo anterior: ${0}", cuenta.SaldoActual); // mensaje mostrando el saldo anterior
                    Console.WriteLine("Deposito: ${0}", saldo);// mensaje mostrando cuanto se deposito
                    cuenta.SaldoActual -= saldo; // agrego al saldo actual lo que el usuario deposito
                    Console.WriteLine("saldo actual: ${0}", cuenta.SaldoActual);// mensaje mostrando el saldo actual
                    Console.WriteLine("--------------------"); // es solo estetico, para darle una vista organizada, puede eliminarse sin repercutir en codigo
                    Console.WriteLine(); // un espacio en blanco
                    Console.WriteLine("Presione una tecla para continuar"); // mensaje en pantalla
                    Console.ReadKey(); // espero que el usuario presione una tecla, lo ocupo solo como una breve pausa y se pueda leer la pantalla
                    Console.Clear(); // limpio pantalla
                }
            }
            else
            {
                Console.Clear(); // limpio pantalla
                Console.WriteLine("La cuenta ingresada no existe, presione una tecla para continuar"); // mensaje de error
                Console.ReadKey(); // espero que el usuario presione una tecla, lo ocupo solo como una breve pausa y se pueda leer la pantalla
                Console.Clear(); // limpio pantalla
            }
        }

        // METODO PARA CAMBIO DE NIP
        public void CambioNip()
        {
            Console.Clear(); // limpio pantalla
            Console.Write("Ingrese su numero de cuenta: "); // mensaje pidiendo datos
            int.TryParse(Console.ReadLine(), out int numeroCuenta); // capturo lo del teclado
            var cuenta = Cuentas.FirstOrDefault(a => a.Id == numeroCuenta); // valido la cuenta
            // si la busqueda de la cuenta es diferente de null, es decir, encontro un valor y lo asigno a variable cuenta
            if (cuenta != null) // si devolcio un valor, la cuenta existe
            {
                int nipo = cuenta.Nip; // si encontro el valor, el nip que corresponde al valor que devolvio lo asigno a una variable, en este caso el NIP
                Console.Write("Ingrese su Nip: "); // mensaje pidiendo datos
                // ** mismos comenatrios que linea 51
                int.TryParse(Console.ReadLine(), out int numeroNip);
                if (nipo == numeroNip) // si el nip es correcto
                {
                    Console.Write("Escriba su nuevo NIP: "); // mensaje pidiendo datos
                    int.TryParse(Console.ReadLine(), out int contra);
                    foreach (var cnta in Cuentas) // recorro la lista en busca del registro a editar y cambio el valor del atributo dado
                    {
                        if (cnta.Id == numeroCuenta) // si la cuenta es igual a la dada
                        {
                            cnta.Nip = contra; // cambio el valor
                        }
                    }
                    Console.WriteLine("Presione una tecla para continuar"); // mensaje en pantalla
                    Console.ReadKey(); // espero que el usuario presione una tecla, lo ocupo solo como una breve pausa y se pueda leer la pantalla
                    Console.Clear(); // limpio pantalla
                }
                else
                {
                    Console.Clear(); // limpio pantalla
                    Console.WriteLine("Contraseña incorrecta, presione una tecla para continuar"); // mensaje de error
                    Console.ReadKey(); // espero que el usuario presione una tecla, lo ocupo solo como una breve pausa y se pueda leer la pantalla
                    Console.Clear(); // limpio pantalla
                }
            }
            else
            {
                Console.Clear(); // limpio pantalla
                Console.WriteLine("La cuenta ingresada no existe, presione una tecla para continuar"); // mensaje de error
                Console.ReadKey(); // espero que el usuario presione una tecla, lo ocupo solo como una breve pausa y se pueda leer la pantalla
                Console.Clear(); // limpio pantalla
            }
        }

        // METODO DOTAR CAJERO DE DINERO
        public void DotarCajero()
        {
            Console.Write("Inserte la cantidad a depositar en cajero automatico: "); // mensaje pidiendo datos
            int.TryParse(Console.ReadLine(), out int cantidad);
            Console.Clear(); // limpio pantalla
            Console.WriteLine("Saldo anterior en cajero: ${0}", dineroEnCaja); // mensaje mostrando el saldo anterior
            Console.WriteLine("Deposito: ${0}", cantidad);// mensaje mostrando cuanto se deposito
            dineroEnCaja += cantidad; // agrego al saldo actual lo que el usuario deposito
            Console.WriteLine("saldo actual en cajero: ${0}", dineroEnCaja);// mensaje mostrando el saldo actual
            Console.WriteLine("--------------------"); // es solo estetico, para darle una vista organizada, puede eliminarse sin repercutir en codigo
            Console.WriteLine(); // un espacio en blanco
            Console.WriteLine("Presione una tecla para continuar"); // mensaje en pantalla
            Console.ReadKey(); // espero que el usuario presione una tecla, lo ocupo solo como una breve pausa y se pueda leer la pantalla
            Console.Clear(); // limpio pantalla           
        }

        // METODO PARA VER LA CANTIDAD DE DINERO QUE TIENE EL CAJERO
        public void VerCajero()
        {
            Console.WriteLine("Cantidad de dinero en cajero: ${0}", dineroEnCaja); // mensaje mostrando el saldo anterior
        }
    }
}
