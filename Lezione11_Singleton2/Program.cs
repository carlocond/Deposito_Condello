using System;

//Creazione del singleton Logger
public sealed class Logger
{
    private static Logger istanza;

    private Logger() { }

    public static Logger GetIstanza()
    {
        if (istanza == null)
        {
            istanza = new Logger();
        }
        return istanza;
    }

    public void ScriviMessaggio(string messaggio)
    {
        Console.WriteLine($"{DateTime.Now}: {messaggio}");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Logger log1 = Logger.GetIstanza();

        log1.ScriviMessaggio("Ciao, questo è il primo messaggio di log.");

        Logger log2 = Logger.GetIstanza();
        log2.ScriviMessaggio("Ciao, questo è il secondo messaggio di log.");

        // Verifica che log1 e log2 siano la stessa istanza
        Console.WriteLine($"Le due istanze sono uguali? {log1 == log2}");


    }
}
