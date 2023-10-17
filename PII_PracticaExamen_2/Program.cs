using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PII_PracticaExamen_2;

namespace PII_PracticaExamen_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ClsControl control = new ClsControl();

            int opcion = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Menú Principal del Sistema:");
                Console.WriteLine("1. Inicializar Vectores");
                Console.WriteLine("2. Ingresar Paso Vehicular");
                Console.WriteLine("3. Consulta de vehículos por Número de Placa");
                Console.WriteLine("4. Modificar Datos de Vehículos por Número de Placa");
                Console.WriteLine("5. Reporte Todos los Datos de los Vectores");
                Console.WriteLine("6. Salir");

                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        control.IniciarVectores();
                        control.CargaDatos();
                        break;
                    case 2:
                        control.IngresarVehiculo();
                        break;
                    case 3:
                        control.ConsultarPlaca();
                        break;
                    case 4:
                        break;
                    case 5:
                        control.ConsultarDatos();
                        break;
                    case 6:
                        break;
                    default:
                        Console.WriteLine("Opcion incorreta, intente de nuevo.");
                        break;
                }

            } while (opcion != 6);
        }
    }
}
