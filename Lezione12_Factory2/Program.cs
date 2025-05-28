using System;

// Interfaccia che rappresenta un veicolo generico
public interface IVeicolo
{
    // Metodo per avviare il veicolo
    void Avvia();
    // Metodo per mostrare il tipo di veicolo
    void MostraTipo();
}

// Classe concreta che rappresenta un'auto
public class ConcreteAuto : IVeicolo
{
    public void Avvia()
    {
        Console.WriteLine("Avvio dell'auto.");
    }

    public void MostraTipo()
    {
        Console.WriteLine("Tipo: Auto");
    }
}

// Classe concreta che rappresenta una moto
public class ConcreteMoto : IVeicolo
{
    public void Avvia()
    {
        Console.WriteLine("Avvio della moto.");
    }

    public void MostraTipo()
    {
        Console.WriteLine("Tipo: Moto");
    }
}

// Classe concreta che rappresenta un camion
public class ConcreteCamion : IVeicolo
{
    public void Avvia()
    {
        Console.WriteLine("Avvio del camion.");
    }

    public void MostraTipo()
    {
        Console.WriteLine("Tipo: Camion");
    }
}

// Classe astratta che funge da Factory per creare veicoli
public abstract class VeicoloFactory
{
    // Metodo statico che crea un veicolo in base al tipo richiesto
    public static IVeicolo CreaVeicolo(string tipo)
    {
        switch (tipo)
        {
            case "auto":
                return new ConcreteAuto(); // Ritorna un oggetto ConcreteAuto
            case "moto":
                return new ConcreteMoto(); // Ritorna un oggetto ConcreteMoto
            case "camion":
                return new ConcreteCamion(); // Ritorna un oggetto ConcreteCamion
            default:
                // Se il tipo non è valido, viene sollevata un'eccezione
                throw new ArgumentException("Inserisci un tipo di veicolo valido: auto, moto o camion.");
        }
    }
}

// Classe principale del programma
public class Program
{
    public static void Main(string[] args)
    {
        // Chiede all'utente di inserire il tipo di veicolo desiderato
        Console.WriteLine("Inserisci il tipo di veicolo (auto, moto, camion):");
        string input = Console.ReadLine(); 

        // Usa la factory per creare il veicolo richiesto
        IVeicolo veicolo = VeicoloFactory.CreaVeicolo(input);
        if(veicolo != null)
        {
            veicolo.Avvia();      // Avvia il veicolo
            veicolo.MostraTipo(); // Mostra il tipo di veicolo
            Console.WriteLine("Veicolo creato.");
        }else
        {
            Console.WriteLine("Veicolo non creato.");
        }
        
    }
}
