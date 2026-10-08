using System;

namespace Ejercicio07
{
    // CLASE: representa las tres etapas del brazo robótico.
    class BrazoRobotico
    {
        // PROPIEDADES
        public double TiempoTomar { get; set; }
        public double TiempoTrasladar { get; set; }
        public double TiempoSoltar { get; set; }
    }

    // CLASE: simula los ciclos de trabajo.
    class SimuladorCiclos
    {
        // MÉTODO: suma las tres etapas para obtener un ciclo.
        public double CalcularTiempoCiclo(BrazoRobotico brazo)
        {
            return brazo.TiempoTomar +
                   brazo.TiempoTrasladar +
                   brazo.TiempoSoltar;
        }

        // MÉTODO: ejecuta el número de ciclos solicitado.
        public double Simular(BrazoRobotico brazo, int numeroCiclos)
        {
            double tiempoCiclo = CalcularTiempoCiclo(brazo);
            double acumulado = 0;

            for (int i = 1; i <= numeroCiclos; i++)
            {
                acumulado += tiempoCiclo;

                Console.WriteLine(
                    $"Ciclo {i}: tiempo acumulado = {acumulado:F2} s");
            }

            return acumulado;
        }
    }

    class Program
    {
        static void Main()
        {
            // OBJETOS.
            BrazoRobotico brazo = new BrazoRobotico();
            SimuladorCiclos simulador = new SimuladorCiclos();

            Console.Write("Tiempo de tomar (s): ");
            brazo.TiempoTomar =
                double.Parse(Console.ReadLine() ?? "0");

            Console.Write("Tiempo de trasladar (s): ");
            brazo.TiempoTrasladar =
                double.Parse(Console.ReadLine() ?? "0");

            Console.Write("Tiempo de soltar (s): ");
            brazo.TiempoSoltar =
                double.Parse(Console.ReadLine() ?? "0");

            Console.Write("Número de ciclos: ");
            int ciclos = int.Parse(Console.ReadLine() ?? "0");

            if (ciclos < 1)
            {
                Console.WriteLine(
                    "El número de ciclos debe ser mayor que 0.");
                return;
            }

            double tiempoCiclo =
                simulador.CalcularTiempoCiclo(brazo);

            double total =
                simulador.Simular(brazo, ciclos);

            Console.WriteLine("\n--- RESULTADO ---");
            Console.WriteLine(
                $"Tiempo de un ciclo: {tiempoCiclo:F2} s");
            Console.WriteLine(
                $"Tiempo total de producción: {total:F2} s");
        }
    }
}
