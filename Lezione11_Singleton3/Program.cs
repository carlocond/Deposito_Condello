using System;

public sealed class Logger
{
    private static Logger istanza;
    private List<string> listaLog;

    private Logger() { }

    public static Logger GetIstanza()
    {
        if (istanza == null)
        {
            istanza = new Logger();
        }
        return istanza;
    }

    public void Log(string messaggio)
    {
        listaLog.Add("Ciao campione");
    }

    public void StampaLog()
    {
        foreach (string chiamata in listaLog)
        {
            Console.WriteLine(chiamata);
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Logger log1 = Logger.GetIstanza();

        Console.WriteLine("Inserisci il messaggio del primo log");
        log1.Log(Console.ReadLine());

        Logger log2 = Logger.GetIstanza();

        Console.WriteLine("Inserisci il messaggio del secondo log");
        log2.Log(Console.ReadLine());

        log1.StampaLog();
        log2.StampaLog();

        Console.WriteLine($"Sono i due log uguali= {log1 == log2}");

    }
}
