using Dominio;

namespace Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sistema sistema = Sistema.Instancia();

            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                MenuBienvenida();


                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        ListarTodosLosClientes();
                        break;
                    case "2":
                        ListarVuelos();
                        break;
                    case "3":
                        DarAltaClienteOcasional();
                        break;
                    case "4":
                        ListarPasajes();
                        break;

                    case "0":
                        Console.WriteLine("Saliendo del programa...");
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }

                if (continuar)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }

        }

        //****************************************************************
        //  ****************** METODO MENU BIENVENIDA ****************
        // ***************************************************************

        #region METODO BIENVENIDA DEL MENU

        public static void MenuBienvenida()
        {
            Console.WriteLine("******************************");
            Console.WriteLine("    BIENVENIDO AL MENU        ");
            Console.WriteLine("******************************");
            Console.WriteLine("Elija una de las siguientes opciones");

            ;
            Console.WriteLine("1. Listar todos los Clientes");
            Console.WriteLine("2.Listar todos los vuelos.");
            Console.WriteLine("3.Alta de cliente ocasional.");
            Console.WriteLine("4.Listar pasajes entre dos fechas");

            Console.WriteLine("0. Salir del menu");


        }

        #endregion


        //*********************************************************
        // ********* METODO LISTAR TODOS LOS CLIENTES **********
        //*********************************************************

        #region METODO LISTAR CLIENTTES
        private static void ListarTodosLosClientes()
        {
            Sistema s = Sistema.Instancia();

            try
            {
                List<Cliente> clientes = s.ObtenerClientesUsuario();

                if (clientes.Count == 0)
                {
                    Console.WriteLine("No hay clientes registrados.");
                }
                else
                {
                    Console.WriteLine("Clientes registrados:");
                    foreach (Cliente c in clientes)
                    {
                        Console.WriteLine(c.ToString()); // Muestra la lista de clientes
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener los clientes: " + ex.Message);
            }
        }

        #endregion

        //****************************************************
        // ************* METODO PARA LISTAR VUELOS **********
        //****************************************************

        #region METODO LISTAR VUELOS
        private static void ListarVuelos()
        {
            Sistema s = Sistema.Instancia();
            try
            {
                Console.WriteLine("Debe ingresar un codigo Aeropuerto, este debe ser en formato IATA.");
                Console.WriteLine("Este debe tener 3 letras. Ejemplo: MVD - Montevideo");

                string codigoIata = Console.ReadLine();

                // Obtener la lista de vuelos
                List<Vuelo> vuelos = s.ObtenerVuelos(codigoIata);

                // Verificar si la lista está vacía
                if (vuelos.Count == 0)
                {
                    Console.WriteLine("No hay vuelos registrados para este aeropuerto.");
                }
                else
                {
                    Console.WriteLine("Vuelos registrados:");
                    // Mostrar cada vuelo usando ToString
                    foreach (Vuelo vuelo in vuelos)
                    {
                        Console.WriteLine(vuelo.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener los vuelos: " + ex.Message);
            }
        }

        #endregion



        //**************************************************************************
        //****************** METODO PARA DAR ALTA A CLIENTE OCACIONAL **********
        //**************************************************************************

        #region METODO ALTA CLIENTE OCACIONAL
        private static void DarAltaClienteOcasional()
        {
            try
            {
                Console.Write("Ingrese Documento : ");
                int documento = int.Parse(Console.ReadLine());

                Console.Write("Ingrese Nacionalidad : ");
                string nacionalidad = Console.ReadLine();

                Console.Write("Ingrese Email : ");
                string email = Console.ReadLine();


                Console.Write("Ingrese su contraseña : ");
                string password = Console.ReadLine();

                Console.Write("Ingrese nombre: ");
                string nombre = Console.ReadLine();

                Console.Write("¿Es elegible? (s/n): ");
                string respuesta = Console.ReadLine().ToLower();
                bool esElegible = respuesta == "s" || respuesta == "si";

                ClienteOcasional nuevoCliente = new ClienteOcasional(documento, nombre, nacionalidad, email, password, esElegible);

                Sistema s = Sistema.Instancia();


                // Verificar si el cliente ya existe antes de darlo de alta
                if (s.VerificarClienteExistencia(documento,email))
                {
                    Console.WriteLine("El cliente con ese documento ya está registrado.");
                }
                else
                {
                    // Si no existe, realizar el alta
                    s.AltaCliente(nuevoCliente);
                    Console.WriteLine("Cliente ocasional dado de alta exitosamente.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error al dar de alta el cliente: {ex.Message}");
            }
        }

        #endregion



        //*********************************************************************************
        //  ************************ METODO PARA LISTAR PASAJES *************************
        //*********************************************************************************

        #region METODO PARA LISTAR LOS PASAJES 

        private static void ListarPasajes()
        {
            Sistema s = Sistema.Instancia();
            try
            {
                DateTime fecha1 = PedirFecha("Ingrese la primera fecha");
                DateTime fecha2 = PedirFecha("Ingrese la segunda fecha");

                List<Pasaje> pasajes = s.ObtenerPasajes(fecha1, fecha2);

                Console.WriteLine($"Fecha 1: {fecha1:yyyy-MM-dd}, Fecha 2: {fecha2:yyyy-MM-dd}"); // Ver las fechas ingresadas

                // Verificar si la lista está vacía
                if (pasajes.Count == 0)
                {
                    Console.WriteLine("No hay pasajes registrados para estas dos fechas");
                }
                else
                {
                    Console.WriteLine("Pasajes registrados:");
                    // Mostrar cada vuelo usando ToString
                    foreach (Pasaje pasaje in pasajes)
                    {
                        Console.WriteLine(pasaje.ToString()); // Ver las fechas de los pasajes
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error al listar los Pasajes: {ex.Message}");
            }
        }

        //*****************************************************************************
        //****************** METODO PARA PEDIR FECHA AL USARIO **********************
        //*****************************************************************************
        private static DateTime PedirFecha(string mensaje)
        {
            DateTime fecha;
            while (true)
            {
                Console.Write($"{mensaje} (formato yyyy-MM-dd): ");
                string input = Console.ReadLine();

                if (DateTime.TryParse(input, out fecha))
                {
                    Console.WriteLine($"Fecha ingresada correctamente: {fecha:yyyy-MM-dd}");
                    return fecha;
                }
                else
                {
                    Console.WriteLine("Formato de fecha incorrecto. Intente nuevamente.");
                }
            }

        }

        #endregion






    }

}
