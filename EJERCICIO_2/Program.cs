Console.WriteLine("EJERCICIO_2");                                    //Numero de la practica
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
if (promedio>=70)       //CLASIFICA AL ALUMNO COMO "APROBADO" O "NO APROBADO"
    Console.Write("**********         Alumno Aprobado          ******");
else
    Console.Write("******           Alumno No Aprobado           *******");

Console.ReadLine(); 
Console.WriteLine();