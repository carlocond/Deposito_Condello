using System;

// Interfaccia che rappresenta un veicolo generico
public interface IVeicolo
{
    string Modello{ get; }
    // Metodo per avviare il veicolo
    void Avvia();
    // Metodo per mostrare il tipo di veicolo
    void MostraTipo();
}

// Classe concreta che rappresenta un'auto
public class ConcreteAuto : IVeicolo
{
    public string Modello { get;  set; }
    public ConcreteAuto(string modello)
    {
        Modello = modello;
    }
    public void Avvia()
    {
        Console.WriteLine($"Avvio dell'auto {Modello}.");
    }

    public void MostraTipo()
    {
        Console.WriteLine($"Tipo: Auto | Modello: {Modello}");
    }
}

// Classe concreta che rappresenta una moto
public class ConcreteMoto : IVeicolo
{
    public string Modello { get;  set; }
    public ConcreteMoto(string modello)
    {
        Modello = modello;
    }
    public void Avvia()
    {
        Console.WriteLine($"Avvio della moto {Modello}.");
    }

    public void MostraTipo()
    {
        Console.WriteLine($"Tipo: Moto | Modello: {Modello}");
    }
}

// Classe concreta che rappresenta un camion
public class ConcreteCamion : IVeicolo
{
    public string Modello { get;  set; }
    public ConcreteCamion(string modello)
    {
        Modello = modello;
    }
    public void Avvia()
    {
        Console.WriteLine($"Avvio del camion {Modello}.");
    }

    public void MostraTipo()
    {
        Console.WriteLine($"Tipo: Camion | Modello: {Modello}");
    }
}

// Classe astratta che funge da Factory per creare veicoli
public abstract class VeicoloFactory
{
    // Metodo statico che crea un veicolo in base al tipo richiesto
    public static IVeicolo CreaVeicolo(string tipo, string modello)
    {
        switch (tipo)
        {
            case "auto":
                return new ConcreteAuto(modello); // Ritorna un oggetto ConcreteAuto
            case "moto":
                return new ConcreteMoto(modello); // Ritorna un oggetto ConcreteMoto
            case "camion":
                return new ConcreteCamion(modello); // Ritorna un oggetto ConcreteCamion
            default:
                throw new ArgumentException("Tipo di veicolo non valido. Usa 'auto', 'moto' o 'camion'.");
        }
    }
}

public sealed class RegistroVeicoli
{
    private static RegistroVeicoli istanza;
    internal List<IVeicolo> veicoliCreati;

    private RegistroVeicoli()
    {
        veicoliCreati = new List<IVeicolo>();

    }

    public static RegistroVeicoli Instanza
    {
        get
        {
            if (istanza == null)
                istanza = new RegistroVeicoli();
            return istanza;
        }
    }

    public void Registra(IVeicolo veicolo)
    {
        veicoliCreati.Add(veicolo);
    }
    public void StampaTutti()
    {
        Console.WriteLine("Ecco tutti i veicoli creati:");
        foreach (var veicolo in veicoliCreati)
        {
            veicolo.MostraTipo();
        }
    }
    public void AvviaVeicoli()
    {
        Console.WriteLine("Avvio dei veicoli:");
        foreach (var veicolo in veicoliCreati)
        {
            
            veicolo.Avvia();
        }
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        List<IVeicolo> veicoli = new List<IVeicolo>();
        bool esci = false;
        
        // ciclo principale del menù
        while (!esci)
        {
            Console.WriteLine("\n-- Menù --");
            Console.WriteLine("1. Aggiungi un auto");
            Console.WriteLine("2. Aggiungi una moto ");
            Console.WriteLine("3. Aggiungi un camion ");
            Console.WriteLine("4. Mostra tutti i veicoli");
            Console.WriteLine("5. Accendi tutti i veicoli");
            Console.WriteLine("6. Esci");
            string scelta = Console.ReadLine();
        
            switch (scelta)
            {
                case "1":
                        Console.WriteLine("Inserisci il modello dell'auto:");
                        string modelloAuto = Console.ReadLine();
                        IVeicolo auto = VeicoloFactory.CreaVeicolo("auto", modelloAuto);
                        RegistroVeicoli.Instanza.Registra(auto);
                        veicoli.Add(auto);
                        Console.WriteLine("Auto aggiunta");
                    break;
        
                case "2":
                    Console.WriteLine("Inserisci il modello della moto:");
                    string modelloMoto = Console.ReadLine();
                    IVeicolo moto = VeicoloFactory.CreaVeicolo("moto", modelloMoto);
                    RegistroVeicoli.Instanza.Registra(moto);
                    veicoli.Add(moto);
                    Console.WriteLine("Moto aggiunta");
                    
                    break;
        
                case "3":
                    Console.WriteLine("Inserisci il modello del camion:");
                    string modelloCamion = Console.ReadLine();
                    IVeicolo camion = VeicoloFactory.CreaVeicolo("camion", modelloCamion);
                    RegistroVeicoli.Instanza.Registra(camion);
                    veicoli.Add(camion);
                    Console.WriteLine("Camion aggiunto");
                    
                    break;
        
                case "4":
                    Console.WriteLine("Ecco tutti i veicoli:");
                    RegistroVeicoli.Instanza.StampaTutti();
                    
                    break;
        
                case "5":
                    Console.WriteLine("Avvio di tutti i veicoli:");
                    RegistroVeicoli.Instanza.AvviaVeicoli();
                    
                    break;
                case "6":
                    Console.WriteLine("Arrivederci");
                    esci = true;
                    break;
        
                default:
                    Console.WriteLine("Errore, scelta non valida");
                    break;
            }
        }
    }
}