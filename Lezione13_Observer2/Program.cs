using System;

public interface IObserver
{
    void Aggiorna(string messaggio);
}

public interface ISubject
{
    void Registra(IObserver osservatore);
    void Rimuovi(IObserver osservatore);
    void Notifica(string messaggio);
}

public class CentroMeteo : ISubject
{
    private readonly List<IObserver> _osservatori = new List<IObserver>();

    public void Registra(IObserver osservatore)
    {
        _osservatori.Add(osservatore);
    }

    public void Rimuovi(IObserver osservatore)
    {
        _osservatori.Remove(osservatore);
    }

    public void Notifica(string messaggio)
    {
        foreach (var osservatore in _osservatori)
        {
            osservatore.Aggiorna(messaggio);
        }
    }
    public void AggiornaMeteo(string dati)
    {
        Console.WriteLine($"Aggiornamento meteo: {dati}");
        Notifica(dati);
    }
}

public class DisplayConsole : IObserver
{
    public void Aggiorna(string messaggio)
    {
        Console.WriteLine($"Console Nuovo aggiornamento meteo: {messaggio}");
    }
}

public class DisplayMobile : IObserver
{

    public void Aggiorna(string messaggio)
    {
        Console.WriteLine($"Mobile Notifica meteo: {messaggio}");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        CentroMeteo centro = new CentroMeteo();
        IObserver console = new DisplayConsole();
        IObserver mobile = new DisplayMobile();

        centro.Registra(console);
        centro.Registra(mobile);

        bool continua = true;
        while (continua)
        {
            Console.WriteLine("\n1. Inserisci aggiornamento meteo\n0. Esci");
            Console.Write("Scelta: ");
            string scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                    Console.Write("Inserisci nuove condizioni meteo: ");
                    string dati = Console.ReadLine();
                    centro.AggiornaMeteo(dati);
                    break;
                case "0":
                    continua = false;
                    break;
                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
        }

        Console.WriteLine("Programma terminato.");
    }
}
        

