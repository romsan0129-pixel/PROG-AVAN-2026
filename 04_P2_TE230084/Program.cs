using System;

namespace Ejercicio04
{
    // CLASE: representa la batería.
    class Bateria
    {
        // PROPIEDADES
        public double Voltaje { get; set; }
        public double VoltajeObjetivo { get; set; } = 12.6;
    }

    // CLASE: controla el proceso de carga.
    class Cargador
    {
        // MÉTODO: carga mientras el voltaje sea menor que 12.6 V.
        public void Cargar(Bateria bateria, double incremento)
        {
            int ciclo = 0;

            while (bateria.Voltaje < bateria.VoltajeObjetivo)
            {
                ciclo++;
                bateria.Voltaje += incremento;

                // Evita superar el límite de 12.6 V.
                if (bateria.Voltaje > bateria.VoltajeObjetivo)
                {
                    bateria.Voltaje = bateria.VoltajeObjetivo;
                }

                Console.WriteLine(
                    $"Ciclo {ciclo}: {bateria.Voltaje:F2} V");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            // OBJETOS.
            Bateria bateria = new Bateria();
            Cargador cargador = new Cargador();

            Console.Write("Voltaje inicial (V): ");
            bateria.Voltaje = double.Parse(Console.ReadLine() ?? "0");

            Console.Write("Incremento por ciclo (V): ");
            double incremento = double.Parse(Console.ReadLine() ?? "0");

            if (incremento <= 0)
            {
                Console.WriteLine("El incremento debe ser mayor que 0 V.");
                return;
            }

            if (bateria.Voltaje >= bateria.VoltajeObjetivo)
            {
                bateria.Voltaje = bateria.VoltajeObjetivo;
                Console.WriteLine($"Voltaje final: {bateria.Voltaje:F2} V");
                return;
            }

            cargador.Cargar(bateria, incremento);

            Console.WriteLine($"\nVoltaje final: {bateria.Voltaje:F2} V");
        }
    }
}
