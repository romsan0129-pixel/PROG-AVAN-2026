using Microsoft.Win32.SafeHandles;

Console.WriteLine("EJERCICIO_5");                                    //Numero de la practica
Console.WriteLine("CÁLCULO DEL PROMEDIO DE UN NUMERO FINITO DE CALIFICACIONES");    //Nombre del ejercicio
Console.WriteLine();                                                 //Instruccion para dejar un espacio en blanco en la consola
double suma = 0;
int ncalif=0;

    for (ncalif = 1; ncalif <=5; ncalif++)
{
    Console.Write($"Ingrese la primera calificación {ncalif}: ");
    double calificacion = Convert.ToDouble(Console.ReadLine());         //Declaramos la variable 
    suma = suma + calificacion;
}

double califs = Convert.ToDouble(ncalif-1);
double promedio = suma / califs;

Console.WriteLine();
Console.WriteLine($"El promedio de las tres calificaciones es: {promedio:F2}"); //Determinar si el alumno trabaja o no
Console.WriteLine();
Console.WriteLine();
if (promedio <= 50)       //CLASIFICA AL ALUMNO COMO "APROBADO" O "NO APROBADO"
    Console.Write("**********         Alumno deficiente         ******");
else if (promedio >= 51 & promedio <= 69)
    Console.Write("******           Alumno Requiere Apoyo           *******");
else if (promedio >= 70 & promedio <= 79)
    Console.Write("******           Alumno Regular          *******");
else if (promedio >= 80 & promedio <= 89)
    Console.Write("******           Alumno Bueno           *******");
else if (promedio >= 90 & promedio <= 100)
    Console.Write("******           Alumno Excelente         *******");

Console.WriteLine();
Console.WriteLine();