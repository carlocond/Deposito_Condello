using System;

public interface IPiatto
{
    string Descrizione();
    string Prepara();
}

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
        Console.WriteLine("Scegli un piatto: \n[1] Pizza \n[2] Hamburger \n[3] Insalata \n[0] Esci");
        string scelta = Console.ReadLine();
        bool esci = false;
        bool agg = true;

        while (!esci)
        {


            switch (scelta)
            {
                case "1":
                    Console.WriteLine("Hai scelto la Pizza.");
                    IPiatto pizza = PiattoFactory.CreaPiatto("pizza");
                    Console.WriteLine(pizza.Descrizione());
                    while (agg)
                    {
                        Console.WriteLine("Vuoi aggiungere ingredienti extra? \n[1] Formaggio \n[2] Bacon \n[3] Salsa \n[0] Nessuno");
                        string sceltaIngrediente = Console.ReadLine(); 
                        switch (sceltaIngrediente)
                        {
                            case "1":
                                pizza = new ConFormaggio(pizza);
                                Console.WriteLine("Hai aggiunto formaggio extra.");
                                break;

                            case "2":
                                pizza = new ConBacon(pizza);
                                Console.WriteLine("Hai aggiunto bacon.");
                                break;

                            case "3":
                                pizza = new ConSalsa(pizza);
                                Console.WriteLine("Hai aggiunto salsa.");
                                break;

                            case "0":
                                Console.WriteLine("Ok, nessuna aggiunta. " + pizza.Descrizione());
                                agg = false; 
                                Console.WriteLine("Come vuoi preparare la tua pizza? \n[1] Fritto \n[2] Al Forno \n[3] Alla Griglia");
                                string sceltaPreparazione = Console.ReadLine();
                                Chef chef = new Chef();
                                switch (sceltaPreparazione)
                                {
                                    case "1":
                                        chef.ImpostaStrategia(new Fritto());
                                        Console.WriteLine(chef.PreparaPiatto(pizza));
                                        break;

                                    case "2":
                                        chef.ImpostaStrategia(new AlForno());
                                        Console.WriteLine(chef.PreparaPiatto(pizza));
                                        break;

                                    case "3":
                                        chef.ImpostaStrategia(new AllaGriglia());
                                        Console.WriteLine(chef.PreparaPiatto(pizza));
                                        break;

                                    default:
                                        Console.WriteLine("Scelta di preparazione non valida.");
                                        break;
                                }
                                break;

                            default:
                                Console.WriteLine("Scelta non valida.");
                                break;
                        }
                    }
                    

                    break;

                case "2":
                    Console.WriteLine("Hai scelto l'Hamburger.");
                    IPiatto hamburger = PiattoFactory.CreaPiatto("hamburger");
                    Console.WriteLine(hamburger.Descrizione());
                    while (agg)
                    {
                        Console.WriteLine("Vuoi aggiungere ingredienti extra? \n[1] Formaggio \n[2] Bacon \n[3] Salsa \n[0] Nessuno");
                        string sceltaIngrediente = Console.ReadLine();
                        switch (sceltaIngrediente)
                        {
                            case "1":
                                hamburger = new ConFormaggio(hamburger);
                                Console.WriteLine("Hai aggiunto formaggio extra.");
                                break;

                            case "2":
                                hamburger = new ConBacon(hamburger);
                                Console.WriteLine("Hai aggiunto bacon.");
                                break;

                            case "3":
                                hamburger = new ConSalsa(hamburger);
                                Console.WriteLine("Hai aggiunto salsa.");
                                break;

                            case "0":
                                Console.WriteLine("Ok, nessuna aggiunta. " + hamburger.Descrizione());
                                agg = false;
                                Console.WriteLine("Come vuoi preparare il tuo hamburger? \n[1] Fritto \n[2] Al Forno \n[3] Alla Griglia");
                                string sceltaPreparazione = Console.ReadLine();
                                Chef chef = new Chef();
                                switch (sceltaPreparazione)
                                {
                                    case "1":
                                        chef.ImpostaStrategia(new Fritto());
                                        Console.WriteLine(chef.PreparaPiatto(hamburger));
                                        break;

                                    case "2":
                                        chef.ImpostaStrategia(new AlForno());
                                        Console.WriteLine(chef.PreparaPiatto(hamburger));
                                        break;

                                    case "3":
                                        chef.ImpostaStrategia(new AllaGriglia());
                                        Console.WriteLine(chef.PreparaPiatto(hamburger));
                                        break;

                                    default:
                                        Console.WriteLine("Scelta di preparazione non valida.");
                                        break;
                                }
                                break;

                            default:
                                Console.WriteLine("Scelta non valida.");
                                break;
                        }
                    }
                    break;

                case "3":
                    Console.WriteLine("Hai scelto l'Insalata.");
                    IPiatto insalata = PiattoFactory.CreaPiatto("insalata");
                    Console.WriteLine(insalata.Descrizione());
                    while (agg)
                    {
                        Console.WriteLine("Vuoi aggiungere ingredienti extra? \n[1] Formaggio \n[2] Bacon \n[3] Salsa \n[0] Nessuno");
                        string sceltaIngrediente = Console.ReadLine();
                        switch (sceltaIngrediente)
                        {
                            case "1":
                                insalata = new ConFormaggio(insalata);
                                Console.WriteLine("Hai aggiunto formaggio extra.");
                                break;

                            case "2":
                                insalata = new ConBacon(insalata);
                                Console.WriteLine("Hai aggiunto bacon.");
                                break;

                            case "3":
                                insalata = new ConSalsa(insalata);
                                Console.WriteLine("Hai aggiunto salsa.");
                                break;

                            case "0":
                                Console.WriteLine("Ok, nessuna aggiunta. " + insalata.Descrizione());
                                agg = false;
                                Console.WriteLine("Come vuoi preparare la tua insalata? \n[1] Fritto \n[2] Al Forno \n[3] Alla Griglia");
                                string sceltaPreparazione = Console.ReadLine();
                                Chef chef = new Chef();
                                switch (sceltaPreparazione)
                                {
                                    case "1":
                                        chef.ImpostaStrategia(new Fritto());
                                        Console.WriteLine(chef.PreparaPiatto(insalata));
                                        break;

                                    case "2":
                                        chef.ImpostaStrategia(new AlForno());
                                        Console.WriteLine(chef.PreparaPiatto(insalata));
                                        break;

                                    case "3":
                                        chef.ImpostaStrategia(new AllaGriglia());
                                        Console.WriteLine(chef.PreparaPiatto(insalata));
                                        break;

                                    default:
                                        Console.WriteLine("Scelta di preparazione non valida.");
                                        break;
                                }
                                break;

                            default:
                                Console.WriteLine("Scelta non valida.");
                                break;
                        }
                    }
                    break;

                case "0":
                    Console.WriteLine("Grazie per aver scelto il nostro ristorante!");
                    esci = true; // Esce dal ciclo
                    break;

                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
        }
    }
}
