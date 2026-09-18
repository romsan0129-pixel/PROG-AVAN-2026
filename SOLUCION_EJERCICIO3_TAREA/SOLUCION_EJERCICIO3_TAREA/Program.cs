using System;
using System.Text;

namespace Ejercicio3
{
    internal class Program
    {
        // Voltaje máximo que debe alcanzar la batería durante la simulación.
        const double VOLTAJE_OBJETIVO = 12.6;

        static void Main(string[] args)
        {
            // Habilita caracteres especiales en la salida de consola.
            Console.OutputEncoding = Encoding.UTF8;

            // Encabezado solicitado con el planteamiento del ejercicio.
            Console.WriteLine("============================================================");
            Console.WriteLine("EJERCICIO 3 - SIMULACIÓN DE CARGA DE UNA BATERÍA DE 12.6 V");
            Console.WriteLine("Leer el voltaje inicial y el incremento por ciclo; usar");
            Console.WriteLine("while para aumentar el voltaje hasta alcanzar 12.6 V.");
            Console.WriteLine("============================================================\n");

            // Entrada de datos: voltaje inicial e incremento aplicado en cada ciclo.
            double voltaje = LeerNoNegativo("Voltaje inicial de la batería (V): ");
            double incremento = LeerDouble("Incremento por ciclo (V): ");

            // El planteamiento indica que un incremento menor o igual que cero es inválido.
            if (incremento <= 0)
            {
                Console.WriteLine("\nERROR: el incremento debe ser mayor que cero.");
                Console.WriteLine("La simulación no se ejecutará.");
                return;
            }

            // Contador para numerar cada ciclo de carga mostrado en pantalla.
            int ciclo = 0;

            // Si la batería ya llegó al objetivo, no es necesario ejecutar el ciclo while.
            if (voltaje >= VOLTAJE_OBJETIVO)
            {
                Console.WriteLine(
                    $"\nLa batería ya se encuentra en {voltaje:F2} V; no requiere ciclos de carga.");
                return;
            }

            Console.WriteLine("\nSimulación de carga:");

            // El ciclo continúa mientras el voltaje sea menor que 12.6 V.
            while (voltaje < VOLTAJE_OBJETIVO)
            {
                ciclo++;

                // Math.Min impide que el valor mostrado exceda el voltaje objetivo.
                voltaje = Math.Min(voltaje + incremento, VOLTAJE_OBJETIVO);
                Console.WriteLine($"Ciclo {ciclo}: {voltaje:F2} V");
            }

            Console.WriteLine("\nLa batería alcanzó 12.60 V.");
        }

        // Lee un valor numérico y repite la solicitud cuando la entrada es inválida.
        static double LeerDouble(string mensaje)
        {
            double valor;

            while (true)
            {
                Console.Write(mensaje);

                if (double.TryParse(Console.ReadLine(), out valor))
                {
                    return valor;
                }

                Console.WriteLine("Entrada inválida. Escriba un valor numérico.");
            }
        }

        // Utiliza LeerDouble y además comprueba que el voltaje inicial no sea negativo.
        static double LeerNoNegativo(string mensaje)
        {
            double valor;

            do
            {
                valor = LeerDouble(mensaje);

                if (valor >= 0)
                {
                    return valor;
                }

                Console.WriteLine("El voltaje inicial no puede ser negativo.");
            }
            while (true);
        }
    }
}
