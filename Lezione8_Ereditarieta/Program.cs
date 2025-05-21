using System;
//Creazione classe base
public class Animale
{
    public void FaiVerso()
    {
        Console.WriteLine("L'animale fa un verso.");
    }
}

//Creazione della classe derivata
public class Cane : Animale
{
    public void Scondizola()
    {
        Console.WriteLine("Il cane scondinzola.");
    }
}

//Programma principale
public class Program
{
    public static void Main(string[] args)
    {
        Cane cane1 = new Cane(); //Creazione di un oggetto della classe derivata
        cane1.FaiVerso(); //Metodo ereditato dalla classe base
        cane1.Scondizola(); //Metodo definito nella classe derivata
    }
}
