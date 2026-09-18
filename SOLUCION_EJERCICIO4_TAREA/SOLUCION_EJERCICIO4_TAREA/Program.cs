using System;
using System.Text;

namespace Ejercicio4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Permite mostrar acentos y caracteres especiales en la consola.
            Console.OutputEncoding = Encoding.UTF8;

            // Encabezado solicitado con el planteamiento del ejercicio.
            Console.WriteLine("============================================================");
            Console.WriteLine("EJERCICIO 4 - MEDICIONES DE CORRIENTE DE UN ACTUADOR");
            Console.WriteLine("Capturar 8 mediciones, clasificar cada una con el límite");
            Console.WriteLine("de 5 A y obtener promedio, conteos y resultado general.");
            Console.WriteLine("============================================================\n");

            // Variables acumuladoras y contadores para el resumen final.
            double sumaCorriente = 0;
            int normales = 0;
            int sobrecorrientes = 0;

            // Se procesan exactamente ocho mediciones de corriente.
            for (int i = 1; i <= 8; i++)
            {
                double corriente = LeerNoNegativo($"Corriente #{i} (A): ");
                sumaCorriente += corriente;

                // Cada lectura se clasifica inmediatamente usando el límite de 5 A.
                if (corriente <= 5)
                {
                    normales++;
                    Console.WriteLine("MEDICIÓN NORMAL.\n");
                }
                else
                {
                    sobrecorrientes++;
                    Console.WriteLine("SOBRECORRIENTE DETECTADA.\n");
                }
            }

            // Después de las ocho lecturas se obtiene la corriente promedio.
            double promedio = sumaCorriente / 8;

            // Se muestran los datos generales obtenidos durante el ciclo.
            Console.WriteLine("================ RESULTADOS ================");
            Console.WriteLine($"Corriente promedio: {promedio:F2} A");
            Console.WriteLine($"Mediciones normales: {normales}");
            Console.WriteLine($"Sobrecorrientes: {sobrecorrientes}");

            // El actuador se aprueba solamente cuando no hubo ninguna sobrecorriente.
            if (sobrecorrientes == 0)
            {
                Console.WriteLine("Resultado general: ACTUADOR APROBADO.");
            }
            else
            {
                Console.WriteLine("Resultado general: EL ACTUADOR REQUIERE REVISIÓN.");
            }
        }

        // Solicita una corriente válida y evita aceptar valores negativos.
        static double LeerNoNegativo(string mensaje)
        {
            double valor;

            while (true)
            {
                Console.Write(mensaje);

                if (double.TryParse(Console.ReadLine(), out valor) && valor >= 0)
                {
                    return valor;
                }

                Console.WriteLine(
                    "Entrada inválida. Escriba una corriente mayor o igual que cero.");
            }
        }
    }
}
