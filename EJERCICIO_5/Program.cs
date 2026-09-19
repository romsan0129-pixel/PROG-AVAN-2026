using Microsoft.Win32.SafeHandles;

Console.WriteLine("EJERCICIO_5");                                    //Numero de la practica
Console.WriteLine("CÁLCULO DEL PROMEDIO DE UN NUMERO FINITO DE CALIFICACIONES");    //Nombre del ejercicio
Console.WriteLine();                                                 //Instruccion para dejar un espacio en blanco en la consola
double suma = 0;
int cantidadCalificaciones = 3;

for (int i = 0; i < cantidadCalificaciones; i++)
{
    suma += Convert.ToDouble(Console.ReadLine());
}

double promedio = suma / cantidadCalificaciones;

Console.WriteLine();
Console.WriteLine($"El promedio de las tres calificaciones es: {promedio:F2}"); //Determinar si el alumno trabaja o no
Console.WriteLine();
Console.WriteLine();
if (promedio <= 50)       //CLASIFICA AL ALUMNO COMO "APROBADO" O "NO APROBADO"
    Console.Write("**********         Alumno deficiente         ******");
else if (promedio >= 51 & promedio <70)
    Console.Write("******           Alumno Requiere Apoyo           *******");
else if (promedio >= 70 & promedio <80)
    Console.Write("******           Alumno Regular          *******");
else if (promedio >= 80 & promedio <90)
    Console.Write("******           Alumno Bueno           *******");
else if (promedio >= 90 & promedio <= 100)
    Console.Write("******           Alumno Excelente         *******");


Console.ReadLine();