using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{


    public class Sistema
    {
        //*********************************************
        // *********** LISTAS DE SISTEMA *************
        //*********************************************
        private List<Usuario> _usuarios = new List<Usuario>();
        private List<Vuelo> _vuelos = new List<Vuelo>();
        private List<Aeropuerto> _aeropuertos = new List<Aeropuerto>();
        private List<Pasaje> _pasajes = new List<Pasaje>();
        private List<Ruta> _rutas = new List<Ruta>();
        private List<Avion> _aviones = new List<Avion>();


        #region Singleton
        private static Sistema _instancia;
        public static Sistema Instancia()
        {
            if (_instancia == null)
            {
                _instancia = new Sistema();
            }
            return _instancia;
        }
        #endregion

        //********************************************************************
        //  ************** METODOS DE PRECARGAS DEL SISTEMA ***************
        //********************************************************************
        public Sistema()
        {
            PrecargarUsuarios();
            PrecargarAviones();
            PrecargarAeropuertos();
            PrecargarRutas();
            PrecargarVuelos();
            PrecargarPasajes();
        }

        #region  PRECARGA USUARIOS

        public void PrecargarUsuarios()
        {
            PrecargarClientes();
            PrecargarAdministradores();
        }

        #endregion

        #region PRECARGA CLIENTES
        public void PrecargarClientes()
        {
            Cliente cp1 = new ClientePremium(1001, "Juan Pérez", "Uruguayo", "juanp@gmail.com", "juan0123", 1200,false);
            Cliente cp2 = new ClientePremium(1002, "María López", "Argentina", "mlopez@hotmail.com", "maria0123", 980, false);
            Cliente cp3 = new ClientePremium(1003, "Carlos Méndez", "Chileno", "cmendez@yahoo.com", "carlos0123", 1500, false);
            Cliente cp4 = new ClientePremium(1004, "Lucía Fernández", "Uruguaya", "luciaf@gmail.com", "lucia0123", 2000, false);
            Cliente cp5 = new ClientePremium(1005, "Lucas Correa", "Uruguayo", "lucas@correo.com", "lucas0123", 1700, false);

            Cliente co1 = new ClienteOcasional(2001, "Pedro González", "Uruguayo", "pedrog@gmail.com", "pedro0123", true, false);
            Cliente co2 = new ClienteOcasional(2002, "Laura Martínez", "Argentina", "lauramartinez@hotmail.com", "laura0123", false, false);
            Cliente co3 = new ClienteOcasional(2003, "Jorge Ramírez", "Chileno", "jorger@outlook.com", "jorge0123", true, false);
            Cliente co4 = new ClienteOcasional(2004, "Ana Ruiz", "Uruguaya", "anaruiz@gmail.com", "ana01234", false, false);
            Cliente co5 = new ClienteOcasional(2005, "Luis Sánchez", "Peruano", "luissanchez@yahoo.com", "luis0123", true, false);
            AltaCliente(cp1);
            AltaCliente(cp2);
            AltaCliente(cp3);
            AltaCliente(cp4);
            AltaCliente(cp5);
            AltaCliente(co1);
            AltaCliente(co2);
            AltaCliente(co3);
            AltaCliente(co4);
            AltaCliente(co5);
        }

        #endregion

        #region PRECARGA ADMINISTRADORES

        public void PrecargarAdministradores()
        {

            Administrador a1 = new Administrador("admin1@empresa.com", "admin123", "admin1");
            Administrador a2 = new Administrador("admin2@empresa.com", "admin456", "admin2");
            AltaAdministrador(a1);
            AltaAdministrador(a2);
        }
        #endregion


        #region PRECARGA AVIONES
        public void PrecargarAviones()
        {
            Avion avion1 = new Avion("Boeing", "737", 180, 4000, 5000);
            Avion avion2 = new Avion("Airbus", "A320", 190, 4200, 5300);
            Avion avion3 = new Avion("Embraer", "E195", 120, 3700, 4000);
            Avion avion4 = new Avion("Bombardier", "CRJ900", 90, 3500, 4500);
            AltaAvion(avion1);
            AltaAvion(avion2);
            AltaAvion(avion3);
            AltaAvion(avion4);
        }


        #endregion



        #region PRECARGA AEROPUERTO
        public void PrecargarAeropuertos()
        {
            Aeropuerto a1 = new Aeropuerto("MVD", "Montevideo", 1500, 300);
            Aeropuerto a2 = new Aeropuerto("BSB", "Brasilia", 2000, 350);
            Aeropuerto a3 = new Aeropuerto("EZE", "Buenos Aires", 1800, 320);
            Aeropuerto a4 = new Aeropuerto("SCL", "Santiago", 2100, 340);
            Aeropuerto a5 = new Aeropuerto("LIM", "Lima", 1900, 330);
            Aeropuerto a6 = new Aeropuerto("BOG", "Bogotá", 2200, 360);
            Aeropuerto a7 = new Aeropuerto("MEX", "Ciudad de México", 2500, 380);
            Aeropuerto a8 = new Aeropuerto("GRU", "São Paulo", 2300, 370);
            Aeropuerto a9 = new Aeropuerto("CCS", "Caracas", 1700, 310);
            Aeropuerto a10 = new Aeropuerto("PTY", "Panamá", 2400, 350);
            Aeropuerto a11 = new Aeropuerto("JFK", "Nueva York", 3000, 500);
            Aeropuerto a12 = new Aeropuerto("LAX", "Los Ángeles", 3100, 520);
            Aeropuerto a13 = new Aeropuerto("ORD", "Chicago", 2950, 480);
            Aeropuerto a14 = new Aeropuerto("MIA", "Miami", 2800, 470);
            Aeropuerto a15 = new Aeropuerto("ATL", "Atlanta", 2900, 490);
            Aeropuerto a16 = new Aeropuerto("MAD", "Madrid", 2600, 410);
            Aeropuerto a17 = new Aeropuerto("CDG", "París", 2650, 420);
            Aeropuerto a18 = new Aeropuerto("LHR", "Londres", 2700, 430);
            Aeropuerto a19 = new Aeropuerto("FRA", "Frankfurt", 2750, 440);
            Aeropuerto a20 = new Aeropuerto("BCN", "Barcelona", 2550, 400);
            AltaAeropuerto(a1);
            AltaAeropuerto(a2);
            AltaAeropuerto(a3);
            AltaAeropuerto(a4);
            AltaAeropuerto(a5);
            AltaAeropuerto(a6);
            AltaAeropuerto(a7);
            AltaAeropuerto(a8);
            AltaAeropuerto(a9);
            AltaAeropuerto(a10);
            AltaAeropuerto(a11);
            AltaAeropuerto(a12);
            AltaAeropuerto(a13);
            AltaAeropuerto(a14);
            AltaAeropuerto(a15);
            AltaAeropuerto(a16);
            AltaAeropuerto(a17);
            AltaAeropuerto(a18);
            AltaAeropuerto(a19);
            AltaAeropuerto(a20);

        }


        #endregion

        #region PRECARGA RUTAS

        public void PrecargarRutas()
        {
            Ruta r1 = new Ruta(_aeropuertos[0], _aeropuertos[1], 800);
            Ruta r2 = new Ruta(_aeropuertos[2], _aeropuertos[3], 1200);
            Ruta r3 = new Ruta(_aeropuertos[4], _aeropuertos[5], 950);
            Ruta r4 = new Ruta(_aeropuertos[6], _aeropuertos[7], 600);
            Ruta r5 = new Ruta(_aeropuertos[8], _aeropuertos[9], 1500);
            Ruta r6 = new Ruta(_aeropuertos[10], _aeropuertos[11], 3200);
            Ruta r7 = new Ruta(_aeropuertos[12], _aeropuertos[13], 2500);
            Ruta r8 = new Ruta(_aeropuertos[14], _aeropuertos[15], 1000);
            Ruta r9 = new Ruta(_aeropuertos[16], _aeropuertos[17], 700);
            Ruta r10 = new Ruta(_aeropuertos[18], _aeropuertos[19], 1300);
            Ruta r11 = new Ruta(_aeropuertos[1], _aeropuertos[3], 1100);
            Ruta r12 = new Ruta(_aeropuertos[5], _aeropuertos[7], 1400);
            Ruta r13 = new Ruta(_aeropuertos[9], _aeropuertos[11], 1600);
            Ruta r14 = new Ruta(_aeropuertos[13], _aeropuertos[15], 900);
            Ruta r15 = new Ruta(_aeropuertos[17], _aeropuertos[19], 2400);
            Ruta r16 = new Ruta(_aeropuertos[0], _aeropuertos[2], 1050);
            Ruta r17 = new Ruta(_aeropuertos[4], _aeropuertos[6], 1250);
            Ruta r18 = new Ruta(_aeropuertos[8], _aeropuertos[10], 980);
            Ruta r19 = new Ruta(_aeropuertos[12], _aeropuertos[14], 890);
            Ruta r20 = new Ruta(_aeropuertos[16], _aeropuertos[18], 1750);
            Ruta r21 = new Ruta(_aeropuertos[1], _aeropuertos[4], 2000);
            Ruta r22 = new Ruta(_aeropuertos[7], _aeropuertos[10], 1450);
            Ruta r23 = new Ruta(_aeropuertos[11], _aeropuertos[13], 2150);
            Ruta r24 = new Ruta(_aeropuertos[15], _aeropuertos[17], 1950);
            Ruta r25 = new Ruta(_aeropuertos[19], _aeropuertos[0], 2300);
            Ruta r26 = new Ruta(_aeropuertos[2], _aeropuertos[5], 870);
            Ruta r27 = new Ruta(_aeropuertos[6], _aeropuertos[9], 770);
            Ruta r28 = new Ruta(_aeropuertos[10], _aeropuertos[12], 1430);
            Ruta r29 = new Ruta(_aeropuertos[14], _aeropuertos[16], 1120);
            Ruta r30 = new Ruta(_aeropuertos[18], _aeropuertos[1], 990);
            AltaRuta(r1);
            AltaRuta(r2);
            AltaRuta(r3);
            AltaRuta(r4);
            AltaRuta(r5);
            AltaRuta(r6);
            AltaRuta(r7);
            AltaRuta(r8);
            AltaRuta(r9);
            AltaRuta(r10);
            AltaRuta(r11);
            AltaRuta(r12);
            AltaRuta(r13);
            AltaRuta(r14);
            AltaRuta(r15);
            AltaRuta(r16);
            AltaRuta(r17);
            AltaRuta(r18);
            AltaRuta(r19);
            AltaRuta(r20);
            AltaRuta(r21);
            AltaRuta(r22);
            AltaRuta(r23);
            AltaRuta(r24);
            AltaRuta(r25);
            AltaRuta(r26);
            AltaRuta(r27);
            AltaRuta(r28);
            AltaRuta(r29);
            AltaRuta(r30);

        }

        #endregion


        #region PRECARGA VUELO
        public void PrecargarVuelos()
        {

            Vuelo v1 = new Vuelo("AR101", _aviones[0], new DateTime(2025, 8, 06), _rutas[0]);
            Vuelo v2 = new Vuelo("LA202", _aviones[1], new DateTime(2025, 8, 07), _rutas[1]);
            Vuelo v3 = new Vuelo("CM303", _aviones[2], new DateTime(2025, 8, 08), _rutas[2]);
            Vuelo v4 = new Vuelo("AV404", _aviones[3], new DateTime(2025, 8, 09), _rutas[3]);
            Vuelo v5 = new Vuelo("IB505", _aviones[0], new DateTime(2025, 8, 10), _rutas[4]);
            Vuelo v6 = new Vuelo("AF606", _aviones[1], new DateTime(2025, 8, 11), _rutas[5]);
            Vuelo v7 = new Vuelo("DL707", _aviones[2], new DateTime(2025, 8, 12), _rutas[6]);
            Vuelo v8 = new Vuelo("UA808", _aviones[3], new DateTime(2025, 8, 13), _rutas[7]);
            Vuelo v9 = new Vuelo("BA909", _aviones[0], new DateTime(2025, 8, 14), _rutas[8]);
            Vuelo v10 = new Vuelo("KL010", _aviones[1], new DateTime(2025, 8, 15), _rutas[9]);
            Vuelo v11 = new Vuelo("LH111", _aviones[2], new DateTime(2025, 8, 16), _rutas[10]);
            Vuelo v12 = new Vuelo("AZ222", _aviones[3], new DateTime(2025, 8, 17), _rutas[11]);
            Vuelo v13 = new Vuelo("UX333", _aviones[0], new DateTime(2025, 8, 18), _rutas[12]);
            Vuelo v14 = new Vuelo("TP444", _aviones[1], new DateTime(2025, 8, 19), _rutas[13]);
            Vuelo v15 = new Vuelo("SK555", _aviones[2], new DateTime(2025, 8, 20), _rutas[14]);
            Vuelo v16 = new Vuelo("JJ666", _aviones[3], new DateTime(2025, 8, 21), _rutas[15]);
            Vuelo v17 = new Vuelo("AC777", _aviones[0], new DateTime(2025, 8, 22), _rutas[16]);
            Vuelo v18 = new Vuelo("EK888", _aviones[1], new DateTime(2025, 8, 23), _rutas[17]);
            Vuelo v19 = new Vuelo("ET999", _aviones[2], new DateTime(2025, 8, 24), _rutas[18]);
            Vuelo v20 = new Vuelo("AI123", _aviones[3], new DateTime(2025, 8, 25), _rutas[19]);
            Vuelo v21 = new Vuelo("NH234", _aviones[0], new DateTime(2025, 8, 26), _rutas[20]);
            Vuelo v22 = new Vuelo("SQ345", _aviones[1], new DateTime(2025, 8, 27), _rutas[21]);
            Vuelo v23 = new Vuelo("CX456", _aviones[2], new DateTime(2025, 8, 28), _rutas[22]);
            Vuelo v24 = new Vuelo("JL567", _aviones[3], new DateTime(2025, 8, 29), _rutas[23]);
            Vuelo v25 = new Vuelo("QF678", _aviones[0], new DateTime(2025, 8, 30), _rutas[24]);
            Vuelo v26 = new Vuelo("NZ789", _aviones[1], new DateTime(2025, 8, 13), _rutas[25]);
            Vuelo v27 = new Vuelo("VS890", _aviones[2], new DateTime(2025, 8, 01), _rutas[26]);
            Vuelo v28 = new Vuelo("TK901", _aviones[3], new DateTime(2025, 8, 02), _rutas[27]);
            Vuelo v29 = new Vuelo("MS012", _aviones[0], new DateTime(2025, 8, 03), _rutas[28]);
            Vuelo v30 = new Vuelo("LO123", _aviones[1], new DateTime(2025, 8, 04), _rutas[29]);
            AltaVuelo(v1);
            AltaVuelo(v2);
            AltaVuelo(v3);
            AltaVuelo(v4);
            AltaVuelo(v5);
            AltaVuelo(v6);
            AltaVuelo(v7);
            AltaVuelo(v8);
            AltaVuelo(v9);
            AltaVuelo(v10);
            AltaVuelo(v11);
            AltaVuelo(v12);
            AltaVuelo(v13);
            AltaVuelo(v14);
            AltaVuelo(v15);
            AltaVuelo(v16);
            AltaVuelo(v17);
            AltaVuelo(v18);
            AltaVuelo(v19);
            AltaVuelo(v20);
            AltaVuelo(v21);
            AltaVuelo(v22);
            AltaVuelo(v23);
            AltaVuelo(v24);
            AltaVuelo(v25);
            AltaVuelo(v26);
            AltaVuelo(v27);
            AltaVuelo(v28);
            AltaVuelo(v29);
            AltaVuelo(v30);

        }


        #endregion


        #region PRECARGA PASAJE
        public void PrecargarPasajes()
        {



            Pasaje p1 = new Pasaje(_vuelos[0], new DateTime(2025, 08, 06), ObtenerCliente(1001), Equipaje.Cabina, 150);
            Pasaje p2 = new Pasaje(_vuelos[1], new DateTime(2025, 08, 07), ObtenerCliente(1002), Equipaje.Light, 180);
            Pasaje p3 = new Pasaje(_vuelos[2], new DateTime(2025, 08, 08), ObtenerCliente(1003), Equipaje.Bodega, 200);
            Pasaje p4 = new Pasaje(_vuelos[3], new DateTime(2025, 08, 09), ObtenerCliente(1004), Equipaje.Cabina, 250);
            Pasaje p5 = new Pasaje(_vuelos[4], new DateTime(2025, 08, 10), ObtenerCliente(1005), Equipaje.Light, 300);
            Pasaje p6 = new Pasaje(_vuelos[5], new DateTime(2025, 08, 11), ObtenerCliente(2001), Equipaje.Cabina, 120);
            Pasaje p7 = new Pasaje(_vuelos[6], new DateTime(2025, 08, 12), ObtenerCliente(2002), Equipaje.Bodega, 130);
            Pasaje p8 = new Pasaje(_vuelos[7], new DateTime(2025, 08, 13), ObtenerCliente(2003), Equipaje.Light, 140);
            Pasaje p9 = new Pasaje(_vuelos[8], new DateTime(2025, 08, 14), ObtenerCliente(2004), Equipaje.Cabina, 160);
            Pasaje p10 = new Pasaje(_vuelos[9], new DateTime(2025, 08, 15), ObtenerCliente(2005), Equipaje.Light, 170);
            Pasaje p11 = new Pasaje(_vuelos[10], new DateTime(2025, 08, 16), ObtenerCliente(1001), Equipaje.Bodega, 180);
            Pasaje p12 = new Pasaje(_vuelos[11], new DateTime(2025, 08, 17), ObtenerCliente(1002), Equipaje.Cabina, 190);
            Pasaje p13 = new Pasaje(_vuelos[12], new DateTime(2025, 08, 18), ObtenerCliente(1003), Equipaje.Bodega, 210);
            Pasaje p14 = new Pasaje(_vuelos[13], new DateTime(2025, 08, 19), ObtenerCliente(1004), Equipaje.Light, 220);
            Pasaje p15 = new Pasaje(_vuelos[14], new DateTime(2025, 08, 20), ObtenerCliente(1005), Equipaje.Bodega, 230);
            Pasaje p16 = new Pasaje(_vuelos[15], new DateTime(2025, 08, 21), ObtenerCliente(2001), Equipaje.Light, 240);
            Pasaje p17 = new Pasaje(_vuelos[16], new DateTime(2025, 08, 22), ObtenerCliente(2002), Equipaje.Bodega, 250);
            Pasaje p18 = new Pasaje(_vuelos[17], new DateTime(2025, 08, 23), ObtenerCliente(2003), Equipaje.Cabina, 260);
            Pasaje p19 = new Pasaje(_vuelos[18], new DateTime(2025, 08, 24), ObtenerCliente(2004), Equipaje.Light, 270);
            Pasaje p20 = new Pasaje(_vuelos[19], new DateTime(2025, 08, 25), ObtenerCliente(2005), Equipaje.Light, 280);
            Pasaje p21 = new Pasaje(_vuelos[20], new DateTime(2025, 08, 26), ObtenerCliente(1001), Equipaje.Bodega, 290);
            Pasaje p22 = new Pasaje(_vuelos[21], new DateTime(2025, 08, 27), ObtenerCliente(1002), Equipaje.Cabina, 300);
            Pasaje p23 = new Pasaje(_vuelos[22], new DateTime(2025, 08, 28), ObtenerCliente(1003), Equipaje.Bodega, 310);
            Pasaje p24 = new Pasaje(_vuelos[23], new DateTime(2025, 08, 29), ObtenerCliente(1004), Equipaje.Light, 320);
            Pasaje p25 = new Pasaje(_vuelos[24], new DateTime(2025, 08, 30), ObtenerCliente(1005), Equipaje.Bodega, 330);
            Pasaje p26 = new Pasaje(_vuelos[25], new DateTime(2025, 08, 13), ObtenerCliente(2001), Equipaje.Cabina, 340);
            Pasaje p27 = new Pasaje(_vuelos[26], new DateTime(2025, 08, 01), ObtenerCliente(2002), Equipaje.Light, 350);
            Pasaje p28 = new Pasaje(_vuelos[27], new DateTime(2025, 08, 02), ObtenerCliente(2003), Equipaje.Bodega, 360);
            Pasaje p29 = new Pasaje(_vuelos[28], new DateTime(2025, 08, 03), ObtenerCliente(2004), Equipaje.Cabina, 370);
            Pasaje p30 = new Pasaje(_vuelos[29], new DateTime(2025, 08, 04), ObtenerCliente(2005), Equipaje.Light, 380);
            AltaPasaje(p1);
            AltaPasaje(p2);
            AltaPasaje(p3);
            AltaPasaje(p4);
            AltaPasaje(p5);
            AltaPasaje(p6);
            AltaPasaje(p7);
            AltaPasaje(p8);
            AltaPasaje(p9);
            AltaPasaje(p10);
            AltaPasaje(p11);
            AltaPasaje(p12);
            AltaPasaje(p13);
            AltaPasaje(p14);
            AltaPasaje(p15);
            AltaPasaje(p16);
            AltaPasaje(p17);
            AltaPasaje(p18);
            AltaPasaje(p19);
            AltaPasaje(p20);
            AltaPasaje(p21);
            AltaPasaje(p22);
            AltaPasaje(p23);
            AltaPasaje(p24);
            AltaPasaje(p25);
            AltaPasaje(p26);
            AltaPasaje(p27);
            AltaPasaje(p28);
            AltaPasaje(p29);
            AltaPasaje(p30);
        }


        #endregion






        // *********************************************************
        //  *************** ALTAS DE  SISTEMA *********************
        // *********************************************************


        #region METODOS DE ALTA

        public void AltaVuelo(Vuelo v)
        {
            v.Validar();
            _vuelos.Add(v);
        }
        public void AltaRuta(Ruta r)
        {
            r.Validar();
            _rutas.Add(r);
        }
        public void AltaAeropuerto(Aeropuerto a)
        {
            a.Validar();
            _aeropuertos.Add(a);
        }

        public void AltaAvion(Avion a)
        {
            a.Validar();
            _aviones.Add(a);
        }

        public void AltaPasaje(Pasaje p)
        {
            p.Validar();
            p.CalcularPrecio();
            _pasajes.Add(p);
        }

        public void AltaCliente(Cliente c)
        {
            c.Validar();
            _usuarios.Add(c);
        }

        public void AltaAdministrador(Administrador a)
        {
            a.Validar();
            _usuarios.Add(a);
        }

        #endregion





        //*****************************************************************
        //***************** METODOS DE LOGICA DEL SISTEMA ****************
        //*****************************************************************


        #region METRODOS DE LA LOGICA DEL SISTEMA 


        //   ************** METODO PARA OBTENER CLIENTE POR MEDIO DE SU DOCUMENTO *******************
        public Cliente ObtenerCliente(int documento)
        {

            foreach (Cliente c in _usuarios)
            {
                if (c.Documento.Equals(documento))
                {
                    return c;
                }
            }
            return null;
        }

        //   ********************* METODO PARA VERIFICAR SI EXISTE UN CLIENTE EN EL SISTEMA POR MEDIO DE SU DOCUMENTO Y EMAIL *******************

        public bool VerificarClienteExistencia(int documento, string email)
        {
            bool Existe = false;

            foreach (Usuario u in _usuarios)
            {
                if (u is Cliente cliente)

                {
                    if (cliente.Documento.Equals(documento) || cliente.Email.ToLower().Equals(email.ToLower()))
                    {
                        Existe = true;

                    }
                }
            }
            return Existe;
        }




        //******* METODO PARA OBTENER LISTA CLIENTES DE USUARIO ******** 
        public List<Cliente> ObtenerClientesUsuario()
        {
            List<Cliente> listaClientes = new List<Cliente>();

            foreach (Usuario u in _usuarios)
            {
                if (u is Cliente cliente)
                {
                    listaClientes.Add(cliente);
                }
            }

            return listaClientes;
        }


        // ***************** METODO PARA OBTENER VUELOS SEGUN UN CODIGO DE AEROPUERTO *********************
        public List<Vuelo> ObtenerVuelos(string codigoIata)
        {
            List<Vuelo> aux = new List<Vuelo>();
            foreach (Vuelo v in _vuelos)
            {
                if (v.Ruta.AeropuertoLlegada.CodigoIata.ToUpper() == codigoIata.ToUpper() || v.Ruta.AeropuertoSalida.CodigoIata.ToUpper() == codigoIata.ToUpper())

                {
                    aux.Add(v);
                }
            }
            return aux;
        }


        //*************** METODO PARA OBTENER TODOS LOS PASAJES ENTRE DOS FECHAS *************************

        public List<Pasaje> ObtenerPasajes(DateTime f1, DateTime f2)
        {
            List<Pasaje> aux = new List<Pasaje>();
            foreach (Pasaje p in _pasajes)
            {
                if (p.Fecha.Date >= f1.Date && p.Fecha.Date <= f2.Date)
                {
                    aux.Add(p);
                }
            }
            return aux;
        }

        //*************** METODO PARA OBTENER TODOS LOS VUELOS  *************************
        public List<Vuelo> ListarVuelos()
        {
            return _vuelos;
        }

        #endregion

        /// <summary>
        /// / Obtiene un vuelo por un id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Vuelo GetVuelo(int id)
        {
            foreach (Vuelo vuelo in _vuelos)
            {
                if (vuelo.Id == id)
                {
                    return vuelo;
                }
            }
            return null;
        }
        /// <summary>
        /// / Obtiene un usuario por su ID
        /// </summary>
        /// <param name="idUsuarioLogueado"></param>
        /// <returns></returns>
        public Usuario GetUsuario(int? idUsuarioLogueado)
        {
            foreach (Usuario usu in _usuarios)
            {
                if (usu.Id.Equals(idUsuarioLogueado))
                {
                    return usu;
                }
            }
            return null;
        }

        /// <summary>
        /// / Método para iniciar sesión de un usuario
        /// </summary>
        /// <param name="email"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public Usuario Login(string email, string pass)
        {

            foreach (Usuario u in _usuarios)
            {
                if (u.Email.Equals(email) && u.Password.Equals(pass))
                {
                    return u;
                }
            }
            return null;
        }
        /// <summary>
        /// / Obtiene un cliente por su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Cliente ObtenerClienteId(int id)
        {
            foreach (Usuario u in _usuarios)
            {
                if (u.Id == id && u is Cliente c)
                {
                    return c;
                }
            }
            return null;
        }

        /// <summary>
        /// Obtiene un pasaje por el vuelo asociado
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public Pasaje ObtenerPasaje(Vuelo v)
        {
            foreach (Pasaje p in _pasajes)
            {
                if (p.Vuelo.Id == v.Id)
                {
                    return p;
                }
            }
            return null;

        }
        /// <summary>
        /// Obtiene una lista de vuelos según la ruta especificada por los códigos IATA de los aeropuertos de salida y llegada.
        /// </summary>
        /// <param name="salida"></param>
        /// <param name="llegada"></param>
        /// <returns></returns>
        public List<Vuelo> ObtenerVuelosPorRuta(string salida, string llegada)
        {
            List<Vuelo> vuelosEncontrados = new List<Vuelo>();

            foreach (Vuelo vuelo in _vuelos)
            {
                if (vuelo.Ruta.AeropuertoSalida.CodigoIata.ToLower().Equals(salida.ToLower()) && vuelo.Ruta.AeropuertoLlegada.CodigoIata.ToLower().Equals(llegada.ToLower()))
                {
                    vuelosEncontrados.Add(vuelo);
                }
            }

            return vuelosEncontrados;
        }

        /// <summary>
        /// Obtiene una lista de pasajes registrados en el sistema.
        /// </summary>
        /// <returns></returns>
        public List<Pasaje> ObtenerPasajes()
        {
            return _pasajes;
        }

        /// <summary>
        /// Obtiene una lista de pasajes asociados a un cliente específico por su ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Pasaje> ObtenerClientePasaje(int id)
        {
            List<Pasaje> p = new List<Pasaje>();
            foreach (Pasaje pc in _pasajes)
            {
                if (pc.Cliente.Id == id)
                {
                    p.Add(pc);
                }
            }
            p.Sort();
            return p;
        }


        /// <summary>
        /// Obtiene un cliente por su documento.
        /// </summary>
        /// <param name="documento"></param>
        /// <returns></returns>
        public Cliente ObtenerClientePorDocumento(int documento)
        {
            foreach (Usuario u in _usuarios)
            {
                if (u is Cliente c && c.Documento == documento)
                {
                    return c;
                }
            }
            return null;
        }

        public Cliente ObtenerIdPremium(int id)
        {
            foreach (Usuario u in _usuarios)
            {
                if (u is Cliente c && c.Id == id && c is ClientePremium)
                {
                    return c;
                }
            }
            return null;
        }

        public void EditarCliente(Cliente c,string nombre)
        {
           c.Nombre = nombre;
        }

        public bool Delate(Cliente c)
        {
            if (!c.Eliminar)
            {
               c.Eliminar = true;
            }
            return c.Eliminar;

        }
    }
}
