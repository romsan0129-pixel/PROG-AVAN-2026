using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace A14_Sensores_VisualStudio
{
    // Clase base: concentra propiedades y comportamiento comunes.
    public abstract class Sensor
    {
        public string Identificador { get; }
        public double Valormedio { get; protected set; }
        public bool Activo { get; private set; }

        protected Sensor(string identificador, double valormedio, bool activo)
        {
            if (string.IsNullOrWhiteSpace(identificador))
                throw new ArgumentException("El identificador no puede estar vacío.");
            if (double.IsNaN(valormedio) || double.IsInfinity(valormedio))
                throw new ArgumentException("La medición debe ser finita.");
            Identificador = identificador.Trim();
            Valormedio = valormedio;
            Activo = activo;
        }

        public void CambiarEstado(bool activo) => Activo = activo;
        public abstract string ObtenerEstado();

        public virtual void MostrarDatos()
        {
            Console.WriteLine($"Sensor: {GetType().Name} | ID: {Identificador}");
            Console.WriteLine($"Medición: {Valormedio:0.##} {Unidad} | Activo: {(Activo ? "Sí" : "No")}");
            Console.WriteLine($"Evaluación: {ObtenerEstado()}");
        }

        protected abstract string Unidad { get; }
        protected bool FueraDeServicio => !Activo;
    }

    public sealed class SensorTemperatura : Sensor
    {
        public const double LimiteCelsius = 80.0;
        public SensorTemperatura(string id, double medicion, bool activo) : base(id, medicion, activo) { }
        protected override string Unidad => "°C";
        public string EvaluarTemperatura() => FueraDeServicio ? "SIN SERVICIO: sensor inactivo."
            : Valormedio > LimiteCelsius ? "ATENCIÓN: temperatura superior a 80 °C."
            : "NORMAL: temperatura dentro del límite de 80 °C.";
        public override string ObtenerEstado() => EvaluarTemperatura();
    }

    public sealed class SensorUltrasonico : Sensor
    {
        // Criterio agregado al proyecto porque el PDF no establece umbral ultrasónico.
        public double UmbralProximidadCm { get; }
        public SensorUltrasonico(string id, double medicion, bool activo, double umbralCm = 30)
            : base(id, medicion, activo)
        {
            if (medicion < 0 || umbralCm <= 0) throw new ArgumentException("Distancias y umbral deben ser válidos.");
            UmbralProximidadCm = umbralCm;
        }
        protected override string Unidad => "cm";
        public string EvaluarProximidad() => FueraDeServicio ? "SIN SERVICIO: sensor inactivo."
            : Valormedio <= UmbralProximidadCm
                ? $"ATENCIÓN: objeto próximo (≤ {UmbralProximidadCm:0.##} cm)."
                : $"NORMAL: sin objeto dentro de {UmbralProximidadCm:0.##} cm.";
        public override string ObtenerEstado() => EvaluarProximidad();
        public override void MostrarDatos() { base.MostrarDatos(); Console.WriteLine($"Umbral configurado: {UmbralProximidadCm:0.##} cm"); }
    }

    public sealed class SensorPresion : Sensor
    {
        public const double LimiteBar = 10.0;
        public SensorPresion(string id, double medicion, bool activo) : base(id, medicion, activo)
        { if (medicion < 0) throw new ArgumentException("La presión no puede ser negativa en este modelo."); }
        protected override string Unidad => "bar";
        public string EvaluarPresion() => FueraDeServicio ? "SIN SERVICIO: sensor inactivo."
            : Valormedio > LimiteBar ? "ATENCIÓN: presión superior a 10 bar."
            : "NORMAL: presión dentro del límite de 10 bar.";
        public override string ObtenerEstado() => EvaluarPresion();
    }

    public sealed class SensorPresencia : Sensor
    {
        // Convención: 1 = detecta persona; 0 = no detecta persona.
        public SensorPresencia(string id, bool hayPersona, bool activo)
            : base(id, hayPersona ? 1.0 : 0.0, activo) { }
        protected override string Unidad => "(0 = no, 1 = sí)";
        public string EvaluarPresencia() => FueraDeServicio ? "SIN SERVICIO: sensor inactivo."
            : Valormedio == 1 ? "PRESENCIA DETECTADA: hay una persona."
            : "SIN PRESENCIA: no se detectan personas.";
        public override string ObtenerEstado() => EvaluarPresencia();
    }

    public sealed class SensorDistancia : Sensor
    {
        public const double UmbralCm = 20.0;
        public SensorDistancia(string id, double medicion, bool activo) : base(id, medicion, activo)
        { if (medicion < 0) throw new ArgumentException("La distancia no puede ser negativa."); }
        protected override string Unidad => "cm";
        public string EvaluarDistancia() => FueraDeServicio ? "SIN SERVICIO: sensor inactivo."
            : Valormedio < UmbralCm ? "ATENCIÓN: objeto a menos de 20 cm."
            : "NORMAL: objeto a 20 cm o más.";
        public override string ObtenerEstado() => EvaluarDistancia();
    }

    internal static class Program
    {
        private static readonly List<Sensor> Sensores = new();
        private static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("=== ACTIVIDAD 14 | MONITOREO DE SENSORES INDUSTRIALES ===");
            bool continuar = true;
            while (continuar)
            {
                Console.WriteLine("\n1) Registrar sensor  2) Mostrar todos  3) Cargar demostración  4) Salir");
                int opcion = LeerEntero("Elige una opción: ", 1, 4);
                switch (opcion)
                {
                    case 1: Registrar(); break;
                    case 2: MostrarTodos(); break;
                    case 3: Demostracion(); break;
                    case 4: continuar = false; break;
                }
            }
            Console.WriteLine("Fin del sistema.");
        }

        private static void Registrar()
        {
            Console.WriteLine("\n1 Temperatura | 2 Ultrasónico | 3 Presión | 4 Presencia | 5 Distancia");
            int tipo = LeerEntero("Tipo: ", 1, 5);
            Console.Write("Identificador: ");
            string id = Console.ReadLine()?.Trim() ?? "";
            if (string.IsNullOrWhiteSpace(id) || Sensores.Exists(s => s.Identificador.Equals(id, StringComparison.OrdinalIgnoreCase)))
            { Console.WriteLine("Identificador vacío o repetido; no se registró."); return; }
            bool activo = LeerEntero("¿Está activo? (1 Sí, 0 No): ", 0, 1) == 1;
            try
            {
                Sensor nuevo;
                if (tipo == 4)
                {
                    bool presencia = LeerEntero("¿Hay persona? (1 Sí, 0 No): ", 0, 1) == 1;
                    nuevo = new SensorPresencia(id, presencia, activo);
                }
                else
                {
                    double valor = LeerDouble("Medición (temperatura °C, otras en cm o bar): ");
                    if (tipo == 2)
                    {
                        double umbral = LeerDouble("Umbral de proximidad ultrasónica (cm, p. ej. 30): ");
                        nuevo = new SensorUltrasonico(id, valor, activo, umbral);
                    }
                    else nuevo = tipo switch
                    {
                        1 => new SensorTemperatura(id, valor, activo),
                        3 => new SensorPresion(id, valor, activo),
                        5 => new SensorDistancia(id, valor, activo),
                        _ => throw new InvalidOperationException("Tipo no reconocido.")
                    };
                }
                Sensores.Add(nuevo);
                Console.WriteLine("Registro exitoso:");
                nuevo.MostrarDatos();
            }
            catch (ArgumentException ex) { Console.WriteLine($"No registrado: {ex.Message}"); }
        }

        private static void MostrarTodos()
        {
            if (Sensores.Count == 0) { Console.WriteLine("No hay sensores registrados."); return; }
            Console.WriteLine($"\n=== SENSORES REGISTRADOS: {Sensores.Count} ===");
            foreach (Sensor sensor in Sensores) // Polimorfismo: se invoca el método de cada clase concreta.
            { sensor.MostrarDatos(); Console.WriteLine(new string('-', 55)); }
        }

        private static void Demostracion()
        {
            Sensores.Clear();
            Sensores.Add(new SensorTemperatura("TEMP-01", 85, true));
            Sensores.Add(new SensorUltrasonico("ULTRA-01", 15, true, 30));
            Sensores.Add(new SensorPresion("PRES-01", 8, true));
            Sensores.Add(new SensorPresencia("PERS-01", true, true));
            Sensores.Add(new SensorDistancia("DIST-01", 25, true));
            Sensores.Add(new SensorTemperatura("TEMP-02", 60, false));
            Console.WriteLine("Se cargaron seis registros de demostración.");
            MostrarTodos();
        }

        private static int LeerEntero(string mensaje, int min, int max)
        {
            while (true)
            {
                Console.Write(mensaje);
                if (int.TryParse(Console.ReadLine(), out int valor) && valor >= min && valor <= max) return valor;
                Console.WriteLine($"Valor inválido. Introduce un entero de {min} a {max}.");
            }
        }
        private static double LeerDouble(string mensaje)
        {
            while (true)
            {
                Console.Write(mensaje);
                string entrada = (Console.ReadLine() ?? "").Trim().Replace(',', '.');
                if (double.TryParse(entrada, NumberStyles.Float, CultureInfo.InvariantCulture, out double valor)
                    && !double.IsNaN(valor) && !double.IsInfinity(valor)) return valor;
                Console.WriteLine("Número inválido. Inténtalo nuevamente.");
            }
        }
    }
}
