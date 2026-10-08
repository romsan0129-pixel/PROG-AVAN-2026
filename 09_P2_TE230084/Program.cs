using System;

namespace Ejercicio09
{
    // CLASE: representa una bomba eléctrica.
    class BombaElectrica
    {
        // PROPIEDADES
        public string Identificador { get; set; } = "";
        public double Voltaje { get; set; }
        public double Corriente { get; set; }
        public double Caudal { get; set; }
        public double Potencia { get; set; }
        public double Desempeno { get; set; }
    }

    // CLASE: calcula y compara el desempeño de las bombas.
    class ComparadorBombas
    {
        // MÉTODO: calcula P = V * I.
        public double CalcularPotencia(BombaElectrica bomba)
        {
            bomba.Potencia = bomba.Voltaje * bomba.Corriente;
            return bomba.Potencia;
        }

        // MÉTODO: calcula caudal/potencia.
        public double CalcularDesempeno(BombaElectrica bomba)
        {
            if (bomba.Potencia <= 0)
                throw new ArgumentException(
                    "La potencia debe ser mayor que 0 W.");

            bomba.Desempeno =
                bomba.Caudal / bomba.Potencia;

            return bomba.Desempeno;
        }

        // MÉTODO: compara los indicadores.
        public string Comparar(
            BombaElectrica bomba1,
            BombaElectrica bomba2)
        {
            const double tolerancia = 1e-9;

            if (Math.Abs(bomba1.Desempeno -
                         bomba2.Desempeno) < tolerancia)
            {
                return "EMPATE";
            }

            return bomba1.Desempeno > bomba2.Desempeno
                ? bomba1.Identificador
                : bomba2.Identificador;
        }
    }

    class Program
    {
        static void Main()
        {
            // OBJETOS de las bombas.
            BombaElectrica bomba1 = CapturarBomba(1);
            BombaElectrica bomba2 = CapturarBomba(2);

            ComparadorBombas comparador =
                new ComparadorBombas();

            comparador.CalcularPotencia(bomba1);
            comparador.CalcularPotencia(bomba2);

            comparador.CalcularDesempeno(bomba1);
            comparador.CalcularDesempeno(bomba2);

            Console.WriteLine("\n--- RESULTADO ---");

            Console.WriteLine(
                $"{bomba1.Identificador}: " +
                $"{bomba1.Potencia:F2} W | " +
                $"{bomba1.Desempeno:F6} L/min/W");

            Console.WriteLine(
                $"{bomba2.Identificador}: " +
                $"{bomba2.Potencia:F2} W | " +
                $"{bomba2.Desempeno:F6} L/min/W");

            string resultado =
                comparador.Comparar(bomba1, bomba2);

            if (resultado == "EMPATE")
                Console.WriteLine("Resultado: EMPATE");
            else
                Console.WriteLine(
                    $"Mayor caudal por watt: {resultado}");
        }

        // MÉTODO auxiliar: captura los datos de una bomba.
        static BombaElectrica CapturarBomba(int numero)
        {
            BombaElectrica bomba =
                new BombaElectrica();

            Console.WriteLine($"\n--- Bomba {numero} ---");

            Console.Write("Identificador: ");
            bomba.Identificador =
                Console.ReadLine() ?? "";

            Console.Write("Voltaje (V): ");
            bomba.Voltaje =
                double.Parse(Console.ReadLine() ?? "0");

            Console.Write("Corriente (A): ");
            bomba.Corriente =
                double.Parse(Console.ReadLine() ?? "0");

            Console.Write("Caudal (L/min): ");
            bomba.Caudal =
                double.Parse(Console.ReadLine() ?? "0");

            return bomba;
        }
    }
}
