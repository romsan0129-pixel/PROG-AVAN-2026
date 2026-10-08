using System;

namespace Ejercicio03
{
    // CLASE: representa al motor y sus cinco temperaturas.
    class Motor
    {
        // PROPIEDADES
        public double[] Temperaturas { get; set; } = new double[5];
        public double Promedio { get; set; }
        public string Estado { get; set; } = "";
    }

    // CLASE: captura y analiza las temperaturas.
    class AnalizadorTemperatura
    {
        // MÉTODO: captura las cinco mediciones mediante for.
        public void CapturarMediciones(Motor motor)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Temperatura {i + 1} (°C): ");
                motor.Temperaturas[i] = double.Parse(Console.ReadLine() ?? "0");
            }
        }

        // MÉTODO: calcula el promedio.
        public double CalcularPromedio(Motor motor)
        {
            double suma = 0;

            for (int i = 0; i < 5; i++)
            {
                suma += motor.Temperaturas[i];
            }

            motor.Promedio = suma / 5.0;
            return motor.Promedio;
        }

        // MÉTODO: determina NORMAL o ALERTA.
        public string DeterminarEstado(Motor motor)
        {
            motor.Estado = motor.Promedio <= 70
                ? "NORMAL"
                : "ALERTA DE TEMPERATURA";

            return motor.Estado;
        }
    }

    class Program
    {
        static void Main()
        {
            // OBJETOS.
            Motor motor = new Motor();
            AnalizadorTemperatura analizador = new AnalizadorTemperatura();

            analizador.CapturarMediciones(motor);
            analizador.CalcularPromedio(motor);
            analizador.DeterminarEstado(motor);

            Console.WriteLine("\n--- RESULTADO ---");
            Console.WriteLine($"Promedio: {motor.Promedio:F2} °C");
            Console.WriteLine($"Estado: {motor.Estado}");
        }
    }
}
