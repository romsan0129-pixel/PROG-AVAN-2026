
Console.WriteLine("SISTEMA DE REGISTRO DE MOTORES");
Console.WriteLine();

// Crear un objeto de la clase Motor
Motor motor1 = new Motor();

// Capturar la información del objeto
Console.Write("Ingrese el identificador del motor: ");
motor1.Identificador = Console.ReadLine() ?? "Sin ID";

Console.Write("Ingrese la temperatura en grados C: ");
motor1.Temperatura = Convert.ToDouble(Console.ReadLine());

Console.Write("Ingrese la corriente en amperios: ");
motor1.Corriente = Convert.ToDouble(Console.ReadLine());

Console.Write("Ingrese la velocidad en RPM: ");
motor1.Velocidad = Convert.ToDouble(Console.ReadLine());

// Solicitar al objeto que verifique la temperatura
string temperatura = motor1.VerificarTemperatura();

// Solicitar al objeto que determine su estado
string estado = motor1.ObtenerEstado();

// Mostrar resultados
Console.WriteLine();
Console.WriteLine("RESULTADOS DEL MOTOR");
Console.WriteLine();

Console.WriteLine($"Identificador: {motor1.Identificador}");
Console.WriteLine($"Temperatura: {motor1.Temperatura:F2} °C");
Console.WriteLine($"Corriente: {motor1.Corriente:F2} A");
Console.WriteLine($"Velocidad: {motor1.Velocidad:F2} RPM");
Console.WriteLine($"Estado de temperatura: {temperatura}");
Console.WriteLine($"Estado del motor: {estado}");


// DEFINICIÓN DE LA CLASE
class Motor
{
    // PROPIEDADES
    public string Identificador { get; set; } = "";

    public double Temperatura { get; set; }

    public double Corriente { get; set; }

    public double Velocidad { get; set; }


    // MÉTODO PARA VERIFICAR LA TEMPERATURA
    public string VerificarTemperatura()
    {
        if (Temperatura > 70)
        {
            return "TEMPERATURA ELEVADA";
        }
        else
        {
            return "TEMPERATURA NORMAL";
        }
    }


    // MÉTODO PARA DETERMINAR EL ESTADO DEL MOTOR
    public string ObtenerEstado()
    {
        if (Velocidad > 0)
        {
            return "EN MARCHA";
        }
        else
        {
            return "DETENIDO";
        }
    }
}
