using System;

// Interfaccia che definisce la strategia per un'operazione matematica
public interface IStrategiaOperazione
{
    // Metodo che esegue il calcolo tra due numeri
    double Calcola(double a, double b);
}

// Strategia per la somma
public class SommaStrategia : IStrategiaOperazione
{
    public double Calcola(double a, double b)
    {
        return a + b;
    }
}
// Strategia per la sottrazione
public class SottrazioneStrategia : IStrategiaOperazione
{
    public double Calcola(double a, double b)
    {
        return a - b;
    }
}
// Strategia per la moltiplicazione
public class MoltiplicazioneStrategia : IStrategiaOperazione
{
    public double Calcola(double a, double b)
    {
        return a * b;
    }
}
// Strategia per la divisione
public class DivisioneStrategia : IStrategiaOperazione
{
    public double Calcola(double a, double b)
    {
        if (b == 0)
        {
            Console.WriteLine("Divisione per zero non permessa.");
        }
        return a / b;
    }
}

// Context: la calcolatrice usa una strategia per eseguire l'operazione
public class Calcolatrice
{
    private IStrategiaOperazione _strategia; // Strategia attuale

    // Esegue l'operazione usando la strategia impostata
    public void EseguiOperazione(double a, double b)
    {
        if (_strategia == null)
        {
            Console.WriteLine("Nessuna strategia impostata.");
            return;
        }
        double risultato = _strategia.Calcola(a, b);
        Console.WriteLine($"Risultato dell'operazione: {risultato}");
    }

    // Imposta la strategia da usare
    public void ImpostaStrategia(IStrategiaOperazione strategia)
    {
        _strategia = strategia;
    }
}

// Classe principale del programma
public class Program
{
    public static void Main(string[] args)
    {
        var calcolatrice = new Calcolatrice(); // Istanzia la calcolatrice

        bool continua = true;

        while (continua)
        {
            // Menu per scegliere l'operazione
            Console.WriteLine("Scegli un'operazione \n[1] Somma \n[2] Sottrazione \n[3] Moltiplicazione \n[4] Divisione \n[5] Esci");
            string scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                    calcolatrice.ImpostaStrategia(new SommaStrategia()); // Imposta la strategia di somma
                    Console.WriteLine("Hai scelto la somma, inserisci il primo numero");
                    double a = double.Parse(Console.ReadLine());
                    Console.WriteLine("Inserisci il secondo numero");
                    double b = double.Parse(Console.ReadLine());

                    calcolatrice.EseguiOperazione(a, b);
                    break;
                case "2":
                    calcolatrice.ImpostaStrategia(new SottrazioneStrategia()); // Imposta la strategia di sottrazione
                    Console.WriteLine("Hai scelto la sottrazione, inserisci il primo numero");
                    a = double.Parse(Console.ReadLine());
                    Console.WriteLine("Inserisci il secondo numero");
                    b = double.Parse(Console.ReadLine());

                    calcolatrice.EseguiOperazione(a, b);
                    break;
                case "3":
                    calcolatrice.ImpostaStrategia(new MoltiplicazioneStrategia()); // Imposta la strategia di moltiplicazione
                    Console.WriteLine("Hai scelto la moltiplicazione, inserisci il primo numero");
                    a = double.Parse(Console.ReadLine());
                    Console.WriteLine("Inserisci il secondo numero");
                    b = double.Parse(Console.ReadLine());

                    calcolatrice.EseguiOperazione(a, b);
                    break;
                case "4":
                    calcolatrice.ImpostaStrategia(new DivisioneStrategia()); // Imposta la strategia di divisione
                    Console.WriteLine("Hai scelto la divisione, inserisci il primo numero");
                    a = double.Parse(Console.ReadLine());
                    Console.WriteLine("Inserisci il secondo numero");
                    b = double.Parse(Console.ReadLine());

                    calcolatrice.EseguiOperazione(a, b);
                    break;
                case "5":
                    continua = false;
                    Console.WriteLine("Arrivederci");
                    break;
            }
        }
    }
}
