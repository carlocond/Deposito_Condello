using System;

public class Program
{
    public static void Main(string[] args)
    {
        List<string> spesa = new List<string>();

        Console.WriteLine("Inserisci 5 prodotti nella lista della spesa");

        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("Aggiungi un prodotto");
            string prodotto = Console.ReadLine();
            spesa.Add(prodotto);
        }
        Console.WriteLine("I prodotti aggiunti alla spesa sono: ");
        foreach (string prodotto in spesa)
        {
            Console.WriteLine($"- {prodotto}");
        }
    }
}
