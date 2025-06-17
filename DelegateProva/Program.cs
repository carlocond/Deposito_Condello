using System;

delegate void Saluto(string nome);

class Program
{
    static void Main()
    {
        Saluto s = Ciao;
        s("Carlo");

        Saluto a = Addio;
        a("Carlo");
    }

    static void Ciao(string nome)
    {
        Console.WriteLine($"Ciao, {nome}!");
    }

    static void Addio(string nome)
    {
        Console.WriteLine($"Addio, {nome}!");
    }
}
