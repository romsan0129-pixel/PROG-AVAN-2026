using System;

namespace Ejercicio02
{
    // CLASE: representa un cilindro neumático.
    class CilindroNeumatico
    {
        // PROPIEDADES
        public double PresionKPa { get; set; }
        public double AreaCm2 { get; set; }
        public double Fuerza { get; set; }
    }

    // CLASE: realiza las conversiones y el cálculo.
    class CalculadorFuerza
    {
        // MÉTODO: convierte kPa a Pa.
        public double ConvertirPresion(double kPa)
        {
            return kPa * 1000.0;
        }

        // MÉTODO: convierte cm^2 a m^2.
        public double ConvertirArea(double cm2)
        {
            return cm2 / 10000.0;
        }

        // MÉTODO: calcula F = P * A.
        public double CalcularFuerza(CilindroNeumatico cilindro)
        {
            double presionPa = ConvertirPresion(cilindro.PresionKPa);
            double areaM2 = ConvertirArea(cilindro.AreaCm2);

            cilindro.Fuerza = presionPa * areaM2;
            return cilindro.Fuerza;
        }

        // MÉTODO: comprueba el requerimiento mínimo.
        public bool CumpleRequerimiento(double fuerza, double minimo)
        {
            return fuerza >= minimo;
        }
    }

    class Program
    {
        static void Main()
        {
            // OBJETOS.
            CilindroNeumatico cilindro = new CilindroNeumatico();
            CalculadorFuerza calculador = new CalculadorFuerza();

            Console.Write("Presión (kPa): ");
            cilindro.PresionKPa = double.Parse(Console.ReadLine() ?? "0");

            Console.Write("Área efectiva (cm^2): ");
            cilindro.AreaCm2 = double.Parse(Console.ReadLine() ?? "0");

            Console.Write("Fuerza mínima requerida (N): ");
            double minimo = double.Parse(Console.ReadLine() ?? "0");

            double presionPa = calculador.ConvertirPresion(cilindro.PresionKPa);
            double areaM2 = calculador.ConvertirArea(cilindro.AreaCm2);
            double fuerza = calculador.CalcularFuerza(cilindro);

            Console.WriteLine("\n--- RESULTADO ---");
            Console.WriteLine($"Presión: {presionPa:F2} Pa");
            Console.WriteLine($"Área: {areaM2:F6} m^2");
            Console.WriteLine($"Fuerza: {fuerza:F2} N");
            Console.WriteLine($"Requerimiento: {(calculador.CumpleRequerimiento(fuerza, minimo) ? "CUMPLE" : "NO CUMPLE")}");
        }
    }
}
