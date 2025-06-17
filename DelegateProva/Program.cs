using System;

public delegate void Saluto(string nome);
public delegate int Calcolo(int a, int b);

class Program
{
        static void Ciao(string nome)
    {
        Console.WriteLine($"Ciao, {nome}!");
    }

    static void Addio(string nome)
    {
        Console.WriteLine($"Addio, {nome}!");
    }

    // Metodo che accetta un delegato come parametro
    static void EseguiSaluto(Saluto saluto, string nome)
    {
        saluto(nome);
    }
    static Action<string> saluta;
    static int EseguiSomma(int a, int b)
    {
        return a + b;
    }
    static void Main()
    {
        // Dichiarazione e utilizzo di un delegato
        Saluto s = Ciao;
        s("Carlo");

        Saluto a = Addio;
        a("Carlo");

        // Utilizzo di un delegato come parametro
        EseguiSaluto(s, "Carlo");

        // Delegato multicast: unisce più metodi
        Saluto multiSaluto = Ciao;
        multiSaluto += nome => Console.WriteLine($"Ciao, {nome} da un Multicast!");
        multiSaluto += Addio;
        multiSaluto += Ciao;
        multiSaluto("Michele");

        //Utilizzo dell'action<T> come delegato
        saluta = nome => Console.WriteLine($"Salve, {nome}!");
        saluta += Addio;
        // saluta("Giulia");
        saluta?.Invoke("Giulia");


        Calcolo calcolo = EseguiSomma;
        Console.WriteLine("Risulato di Esegui somma: " + calcolo(5, 10));

    }

    // Metodi che corrispondono alla firma del delegato Saluto



}
