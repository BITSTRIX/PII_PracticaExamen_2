using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PII_PracticaExamen_2
{
    internal class ClsControl
    {
        static int codFactura = 1000;

        int[] numeroFactura = new int[15];
        string[] numeroPlaca = new string[15];
        string[] fechaHora = new string[15];
        int[] tipoVehiculo = new int[15];
        int[] numeroCaseta = new int[15];
        double[] monto = new double[15];
        double[] pagaCon = new double[15];
        double[] vuelto = new double[15];

        public void IniciarVectores()
        {
            for (int i = 0; i < 15; i++)
            {
                numeroFactura[i] = 0;
                numeroPlaca[i] = string.Empty;
                fechaHora[i] = string.Empty;
                tipoVehiculo[i] = 0;
                numeroCaseta[i] = 0;
                monto[i] = 0;
                pagaCon[i] = 0;
                vuelto[i] = 0;
            }
            Console.WriteLine("Vectores iniciados.");

        }

        public void CargaDatos()
        {
            numeroFactura[0] = 20;
            numeroPlaca[0] = "101010";
            fechaHora[0] = Convert.ToString(DateTime.Now);
            tipoVehiculo[0] = 1;
            numeroCaseta[0] = 3;
            monto[0] = 500;
            pagaCon[0] = 1000;
            vuelto[0] = 500;

            numeroFactura[1] = 21;
            numeroPlaca[1] = "202020";
            fechaHora[1] = Convert.ToString(DateTime.Now);
            tipoVehiculo[1] = 4;
            numeroCaseta[1] = 1;
            monto[1] = 3700;
            pagaCon[1] = 5000;
            vuelto[1] = 1300;

            numeroFactura[2]= 22;
            numeroPlaca[2] = "303030";
            fechaHora[2] = Convert.ToString(DateTime.Now);
            tipoVehiculo[2] = 2;
            numeroCaseta[2] = 2;
            monto[2] = 700;
            pagaCon[2] = 700;
            vuelto[2] = 0;

            Console.WriteLine("Datos cargados.");
        }

        public void IngresarVehiculo()
        {
            int tempCodFactura = 0;
            string tempFecha = "";
            int tempTipoVec = 0;
            int tempCaseta = 0;
            string tempPlaca = "";
            double tempMonto = 0;
            double tempVuelto = 0;

            Console.WriteLine("\t\tREGISTRAR FLUJO VEHICULAR");
            tempCodFactura =GenerarIDFactura();
            Console.WriteLine("Numero de Factura: " + tempCodFactura);
            tempFecha = Convert.ToString(DateTime.Now);
            Console.WriteLine("Fecha y Hora: " + tempFecha);
            Console.WriteLine("Ingrese el numero de placa del Vehiculo: ");
            tempPlaca = (Console.ReadLine());
            do
            {
                Console.WriteLine("Ingrese el tipo de Vehiculo:");
                Console.WriteLine("[1= Moto\t\t2= Vehículo Liviano\t\t3=Camión o Pesado\t\t4=Autobús]");
                if (int.TryParse(Console.ReadLine(), out tempTipoVec))
                {
                    if (tempTipoVec >= 1 && tempTipoVec <= 4)
                    {
                        break;
                    }
                }
                Console.WriteLine("Entrada no válida. Debe ingresar 1, 2, 3 o 4.");
            } while (true);

            do
            {
                Console.WriteLine("Ingrese el numero de Caseta: ");
                Console.WriteLine("[1= Caseta 1.\t\t2= Caseta 2.\t\t3=Caseta 3.]");
                if (int.TryParse(Console.ReadLine(), out tempCaseta))
                {
                    if (tempCaseta >= 1 && tempCaseta <= 3)
                    {
                        break;
                    }
                }
                Console.WriteLine("Entrada no válida. Debe ingresar 1, 2 o 3.");
            } while (true);
            Console.WriteLine($"El monto a pagar por el Conductor es: {ValidarPrecio(tempTipoVec)} colones");
            Console.WriteLine("Ingrese el monto con el cual paga el peaje: ");
            tempMonto = Convert.ToDouble(Console.ReadLine());
            tempVuelto = tempMonto - ValidarPrecio(tempTipoVec);
            Console.WriteLine($"El vuelto es de: {tempVuelto} colones");
            Console.WriteLine("Desea almacenar la transaccion(Y/N)?");
            string almacenar = Console.ReadLine();

            if ( almacenar == "y" || almacenar == "Y")
            {
                Boolean almacenado = false;
                for (int i = 0; i < 15; i++)
                {
                    if (numeroFactura[i] == 0)
                    {
                        numeroFactura[i] = tempCodFactura;
                        numeroPlaca[i] = tempPlaca;
                        fechaHora[i] = tempFecha;
                        tipoVehiculo[i] = tempTipoVec;
                        numeroCaseta[i] =tempCaseta;
                        monto[i] = ValidarPrecio(tempTipoVec);
                        pagaCon[i] = tempMonto;
                        vuelto[i] = tempVuelto;
                        Console.WriteLine("El registro se almaceno correctamente.");
                        Console.ReadLine();
                        almacenado = true;
                        break;
                    }
                    

                }
                if (almacenado == false)
                {
                    Console.WriteLine("No hay espacio en la base de datos.");
                }
            }
        }

        public static double ValidarPrecio(int Tipo)
        {
            int Precio = 0;
            if (Tipo == 1)
            {
                Precio = 500;
                return Precio;
            }
            else if (Tipo == 2)
            {
                Precio = 700;
                return Precio;
            }
            else if (Tipo == 3)
            {
                Precio = 2700;
                return Precio;
            }
            else if (Tipo == 4)
            {
                Precio = 3700;
                return Precio;
            }
            return Precio;
        }

        public static string TipoVehiculo(int Tipo)
        {
            string TipoVehiculo = null;
            if (Tipo == 1)
            {
                TipoVehiculo = "Moto";
                return TipoVehiculo;
            }
            else if (Tipo == 2)
            {
                TipoVehiculo = "V. Liviano";
                return TipoVehiculo;
            }
            else if (Tipo == 3)
            {
                TipoVehiculo = "Camion Pesado";
                return TipoVehiculo;
            }
            else if (Tipo == 4)
            {
                TipoVehiculo = "Autobus";
                return TipoVehiculo;
            }
            return null;
        }

        public void ConsultarPlaca()
        {
            Console.WriteLine("Ingrese el numero de placa a consultar: ");
            string Placa = Console.ReadLine();
            Boolean encontrado = false;
            Console.WriteLine("\t\t\t\t\t REPORTE POR NUMERO DE PLACA\t\t\t");
            Console.WriteLine("=========================================================================================================");
            Console.WriteLine("N. factura\tPlaca\tTipo de vehículo\tN. Caseta\tMonto Pagar\tPaga con\tVuelto");
            Console.WriteLine("=========================================================================================================");
            for (int i = 0; i < 15; i++)
            {
                if (numeroPlaca[i] == Placa)
                {
                    Console.WriteLine($"{numeroFactura[i]}\t\t{numeroPlaca[i]}\t\t{TipoVehiculo(tipoVehiculo[i])}\t\t{numeroCaseta[i]}\t\t{monto[i]}\t\t{pagaCon[i]}\t\t{vuelto[i]}");
                    encontrado = true;
                } 
            }
            if (encontrado == false)
            {
                Console.WriteLine("********* No hay registros con la placa ingresada *********");
            }
            Console.WriteLine("========================================================================================================");
            Console.WriteLine("                                 PRESIONE CUALQUIER TECLA PARA CONTINUAR.                               ");
            Console.ReadKey();
        }

        public void ConsultarDatos()
        {
            Boolean encontrado = false;
            Console.WriteLine("\t\t\t\t\tREPORTE DE TODOS LOS DATOS\t\t\t");
            Console.WriteLine("========================================================================================================");
            Console.WriteLine("N. factura\tPlaca\tTipo de vehículo\t N. Caseta\tMonto Pagar\tPaga con\tVuelto");
            Console.WriteLine("========================================================================================================");
            for (int i = 0; i < 15; i++)
            {
                if (numeroPlaca[i] != string.Empty)
                {
                    Console.WriteLine($"{numeroFactura[i]}\t\t{numeroPlaca[i]}\t\t{TipoVehiculo(tipoVehiculo[i])}\t\t{numeroCaseta[i]}\t\t{monto[i]}\t\t{pagaCon[i]}\t\t{vuelto[i]}");
                    encontrado = true;
                }
            }
            if (encontrado == false)
            {
                Console.WriteLine("********* No hay registros en la base de datos *********");
            }
            Console.WriteLine("========================================================================================================");
            Console.WriteLine("                                 PRESIONE CUALQUIER TECLA PARA CONTINUAR.                               ");
            Console.ReadKey();
        }

        static int GenerarIDFactura() { 
            int idFactura = codFactura;
            codFactura++;
            return idFactura;
        }
    }


}
