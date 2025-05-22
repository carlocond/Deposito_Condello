using System;


public class ContoBancario
{
    //Campo privato (non accessibile direttamente dall'esterno) 
    private double saldo;

    //Proprietà per accedere al saldo in modo controllato
    public double Saldo
    {
        //Metodo che permette la lettura del saldo
        get { return saldo; }

        set
        {
            if (value >= 0)
            {
                saldo = value;
            }
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        ContoBancario conto = new ContoBancario();

        //Richiamo del metodo per impostare il saldo tramite la proprietà
        conto.Saldo = 1000.50;
        //Leggere il saldo tramite la prorpietà
        Console.WriteLine(conto.Saldo);

        //Non permette la modifica del saldo perchè è negativo
        conto.Saldo = -500;
        //Stampa del saldo che rimane identico a prima
        Console.WriteLine(conto.Saldo);
    }
}

