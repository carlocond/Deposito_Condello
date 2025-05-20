using System;

public class Prodotto
{
    //Dichiarazione delle variabili della classe
    public string nome;
    public double prezzo;

    //Hashcode coerente con i dati significativi
    public override int GetHashCode()
    {
        return HashCode.Combine(nome, prezzo);
    }

}

public class Program
{
    public static void Main(string[] args)
    {
        //Creazione degli oggetti e assegnazione dei valori

        Prodotto p1 = new Prodotto { nome = "Matita", prezzo = 0.50 };
        Prodotto p2 = new Prodotto { nome = "Matita", prezzo = 0.50 };
        Prodotto p3 = new Prodotto { nome = "Penna", prezzo = 1.50 };
        Prodotto p4 = new Prodotto { nome = "Penna", prezzo = 1.75 };

        //Stampa dei codici, uguale se i valori sono gli stessi

        Console.WriteLine(p1.GetHashCode());
        Console.WriteLine(p2.GetHashCode());
        Console.WriteLine(p3.GetHashCode());
        Console.WriteLine(p4.GetHashCode());
    }
}
