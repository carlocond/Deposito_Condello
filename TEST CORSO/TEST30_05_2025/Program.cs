using System;
using System.Collections.Generic;

// INTERFACCIA BASE
public interface IPizza
{
    string Descrizione();
    string CreaPizza(string tipo);
}

// TIPI DI PIZZA (Factory)
public class PizzaMargherita : IPizza
{
    public string Descrizione()
    {
        return "Pizza Margherita: impasto, salsa di pomodoro, mozzarella.";
    }
    
    public string CreaPizza(string tipo) { return "Preparazione della Pizza Margherita"; }
}

public class PizzaDiavola : IPizza
{
    public string Descrizione() {
        return "Pizza Diavola: impasto, salsa di pomodoro, mozzarella, salame piccante.";
    }
    public string CreaPizza(string tipo) { return "Preparazione della Pizza Diavola"; }
}

public class PizzaVegetariana : IPizza
{
    public string Descrizione()
    {
        return "Pizza Vegetariana: impasto, salsa di pomodoro, mozzarella, verdure grigliate.";
    }
    public string CreaPizza(string tipo) { return "Preparazione della Pizza Vegetariana"; }
}

// FACTORY
public abstract class PizzaFactory
{
    public static IPizza CreaPizza(string tipo)
    {
        // Crea l'oggetto pizza in base al tipo richiesto
        switch (tipo.ToLower())
        {
            case "margherita": return new PizzaMargherita();
            case "diavola": return new PizzaDiavola();
            case "vegetariana": return new PizzaVegetariana();
            default: throw new ArgumentException("Tipo di pizza non riconosciuto.");
        }
    }
}

// DECORATOR - Ingredienti Extra
public abstract class IngredienteExtra : IPizza
{
    protected IPizza _pizza;
    protected IngredienteExtra(IPizza pizza) { _pizza = pizza; }
    public virtual string Descrizione() {
        return _pizza.Descrizione();
    } 
    // Permette di aggiungere ingredienti extra mantenendo la struttura della pizza base
    public virtual string CreaPizza(string tipo) => _pizza.CreaPizza(tipo);
}

public class ConOlive : IngredienteExtra
{
    public ConOlive(IPizza pizza) : base(pizza) { }
    public override string Descrizione()
    {
        return _pizza.Descrizione() + " con olive.";
    }
    public override string CreaPizza(string tipo)
    {
      return  _pizza.CreaPizza(tipo) + " Aggiunta delle olive.";
    }
}

public class ConMozzarellaExtra : IngredienteExtra
{
    public ConMozzarellaExtra(IPizza pizza) : base(pizza) { }
    public override string Descrizione()
    {
        return _pizza.Descrizione() + " con mozzarella extra.";
    }
    public override string CreaPizza(string tipo)
    {
        return _pizza.CreaPizza(tipo) + " Aggiunta di mozzarella extra.";
    }
}

public class ConFunghi : IngredienteExtra
{
    public ConFunghi(IPizza pizza) : base(pizza) { }
    public override string Descrizione()
    {
        return _pizza.Descrizione() + " con funghi.";
    }
    public override string CreaPizza(string tipo)
    {
        return _pizza.CreaPizza(tipo) + " Aggiunta dei funghi.";
    } 
}

// STRATEGY - Metodo di Cottura
public interface IMetodoCottura
{
    string Cuoci(string pizza);
}

public class FornoElettrico : IMetodoCottura
{
    public string Cuoci(string pizza) { return $"Cottura della {pizza} nel forno elettrico."; }
}

public class FornoALegna : IMetodoCottura
{
    public string Cuoci(string pizza) { return $"Cottura della {pizza} nel forno a legna."; }
}

public class FornoVentilato : IMetodoCottura
{
    public string Cuoci(string pizza) { return $"Cottura della {pizza} nel forno ventilato."; }
}

// SINGLETON - Gestione Ordine
public class GestoreOrdine
{
    private static GestoreOrdine? _istanza; // Nullable per evitare warning
    public string? OrdineCorrente { get; private set; } // Nullable per evitare warning

    private GestoreOrdine() { }

    // Garantisce che esista una sola istanza di GestoreOrdine
    public static GestoreOrdine Istanza => _istanza ??= new GestoreOrdine();

    public void SalvaOrdine(string descrizione) => OrdineCorrente = descrizione;
}

// OBSERVER - Sistemi Esterni
public interface IObserver
{
    void Notifica(string messaggio);
}

public class SistemaLog : IObserver
{
    public void Notifica(string messaggio) => Console.WriteLine($"[LOG] {messaggio}");
}

public class SistemaMarketing : IObserver
{
    public void Notifica(string messaggio) => Console.WriteLine($"[MARKETING] Promo inviata per: {messaggio}");
}

public class NotifyCambiamenti : IObserver
{
    public void Notifica(string messaggio) => Console.WriteLine($"[NOTIFICA CAMBIAMENTO] {messaggio}");
}

public class NotificatoreOrdine
{
    private readonly List<IObserver> _osservatori = new();

    public void Aggiungi(IObserver osservatore) => _osservatori.Add(osservatore);

    // Notifica tutti i sistemi esterni (observer) di un nuovo ordine
    public void NotificaTutti(string messaggio)
    {
        foreach (var osservatore in _osservatori)
            osservatore.Notifica(messaggio);
    }
}

// MAIN
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Benvenuto nella Pizzeria Smart!");

        bool esci = false;
        while (!esci)
        {
            Console.WriteLine("\nScegli una pizza: \n[1] Margherita \n[2] Diavola \n[3] Vegetariana \n[0] Esci");
            string? sceltaInput = Console.ReadLine();
            string scelta = sceltaInput ?? "";

            switch (scelta)
            {
                case "1":
                    GestisciPiatto("margherita");
                    break;
                case "2":
                    GestisciPiatto("diavola");
                    break;
                case "3":
                    GestisciPiatto("vegetariana");
                    break;
                case "0":
                    esci = true;
                    break;
                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
        }
    }

    public static void GestisciPiatto(string tipo)
    {
        IPizza pizza = PizzaFactory.CreaPizza(tipo);
        Console.WriteLine($"Hai scelto: {pizza.Descrizione()}");

        bool aggiunta = true;
        while (aggiunta)
        {
            // Permette di aggiungere ingredienti extra tramite il pattern Decorator
            Console.WriteLine("\nVuoi aggiungere ingredienti extra?");
            Console.WriteLine("[1] Olive\n[2] Mozzarella Extra\n[3] Funghi\n[0] Nessuno");
            string? sceltaIngredienteInput = Console.ReadLine();
            string sceltaIngrediente = sceltaIngredienteInput ?? "";

            switch (sceltaIngrediente)
            {
                case "1":
                    pizza = new ConOlive(pizza);
                    Console.WriteLine("Hai aggiunto le olive.");
                    break;
                case "2":
                    pizza = new ConMozzarellaExtra(pizza);
                    Console.WriteLine("Hai aggiunto mozzarella extra.");
                    break;
                case "3":
                    pizza = new ConFunghi(pizza);
                    Console.WriteLine("Hai aggiunto i funghi.");
                    break;
                case "0":
                    aggiunta = false;
                    break;
                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
        }

        Console.WriteLine("\nMetodo di cottura:");
        Console.WriteLine("[1] Forno Elettrico\n[2] Forno a Legna\n[3] Forno Ventilato");
        string? sceltaCotturaInput = Console.ReadLine();
        string sceltaCottura = sceltaCotturaInput ?? "";

        IMetodoCottura metodo;
        switch (sceltaCottura)
        {
            case "1":
                metodo = new FornoElettrico();
                break;
            case "2":
                metodo = new FornoALegna();
                break;
            case "3":
                metodo = new FornoVentilato();
                break;
            default:
                Console.WriteLine("Scelta non valida, uso forno elettrico di default.");
                metodo = new FornoElettrico();
                break;
        }

        string descrizione = pizza.Descrizione();
        string preparazione = pizza.CreaPizza(tipo);
        string cottura = metodo.Cuoci(descrizione);

        // Salvataggio ordine (Singleton)
        GestoreOrdine.Istanza.SalvaOrdine(cottura);

        // Notifica (Observer)
        NotificatoreOrdine notificatore = new();
        notificatore.Aggiungi(new SistemaLog());
        notificatore.Aggiungi(new SistemaMarketing());
        notificatore.Aggiungi(new NotifyCambiamenti());

        notificatore.NotificaTutti(cottura);

        Console.WriteLine($"\nOrdine completato: {cottura}");
    }
}
