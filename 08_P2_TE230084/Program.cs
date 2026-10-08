using System;

namespace Ejercicio08
{
    // CLASE: representa el tanque.
    class Tanque
    {
        // PROPIEDADES
        public double CapacidadMaxima { get; set; }
        public double Volumen { get; set; }
        public double Porcentaje { get; set; }
    }

    // CLASE: controla el llenado.
    class ControlTanque
    {
        // MÉTODO: evita superar la capacidad máxima.
        public void AjustarCapacidad(Tanque tanque)
        {
            if (tanque.Volumen > tanque.CapacidadMaxima)
                tanque.Volumen = tanque.CapacidadMaxima;
        }

        // MÉTODO: calcula el porcentaje de llenado.
        public double CalcularPorcentaje(Tanque tanque)
        {
            tanque.Porcentaje =
                tanque.Volumen / tanque.CapacidadMaxima * 100.0;

            return tanque.Porcentaje;
        }

        // MÉTODO: llena el tanque mediante while.
        public void Llenar(Tanque tanque, double agregado)
        {
            while (tanque.Volumen < tanque.CapacidadMaxima)
            {
                tanque.Volumen += agregado;

                AjustarCapacidad(tanque);
                CalcularPorcentaje(tanque);

                Console.WriteLine(
                    $"Volumen: {tanque.Volumen:F2} L | " +
                    $"Llenado: {tanque.Porcentaje:F2} %");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            // OBJETOS.
            Tanque tanque = new Tanque();
            ControlTanque control = new ControlTanque();

            Console.Write("Capacidad máxima (L): ");
            tanque.CapacidadMaxima =
                double.Parse(Console.ReadLine() ?? "0");

            Console.Write("Volumen inicial (L): ");
            tanque.Volumen =
                double.Parse(Console.ReadLine() ?? "0");

            Console.Write("Volumen agregado por ciclo (L): ");
            double agregado =
                double.Parse(Console.ReadLine() ?? "0");

            if (tanque.CapacidadMaxima <= 0 ||
                tanque.Volumen < 0 ||
                agregado <= 0 ||
                tanque.Volumen > tanque.CapacidadMaxima)
            {
                Console.WriteLine("Datos inválidos.");
                return;
            }

            control.Llenar(tanque, agregado);

            Console.WriteLine(
                $"\nTanque lleno: {tanque.Volumen:F2} L");
        }
    }
}
