Console.WriteLine("EJERCICIO_3");                                    //Numero de la practica
Console.WriteLine("CÁLCULO DEL PROMEDIO DE TRES CALIFICACIONES");    //Nombre del ejercicio
Console.WriteLine();                                                 //Instruccion para dejar un espacio en blanco en la consola

Console.Write("Ingrese la primera calificación: ");
double calificacion1 = Convert.ToDouble(Console.ReadLine());         //Declaramos la variable 1

Console.Write("Ingrese la segunda calificación: ");
double calificacion2 = Convert.ToDouble(Console.ReadLine());         //Declaramos la variable 2

Console.Write("Ingrese la tercera calificación: ");
double calificacion3 = Convert.ToDouble(Console.ReadLine());         //Declaramos la variable 3 

double promedio = (calificacion1 + calificacion2 + calificacion3) / 3.0;

Console.WriteLine();
Console.WriteLine($"El promedio de las tres calificaciones es: {promedio:F2}"); //Determinar si el alumno trabaja o no
Console.WriteLine();
Console.WriteLine();
if (promedio <= 50)       //CLASIFICA AL ALUMNO COMO "APROBADO" O "NO APROBADO"
    Console.Write("**********         Alumno deficiente         ******");
else if (promedio>=51&promedio<=69)
    Console.Write("******           Alumno Requiere Apoyo           *******");
else if (promedio >= 70&promedio <=79)
    Console.Write("******           Alumno Regular          *******");
else if (promedio >= 80&promedio <= 89)
    Console.Write("******           Alumno Bueno           *******");
else if (promedio >= 90&promedio <= 100)
    Console.Write("******           Alumno Excelente         *******");

Console.WriteLine();
Console.WriteLine();