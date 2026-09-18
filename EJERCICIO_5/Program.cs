using Microsoft.Win32.SafeHandles;

Console.WriteLine("EJERCICIO_5");                                    //Numero de la practica
Console.WriteLine("CÁLCULO DEL PROMEDIO DE UN NUMERO FINITO DE CALIFICACIONES");    //Nombre del ejercicio
Console.WriteLine();                                                 //Instruccion para dejar un espacio en blanco en la consola
double suma = 0;
double calificacion1 = Convert.ToDouble(Console.ReadLine());         //Declaramos la variable 
double calificacion2 = Convert.ToDouble(Console.ReadLine());         //Declaramos la variable
double calificacion3 = Convert.ToDouble(Console.ReadLine());         //Declaramos la variable
suma = calificacion1 + calificacion2 + calificacion3;
double promedio = suma / 3.0;

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

Console.WriteLine();
Console.WriteLine();