
using System;

namespace Ejercicio05
{
    // CLASE: representa al servomotor.
    class Servomotor
    {
        // PROPIEDADES
        public double PosicionActual { get; set; }
        public double PosicionObjetivo { get; set; }
        public double Desplazamiento { get; set; }
    }

    // CLASE: contiene la logica de control.
    class ControlServo
    {
        // METODO: valida la posicion.
        public bool EsValida(double posicion)
        {
            return posicion >= 0 && posicion <= 180;
        }

        // METODO: calcula el desplazamiento.
        public double CalcularDesplazamiento(Servomotor servo)
        {
            servo.Desplazamiento =
                Math.Abs(servo.PosicionObjetivo - servo.PosicionActual);

            return servo.Desplazamiento;
        }

        // METODO: determina la direccion.
        public string DeterminarDireccion(Servomotor servo)
        {
            if (servo.PosicionObjetivo > servo.PosicionActual)
                return "HACIA UNA POSICION MAYOR";

            if (servo.PosicionObjetivo < servo.PosicionActual)
                return "HACIA UNA POSICION MENOR";

            return "NO HAY MOVIMIENTO";
        }
    }

    class Program
    {
        static void Main()
        {
            // OBJETOS
            Servomotor servo = new Servomotor();
            ControlServo control = new ControlServo();

            do
            {
                Console.Write("Posicion actual (0 a 180 grados): ");
                servo.PosicionActual =
                    double.Parse(Console.ReadLine() ?? "0");

                Console.Write("Posicion objetivo (0 a 180 grados): ");
                servo.PosicionObjetivo =
                    double.Parse(Console.ReadLine() ?? "0");

                if (!control.EsValida(servo.PosicionActual) ||
                    !control.EsValida(servo.PosicionObjetivo))
                {
                    Console.WriteLine(
                        "Valores fuera del intervalo permitido.");
                    Console.WriteLine("Intente nuevamente.");
                }
                else
                {
                    break;
                }

            } while (true);

            control.CalcularDesplazamiento(servo);

            Console.WriteLine();
            Console.WriteLine("--- RESULTADO ---");
            Console.WriteLine(
                $"Desplazamiento: {servo.Desplazamiento:F2} grados");
            Console.WriteLine(
                $"Movimiento: {control.DeterminarDireccion(servo)}");
        }
    }
}
