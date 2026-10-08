using System;
2
3 class Motor
{
4 public string Identificador { get; set; }
5 public double Voltaje { get; set; }
6 public double Corriente { get; set; }
7 public double Potencia { get; private set; }
8
9 public void CalcularPotencia()
    {
        10 Potencia = Voltaje * Corriente;
        11 }
12 public string EvaluarConsumo()
    {
        13 return Potencia <= 120 ? " Normal " : " Elevado ";
        14 }
15 }
16
17 class Program
{
18 static void Main()
    {
        19 Motor motor1 = new Motor();
        20 Console.Write("ID del motor : ");
        21 motor1.Identificador = Console.ReadLine();
        22 Console.Write(" Voltaje (V): ");