using System;
using System.Text;

namespace Ejercicio2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Habilita la salida UTF-8 para mostrar correctamente ° y caracteres acentuados.
            Console.OutputEncoding = Encoding.UTF8;

            // Encabezado solicitado con el planteamiento del ejercicio.
            Console.WriteLine("============================================================");
            Console.WriteLine("EJERCICIO 2 - TEMPERATURA PROMEDIO DE UN MOTOR");
            Console.WriteLine("Solicitar 10 mediciones con un ciclo, calcular el promedio");
            Console.WriteLine("y clasificarlo con respecto al límite de 70 °C.");
            Console.WriteLine("============================================================\n");

            // Acumulador donde se sumarán las diez mediciones.
            double sumaTemperaturas = 0;

            // El ciclo for permite escribir una sola vez la instrucción de captura.
            for (int i = 1; i <= 10; i++)
            {
                // Se solicita y valida la medición correspondiente a cada repetición.
                double temperatura = LeerDouble($"Temperatura #{i} (°C): ");
                sumaTemperaturas += temperatura;
            }

            // Se calcula el promedio dividiendo la suma entre las diez mediciones.
            double promedio = sumaTemperaturas / 10;
            Console.WriteLine($"\nTemperatura promedio: {promedio:F2} °C");

            // Se clasifica el estado térmico según el límite de 70 °C.
            if (promedio <= 70)
            {
                Console.WriteLine("TEMPERATURA NORMAL.");
            }
            else
            {
                Console.WriteLine("ALERTA DE TEMPERATURA.");
            }
        }

        // Lee un número de tipo double y vuelve a solicitarlo si la entrada no es numérica.
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
    }
}
