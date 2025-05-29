using System;

public interface IBevanda
{
    string Descrizione { get; }
    double Costo();
}

public class Caffe : IBevanda
{
    public string Descrizione { get; } = "Caffè";

    public double Costo() => 1.00;
}

public class Te : IBevanda
{
    public string Descrizione { get; } = "Tè";

    public double Costo() => 1.50;
}

public abstract class DecoratoreBevanda : IBevanda
{
    protected IBevanda _bevanda;
    protected DecoratoreBevanda(IBevanda bevanda)
    {
        _bevanda = bevanda;
    }
    public virtual string Descrizione => _bevanda.Descrizione;
    public virtual double Costo() => _bevanda.Costo();
}

public class ConLatte : DecoratoreBevanda
{
    public ConLatte(IBevanda bevanda) : base(bevanda) { }
    public override string Descrizione => _bevanda.Descrizione + ", Latte";
    public override double Costo() => _bevanda.Costo() + 0.50;
}

public class ConCioccolato : DecoratoreBevanda
{
    public ConCioccolato(IBevanda bevanda) : base(bevanda) { }
    public override string Descrizione => _bevanda.Descrizione + ", Cioccolato";
    public override double Costo() => _bevanda.Costo() + 0.70;
}

public class ConPanna : DecoratoreBevanda
{
    public ConPanna(IBevanda bevanda) : base(bevanda) { }
    public override string Descrizione => _bevanda.Descrizione + ", Panna";
    public override double Costo() => _bevanda.Costo() + 0.30;
}

public class Program
{
    public static void Main(string[] args)
    {
        bool esci = false;

        while (!esci)
        {
            Console.WriteLine("\n-- Menù bevande (molto ricco) --");
            Console.WriteLine("[1] Caffè | [2] Tè | [0] Esci");
            string scelta = Console.ReadLine();

            IBevanda bevanda = null;

            switch (scelta)
            {
                case "1":
                    bevanda = new Caffe();
                    break;
                case "2":
                    bevanda = new Te();
                    break;
                case "0":
                    Console.WriteLine("Arrivederci!");
                    esci = true;
                    continue;
                default:
                    Console.WriteLine("Scelta non valida.");
                    continue;
            }

            Console.WriteLine($"Hai scelto: {bevanda.Descrizione}. Prezzo base: {bevanda.Costo():0.00}€");

            // Aggiunte multiple
            bool aggiunte = true;
            while (aggiunte)
            {
                Console.WriteLine("Vuoi aggiungere qualcosa? (1) Latte (2) Cioccolato (3) Panna (0) Nessuna aggiunta");
                string sceltaAggiunta = Console.ReadLine();
                switch (sceltaAggiunta)
                {
                    case "1":
                        bevanda = new ConLatte(bevanda);
                        Console.WriteLine($"Hai aggiunto Latte. Nuovo prezzo: {bevanda.Costo():0.00}€");
                        break;
                    case "2":
                        bevanda = new ConCioccolato(bevanda);
                        Console.WriteLine($"Hai aggiunto Cioccolato. Nuovo prezzo: {bevanda.Costo():0.00}€");
                        break;
                    case "3":
                        bevanda = new ConPanna(bevanda);
                        Console.WriteLine($"Hai aggiunto Panna. Nuovo prezzo: {bevanda.Costo():0.00}€");
                        break;
                    case "0":
                        aggiunte = false;
                        break;
                    default:
                        Console.WriteLine("Scelta non valida.");
                        break;
                }
            }

            Console.WriteLine($"Ordine completo: {bevanda.Descrizione}");
            Console.WriteLine($"Totale da pagare: {bevanda.Costo():0.00}€");
        }
    }
}
