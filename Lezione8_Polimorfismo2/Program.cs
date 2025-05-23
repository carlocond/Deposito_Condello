using System;

public class Calcolatrice
{
    public int Somma(int a, int b) => a + b;
    public double Somma(double a, double b) => a + b;
    public int Somma(int a, int b, int c) => a + b + c;
}
public class Program
{
    public static void Main(string[] args)
    {
        Calcolatrice calcolatrice= new Calcolatrice();

        Console.WriteLine(calcolatrice.Somma(10, 20));
        Console.WriteLine(calcolatrice.Somma(10.20, 10.30));
        Console.WriteLine(calcolatrice.Somma(1, 2, 3));
    }
}