using System;

public interface IBevanda
{
    string Descrizione { get; set; }
    double Costo();
}
public class Caffe : IBevanda
{
    public string Descrizione { get; set; } = "Caffè";

    public double Costo()
    {
        return 1.00; // Prezzo del caffè
    }
}
public class Te : IBevanda
{
    public string Descrizione { get; set; } = "Tè";

    public double Costo()
    {
        return 1.50; // Prezzo del tè
    }
}

public abstract class DecoratoreBevanda : IBevanda
{
    protected IBevanda _bevanda;

    protected DecoratoreBevanda(IBevanda bevanda)
    {
        _bevanda = bevanda;
    }
    public virtual string Descrizione
    {
        get { return _bevanda.Descrizione; }
        set { _bevanda.Descrizione = value; }
    }
    public virtual double Costo()
    {
        return _bevanda.Costo();
    }
}

public class ConLatte : DecoratoreBevanda
{
    public ConLatte(IBevanda bevanda) : base(bevanda) { }

    public override string Descrizione
    {
        get { return _bevanda.Descrizione + ", Latte"; }
    }

    public override double Costo()
    {
        return _bevanda.Costo() + 0.50;
    }
}
public class ConCioccolato : DecoratoreBevanda
{
    public ConCioccolato(IBevanda bevanda) : base(bevanda) { }

    public override string Descrizione
    {
        get { return _bevanda.Descrizione + ", Cioccolato"; }
    }

    public override double Costo()
    {
        return _bevanda.Costo() + 0.70;
    }
}

public class ConPanna : DecoratoreBevanda
{
    public ConPanna(IBevanda bevanda) : base(bevanda) { }

    public override string Descrizione
    {
        get { return _bevanda.Descrizione + ", Panna"; }
    }

    public override double Costo()
    {
        return _bevanda.Costo() + 0.30;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        bool esci = false;
        
        // ciclo principale del menù
        while (!esci)
        {
            Console.WriteLine("\n-- Menù bevande (molto ricco) --");
            Console.WriteLine("[1] Caffè | [2] Tè | [0] Esci");
            string scelta = Console.ReadLine();
        
            switch (scelta)
            {
                case "1":
                    IBevanda bevandaCaffe = new Caffe();
                    Console.WriteLine("Hai scelto un Caffè. Ecco il prezzo base: " + bevandaCaffe.Costo() + "€");
                    Console.WriteLine("Vuoi aggiungere qualcosa? (1) Latte (2) Cioccolato (3) Panna (0) Nessuno");
                    string sceltaAggiunta = Console.ReadLine();
                    bool aggCaff = true;
                    while (aggCaff)
                    {
                        switch (sceltaAggiunta)
                        {
                            case "1":
                                bevandaCaffe = new ConLatte(bevandaCaffe);
                                Console.WriteLine("Hai aggiunto Latte. Nuovo prezzo: " + bevandaCaffe.Costo() + "€");
                                break;
                            case "2":
                                bevandaCaffe = new ConCioccolato(bevandaCaffe);
                                Console.WriteLine("Hai aggiunto Cioccolato. Nuovo prezzo: " + bevandaCaffe.Costo() + "€");
                                break;
                            case "3":
                                bevandaCaffe = new ConPanna(bevandaCaffe);
                                Console.WriteLine("Hai aggiunto Panna. Nuovo prezzo: " + bevandaCaffe.Costo() + "€");
                                break;
                            case "0":
                                Console.WriteLine("Ok, nessuna aggiunta. Allora devi pagara " + bevandaCaffe.Costo() + "€");
                                break;
                            default:
                                Console.WriteLine("Scelta non valida.");
                                continue;
                        }
                    }
                        break;
                    
        
                case "2":
                    IBevanda bevandaTè = new Te();
                    Console.WriteLine("Hai scelto un Tè. Ecco il prezzo base: " + bevandaTè.Costo() + "€");
                    Console.WriteLine("Vuoi aggiungere qualcosa? (1) Latte (2) Cioccolato (3) Panna (0) Nessuno");
                    string sceltaAggiuntaTè = Console.ReadLine();
                    switch (sceltaAggiuntaTè)
                    {
                        case "1":
                            bevandaTè = new ConLatte(bevandaTè);
                            Console.WriteLine("Hai aggiunto Latte. Nuovo prezzo: " + bevandaTè.Costo() + "€");
                            break;
                        case "2":
                            bevandaTè = new ConCioccolato(bevandaTè);
                            Console.WriteLine("Hai aggiunto Cioccolato. Nuovo prezzo: " + bevandaTè.Costo() + "€");
                            break;
                        case "3":
                            bevandaTè = new ConPanna(bevandaTè);
                            Console.WriteLine("Hai aggiunto Panna. Nuovo prezzo: " + bevandaTè.Costo() + "€");
                            break;
                        case "0":
                            Console.WriteLine("Ok, nessuna aggiunta. Allora devi pagara " + bevandaTè.Costo() + "€");
                            break;
                        default:
                            Console.WriteLine("Scelta non valida.");
                            continue;
                    }
                    break;
        
                case "0":
                    Console.WriteLine("Arrivederci");
                    esci = true;
                    break;
        
                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
        }
    }
}
