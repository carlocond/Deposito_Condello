using System;

// Interfaccia base per ogni piatto
public interface IPiatto
{
    string Descrizione();
    string Prepara();
}

// Implementazioni concrete dei piatti
public class Pizza : IPiatto
{
    public string Descrizione()
    {
        return "Pizza Margherita: impasto, salsa di pomodoro, mozzarella.";
    }

    public string Prepara()
    {
        return "Preparazione della Pizza Margherita";
    }
}
public class Hamburger : IPiatto
{
    public string Descrizione()
    {
        return "Hamburger Classico: pane, carne, lattuga, pomodoro.";
    }

    public string Prepara()
    {
        return "Preparazione dell'Hamburger Classico";
    }
}
public class Insalata : IPiatto
{
    public string Descrizione()
    {
        return "Insalata Mista: lattuga, pomodori, cetrioli, carote.";
    }

    public string Prepara()
    {
        return "Preparazione dell'Insalata Mista";
    }
}

// Decorator base per ingredienti extra
public abstract class IngredienteExtra : IPiatto
{
    protected IPiatto _piatto;

    protected IngredienteExtra(IPiatto piatto)
    {
        _piatto = piatto;
    }

    public virtual string Descrizione()
    {
        return _piatto.Descrizione();
    }

    public virtual string Prepara()
    {
        return _piatto.Prepara();
    }
}

// Decorator concreti
public class ConFormaggio : IngredienteExtra
{
    public ConFormaggio(IPiatto piatto) : base(piatto) { }

    public override string Descrizione()
    {
        return _piatto.Descrizione() + ", con formaggio extra.";
    }

    public override string Prepara()
    {
        return _piatto.Prepara() + " Aggiunta di formaggio extra.";
    }
}
public class ConBacon : IngredienteExtra
{
    public ConBacon(IPiatto piatto) : base(piatto) { }

    public override string Descrizione()
    {
        return _piatto.Descrizione() + ", con bacon";
    }

    public override string Prepara()
    {
        return _piatto.Prepara() + " Aggiunta di bacon";
    }
}
public class ConSalsa : IngredienteExtra
{
    public ConSalsa(IPiatto piatto) : base(piatto) { }

    public override string Descrizione()
    {
        return _piatto.Descrizione() + ", con salsa";
    }

    public override string Prepara()
    {
        return _piatto.Prepara() + " Aggiunta di salsa";
    }
}

// Factory dei piatti
public abstract class PiattoFactory
{
    public static IPiatto CreaPiatto(string tipo)
    {
        switch (tipo.ToLower())
        {
            case "pizza":
                return new Pizza();
            case "hamburger":
                return new Hamburger();
            case "insalata":
                return new Insalata();
            default:
                throw new ArgumentException("Tipo di piatto non valido. Scegli tra pizza, hamburger o insalata.");
        }
    }
}

// Interfaccia Strategy
public interface IPreparazioneStrategia
{
    string Prepara(string descrizione);
}
public class Fritto : IPreparazioneStrategia
{
    public string Prepara(string descrizione)
    {
        return $"Fritto: {descrizione}";
    }
}
public class AlForno : IPreparazioneStrategia
{
    public string Prepara(string descrizione)
    {
        return $"Al Forno: {descrizione}";
    }
}
public class AllaGriglia : IPreparazioneStrategia
{
    public string Prepara(string descrizione)
    {
        return $"Alla Griglia: {descrizione}";
    }
}

// Context Strategy
public class Chef
{
    private IPreparazioneStrategia _strategia;

    public void ImpostaStrategia(IPreparazioneStrategia strategia)
    {
        _strategia = strategia;
    }

    public string PreparaPiatto(IPiatto piatto)
    {
        if (_strategia == null)
        {
            throw new InvalidOperationException("Nessuna strategia di preparazione impostata.");
        }
        return _strategia.Prepara(piatto.Descrizione());
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Benvenuto nel ristorante!");

        bool esci = false;
        while (!esci)
        {
            // Richiedi sempre la scelta del piatto ad ogni ciclo
            Console.WriteLine("\nScegli un piatto: \n[1] Pizza \n[2] Hamburger \n[3] Insalata \n[0] Esci");
            string scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                    GestisciPiatto("pizza");
                    break;
                case "2":
                    GestisciPiatto("hamburger");
                    break;
                case "3":
                    GestisciPiatto("insalata");
                    break;
                case "0":
                    Console.WriteLine("Grazie per aver scelto il nostro ristorante!");
                    esci = true;
                    break;
                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
        }
    }

    // Funzione per gestire la logica comune dei piatti
    public static void GestisciPiatto(string tipo)
    {
        IPiatto piatto = PiattoFactory.CreaPiatto(tipo);
        Console.WriteLine($"Hai scelto: {piatto.Descrizione()}");

        bool agg = true;
        while (agg)
        {
            Console.WriteLine("Vuoi aggiungere ingredienti extra? \n[1] Formaggio \n[2] Bacon \n[3] Salsa \n[0] Nessuno");
            string sceltaIngrediente = Console.ReadLine();
            switch (sceltaIngrediente)
            {
                case "1":
                    piatto = new ConFormaggio(piatto);
                    Console.WriteLine("Hai aggiunto formaggio extra.");
                    break;
                case "2":
                    piatto = new ConBacon(piatto);
                    Console.WriteLine("Hai aggiunto bacon.");
                    break;
                case "3":
                    piatto = new ConSalsa(piatto);
                    Console.WriteLine("Hai aggiunto salsa.");
                    break;
                case "0":
                    Console.WriteLine("Ok, nessuna aggiunta. " + piatto.Descrizione());
                    agg = false;
                    break;
                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
        }

        Console.WriteLine("Come vuoi preparare il tuo piatto? \n[1] Fritto \n[2] Al Forno \n[3] Alla Griglia");
        string sceltaPreparazione = Console.ReadLine();
        Chef chef = new Chef();
        switch (sceltaPreparazione)
        {
            case "1":
                chef.ImpostaStrategia(new Fritto());
                Console.WriteLine(chef.PreparaPiatto(piatto));
                break;
            case "2":
                chef.ImpostaStrategia(new AlForno());
                Console.WriteLine(chef.PreparaPiatto(piatto));
                break;
            case "3":
                chef.ImpostaStrategia(new AllaGriglia());
                Console.WriteLine(chef.PreparaPiatto(piatto));
                break;
            default:
                Console.WriteLine("Scelta di preparazione non valida.");
                break;
        }
    }
}
