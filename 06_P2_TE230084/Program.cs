using System;

namespace Ejercicio06
{
    // CLASE: representa una pieza individual.
    class Pieza
    {
        // PROPIEDAD
        public bool EsCorrecta { get; set; }
    }

    // CLASE: representa el lote de diez piezas.
    class Lote
    {
        // PROPIEDADES
        public int Total { get; set; } = 10;
        public int Correctas { get; set; }
        public int Defectuosas { get; set; }
        public double PorcentajeCorrectas { get; set; }
    }

    // CLASE: realiza la inspección.
    class InspectorLote
    {
        // MÉTODO: registra las diez piezas.
        public void RegistrarPiezas(Lote lote)
        {
            for (int i = 1; i <= lote.Total; i++)
            {
                int valor;

                while (true)
                {
                    Console.Write(
                        $"Pieza {i} (1 = correcta, 0 = defectuosa): ");

                    if (int.TryParse(Console.ReadLine(), out valor) &&
                        (valor == 0 || valor == 1))
                    {
                        break;
                    }

                    Console.WriteLine(
                        "Dato inválido. Introduzca únicamente 0 o 1.");
                }

                // OBJETO creado a partir de Pieza.
                Pieza pieza = new Pieza
                {
                    EsCorrecta = valor == 1
                };

                if (pieza.EsCorrecta)
                    lote.Correctas++;
                else
                    lote.Defectuosas++;
            }
        }

        // MÉTODO: calcula el porcentaje de piezas correctas.
        public double CalcularPorcentaje(Lote lote)
        {
            lote.PorcentajeCorrectas =
                lote.Correctas * 100.0 / lote.Total;

            return lote.PorcentajeCorrectas;
        }

        // MÉTODO: determina si el lote es aceptado o rechazado.
        public string DeterminarEstado(Lote lote)
        {
            return lote.PorcentajeCorrectas >= 90
                ? "ACEPTADO"
                : "RECHAZADO";
        }
    }

    class Program
    {
        static void Main()
        {
            // OBJETOS.
            Lote lote = new Lote();
            InspectorLote inspector = new InspectorLote();

            inspector.RegistrarPiezas(lote);
            inspector.CalcularPorcentaje(lote);

            Console.WriteLine("\n--- RESULTADO ---");
            Console.WriteLine($"Piezas correctas: {lote.Correctas}");
            Console.WriteLine($"Piezas defectuosas: {lote.Defectuosas}");
            Console.WriteLine(
                $"Porcentaje: {lote.PorcentajeCorrectas:F2} %");
            Console.WriteLine(
                $"Estado del lote: {inspector.DeterminarEstado(lote)}");
        }
    }
}
