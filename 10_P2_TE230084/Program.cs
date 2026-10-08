using System;

namespace Ejercicio10
{
    // CLASE: representa un motor y sus cuatro mediciones.
    class Motor
    {
        // PROPIEDADES
        public string Identificador { get; set; } = "";
        public double[] Corrientes { get; set; } = new double[4];
        public double Promedio { get; set; }
        public string Estado { get; set; } = "";
    }

    // CLASE: realiza el diagnóstico de un motor.
    class DiagnosticoMotor
    {
        // MÉTODO: captura las cuatro corrientes mediante for.
        public void CapturarCorrientes(Motor motor)
        {
            for (int i = 0; i < 4; i++)
            {
                Console.Write($"Corriente {i + 1} (A): ");
                motor.Corrientes[i] =
                    double.Parse(Console.ReadLine() ?? "0");
            }
        }

        // MÉTODO: calcula el promedio de corriente.
        public double CalcularPromedio(Motor motor)
        {
            double suma = 0;

            for (int i = 0; i < 4; i++)
            {
                suma += motor.Corrientes[i];
            }

            motor.Promedio = suma / 4.0;
            return motor.Promedio;
        }

        // MÉTODO: determina el estado del motor.
        public string DeterminarEstado(Motor motor)
        {
            motor.Estado = motor.Promedio <= 5
                ? "NORMAL"
                : "REQUIERE MANTENIMIENTO";

            return motor.Estado;
        }
    }

    // CLASE: controla el registro de una cantidad desconocida de motores.
    class SistemaDiagnostico
    {
        // MÉTODO: usa while para permitir registrar varios motores.
        public void Ejecutar()
        {
            string continuar = "S";

            while (continuar.Equals(
                "S", StringComparison.OrdinalIgnoreCase))
            {
                // OBJETOS creados para cada diagnóstico.
                Motor motor = new Motor();
                DiagnosticoMotor diagnostico =
                    new DiagnosticoMotor();

                Console.Write(
                    "\nIdentificador del motor: ");
                motor.Identificador =
                    Console.ReadLine() ?? "";

                diagnostico.CapturarCorrientes(motor);
                diagnostico.CalcularPromedio(motor);
                diagnostico.DeterminarEstado(motor);

                Console.WriteLine("\n--- RESULTADO ---");
                Console.WriteLine(
                    $"Motor: {motor.Identificador}");
                Console.WriteLine(
                    $"Promedio de corriente: " +
                    $"{motor.Promedio:F2} A");
                Console.WriteLine(
                    $"Estado: {motor.Estado}");

                Console.Write(
                    "\n¿Desea registrar otro motor? (S/N): ");
                continuar = Console.ReadLine() ?? "N";
            }
        }
    }

    class Program
    {
        static void Main()
        {
            // OBJETO principal.
            SistemaDiagnostico sistema =
                new SistemaDiagnostico();

            sistema.Ejecutar();
        }
    }
}
