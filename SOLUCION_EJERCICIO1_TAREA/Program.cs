using System;
using System.Text;

namespace Ejercicio1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Permite mostrar correctamente caracteres como acentos y símbolos en la consola.
            Console.OutputEncoding = Encoding.UTF8;

            // Encabezado solicitado: presenta el planteamiento antes de pedir los datos.
            Console.WriteLine("============================================================");
            Console.WriteLine("EJERCICIO 1 - POTENCIA ELÉCTRICA DE UN MOTOR DE C.D.");
            Console.WriteLine("Solicitar voltaje y corriente, calcular P = V * I y");
            Console.WriteLine("clasificar el consumo con respecto al límite de 120 W.");
            Console.WriteLine("============================================================\n");

            // Entrada de datos. Ambos valores se validan para evitar números negativos.
            double voltaje = LeerNoNegativo("Ingrese el voltaje del motor (V): ");
            double corriente = LeerNoNegativo("Ingrese la corriente consumida (A): ");

            // Proceso: la potencia eléctrica se obtiene con la expresión P = V * I.
            double potencia = voltaje * corriente;

            // Salida del valor calculado con dos cifras decimales.
            Console.WriteLine($"\nPotencia eléctrica: {potencia:F2} W");

            // Clasificación del consumo de acuerdo con el límite indicado de 120 W.
            if (potencia <= 120)
            {
                Console.WriteLine("CONSUMO NORMAL.");
            }
            else
            {
                Console.WriteLine("ADVERTENCIA: CONSUMO ELEVADO.");
            }
        }

        // Solicita un número y repite la lectura hasta recibir un valor válido y no negativo.
        static double LeerNoNegativo(string mensaje)
        {
            double valor;

            do
            {
                Console.Write(mensaje);

                // TryParse evita que el programa termine si el usuario escribe texto no numérico.
                if (double.TryParse(Console.ReadLine(), out valor) && valor >= 0)
                {
                    return valor;
                }

                Console.WriteLine("Entrada inválida. Escriba un número mayor o igual que cero.");
            }
            while (true);
        }
    }
}
