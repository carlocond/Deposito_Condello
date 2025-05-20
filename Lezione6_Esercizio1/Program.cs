using System;

public class Studente
{
    public string Nome;

    public int Matricola;

    public double MediaVoti;

    public Studente(string nome, int matricola, double media)
    {
        Nome = nome;
        Matricola = matricola;
        MediaVoti = media;
    }

    public void StampaNome()
    {
        Console.WriteLine($"Nome studente: {Nome}");
    }

    public void StampaMatr()
    {
        Console.WriteLine($"Numero matricola: {Matricola}");
    }

    public void StampaMedia()
    {
        Console.WriteLine($"Media: {MediaVoti}");
    }


    public static void Main(string[] args)
    {
        string nome = "";
        int matricola = 0;
        double media = 0;

        string nome2 = "";
        int matricola2 = 0;
        double media2 = 0;


        Console.WriteLine("Inserisci il nome dello studente interessato");
        nome = Console.ReadLine();
        Console.WriteLine("Adesso inserisci la matricola di " + nome);
        matricola = int.Parse(Console.ReadLine());
        Console.WriteLine("Inserisci la media del primo studente");
        media = double.Parse(Console.ReadLine());



        Console.WriteLine("Inserisci il nome del secondo studente");
        nome2 = Console.ReadLine();
        Console.WriteLine("Inserisci la matricola del secondo studente");
        matricola2 = int.Parse(Console.ReadLine());
        Console.WriteLine("Inserisci la media del secondo studente");
        media2 = double.Parse(Console.ReadLine());


        Studente studente1 = new Studente(nome, matricola, media);
        Studente studente2 = new Studente(nome2, matricola2, media2);

        studente1.StampaNome();
        studente1.StampaMatr();
        studente1.StampaMedia();

        studente2.StampaNome();
        studente2.StampaMatr();
        studente2.StampaMedia();




    }
}
