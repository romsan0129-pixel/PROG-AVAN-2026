using System;
using System.Text;

namespace Ejercicio5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Habilita caracteres especiales y acentos en la consola.
            Console.OutputEncoding = Encoding.UTF8;

            // Encabezado solicitado con el planteamiento del ejercicio.
            Console.WriteLine("============================================================");
            Console.WriteLine("EJERCICIO 5 - ANÁLISIS DE VIBRACIÓN DE VARIOS MOTORES");
            Console.WriteLine("Para cada motor: solicitar identificador, capturar 4");
            Console.WriteLine("mediciones con for, promediar, clasificar y preguntar");
            Console.WriteLine("si se desea analizar otro motor usando un ciclo while.");
            Console.WriteLine("============================================================\n");

            // Contadores generales que se conservarán entre todos los motores evaluados.
            int totalMotores = 0;
            int motoresNormales = 0;
            int motoresMantenimiento = 0;

            // Se inicia con "S" para permitir el análisis del primer motor.
            string respuesta = "S";

            // El while controla cuántos motores se analizarán.
            while (respuesta.Equals("S", StringComparison.OrdinalIgnoreCase))
            {
                // Datos correspondientes al motor que se está procesando.
                string identificador = LeerIdentificador();
                double sumaVibracion = 0;

                // El for solicita exactamente cuatro mediciones de vibración por motor.
                for (int i = 1; i <= 4; i++)
                {
                    double vibracion = LeerNoNegativo(
                        $"Medición de vibración #{i} para {identificador} (mm/s): ");

                    sumaVibracion += vibracion;
                }

                // Se calcula el promedio del motor actual y se aumenta el total evaluado.
                double promedio = sumaVibracion / 4;
                totalMotores++;

                Console.WriteLine($"\nPromedio de {identificador}: {promedio:F2} mm/s");

                // Se clasifica el motor usando el límite de 4.5 mm/s.
                if (promedio <= 4.5)
                {
                    motoresNormales++;
                    Console.WriteLine("FUNCIONAMIENTO NORMAL DEL MOTOR.");
                }
                else
                {
                    motoresMantenimiento++;
                    Console.WriteLine("EL MOTOR REQUIERE MANTENIMIENTO.");
                }

                // La respuesta determina si el ciclo while ejecutará otra iteración.
                respuesta = LeerRespuesta();
                Console.WriteLine();
            }

            // Resumen global solicitado al terminar el análisis de todos los motores.
            Console.WriteLine("================ RESUMEN FINAL ================");
            Console.WriteLine($"Total de motores evaluados: {totalMotores}");
            Console.WriteLine($"Motores con funcionamiento normal: {motoresNormales}");
            Console.WriteLine($"Motores que requieren mantenimiento: {motoresMantenimiento}");
        }

        // Solicita un nombre o identificador y no permite dejarlo vacío.
        static string LeerIdentificador()
        {
            while (true)
            {
                Console.Write("Nombre o identificador del motor: ");
                string texto = Console.ReadLine() ?? "";

                if (!string.IsNullOrWhiteSpace(texto))
                {
                    return texto.Trim();
                }

                Console.WriteLine("El identificador no puede quedar vacío.");
            }
        }

        // Lee una medición de vibración y valida que sea numérica y no negativa.
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

                Console.WriteLine("Entrada inválida. Escriba un valor mayor o igual que cero.");
            }
        }

        // Valida la respuesta para aceptar únicamente S (sí) o N (no).
        static string LeerRespuesta()
        {
            while (true)
            {
                Console.Write("¿Desea analizar otro motor? (S/N): ");
                string respuesta = (Console.ReadLine() ?? "").Trim().ToUpper();

                if (respuesta == "S" || respuesta == "N")
                {
                    return respuesta;
                }

                Console.WriteLine("Respuesta inválida. Escriba S o N.");
            }
        }
    }
}
