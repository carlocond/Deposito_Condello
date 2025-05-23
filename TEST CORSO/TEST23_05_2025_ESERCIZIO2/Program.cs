using System;

public class ContoCorrente
{
    private decimal saldo;

    public decimal Saldo
    {
        get { return saldo; }
        set
        {
            if (value >= 0)
            {
                saldo = value;
            }
        }
    }
    private int numeroOperazioni;
    public int NumeroOperazioni
    {
        get { return numeroOperazioni; }
        set
        {
            if (value >= 0)
            {
                numeroOperazioni = value;
            }
        }
    }
    public void Versa(decimal importo)
    {
        if (importo == 0)
        {
            Console.WriteLine("Numero inserito non valido");
        }
        else if (importo >= 0)
        {
            saldo += importo;
            Console.WriteLine($"{importo}€ caricati");
        }
        else
        {
            Console.WriteLine("Non valido");
        }
    }

    public void Preleva(decimal importo)
    {
        if (importo <= 0)
        {
            Console.WriteLine("Numero inserito non valido");
        }
        else if (importo <= Saldo)
        {
            saldo -= importo;
            Console.WriteLine($"{importo}€ sono stati prelevati dal tuo conto");
        }
        else
        {
            Console.WriteLine("Non puoi prelevare più soldi di quelli disponibili");
        }
    }

    public string toString()
    {
        return $"Il saldo è {saldo}, le operazioni effettuate sono {numeroOperazioni}";
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        ContoCorrente conto = new ContoCorrente();

        bool continua = true;

        while (continua)
        {
            Console.WriteLine("Vuoi prelevare o versare o stampare | p - v - s - uscire dal programma u?");
            string scelta = Console.ReadLine();

            switch (scelta)
            {
                case "p":
                    Console.WriteLine("Quanto vuoi prelevare");
                    int prelevaValore = int.Parse(Console.ReadLine());
                    conto.Preleva(prelevaValore);
                    conto.NumeroOperazioni++;
                    break;
                case "v":
                    Console.WriteLine("Quanto vuoi versare?");
                    int versaValore = int.Parse(Console.ReadLine());
                    conto.Versa(versaValore);
                    conto.NumeroOperazioni++;
                    break;
                case "s":
                    Console.WriteLine(conto.toString());
                    break;
                case "u":
                    Console.WriteLine("Arrivederci");
                    continua = false;
                    break;
                default:
                    Console.WriteLine("Hai sbagliato campione");
                    conto.toString();
                    break;
            }
        }
    }
}
