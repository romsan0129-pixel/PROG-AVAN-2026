using System;

namespace Ejercicio01
{
    // CLASE: representa el motor y sus datos.
    class Motor
    {
        // PROPIEDADES
        public string Identificador { get; set; }
        public double Voltaje { get; set; }
        public double Corriente { get; set; }
        public double Potencia { get; set; }
    }

    // CLASE: contiene los métodos para evaluar el consumo.
    class EvaluadorConsumo
    {
        // MÉTODO: calcula la potencia P = V * I.
        public double CalcularPotencia(Motor motor)
        {
            motor.Potencia = motor.Voltaje * motor.Corriente;
            return motor.Potencia;
        }

        // MÉTODO: determina el estado del consumo.
        public string DeterminarEstado(Motor motor)
        {
            return motor.Potencia <= 120
                ? "CONSUMO NORMAL"
                : "CONSUMO ELEVADO";
        }
    }

    class Program
    {
        static void Main()
        {
            // OBJETOS creados a partir de las clases.
            Motor motor = new Motor();
            EvaluadorConsumo evaluador = new EvaluadorConsumo();

            Console.Write("Identificador del motor: ");
            motor.Identificador = Console.ReadLine() ?? "";

            Console.Write("Voltaje de alimentación (V): ");
            motor.Voltaje = double.Parse(Console.ReadLine() ?? "0");

            Console.Write("Corriente consumida (A): ");
            motor.Corriente = double.Parse(Console.ReadLine() ?? "0");

            evaluador.CalcularPotencia(motor);

            Console.WriteLine("\n--- RESULTADO ---");
            Console.WriteLine($"Motor: {motor.Identificador}");
            Console.WriteLine($"Potencia: {motor.Potencia:F2} W");
            Console.WriteLine($"Estado: {evaluador.DeterminarEstado(motor)}");
        }
    }
}
