using System;

// Interfaccia Observer: chi implementa questa interfaccia riceverà notifiche sulla creazione di utenti
public interface IObserver
{
    // Metodo chiamato quando viene creato un nuovo utente
    void NotificaCreazione(string nomeUtente);
}

// Interfaccia Soggetto: gestisce la registrazione, rimozione e notifica degli observer
public interface ISoggetto
{
    void Registra(IObserver o); // Registra un observer
    void Rimuovi(IObserver o);  // Rimuove un observer
    void Notifica(string nomeUtente); // Notifica tutti gli observer
}

// Classe che gestisce la creazione degli utenti e notifica gli observer registrati
public class GestoreCreazioneUtente : ISoggetto
{
    private readonly List<IObserver> listaO = new List<IObserver>(); // Lista degli observer registrati
    public void Registra(IObserver o)
    {
        listaO.Add(o); // Aggiunge un observer
    }
    public void Rimuovi(IObserver o)
    {
        listaO.Remove(o); // Rimuove un observer
    }
    public void Notifica(string nomeUtente)
    {
        // Notifica tutti gli observer della creazione di un nuovo utente
        foreach (var observer in listaO)
        {
            observer.NotificaCreazione(nomeUtente);
        }
    }
    public void CreaUtente(string nomeUtente)
    {
        // Crea un nuovo utente tramite la factory
        Utente utente = UserFactory.Crea(nomeUtente);
        Console.WriteLine($"Utente {utente.Nome} creato con successo.");
        Notifica(nomeUtente); // Notifica tutti gli observer
    }
}

// Factory per la creazione di oggetti Utente
public static class UserFactory
{
    public static Utente Crea(string nome)
    {
        return new Utente(nome);
    }
}

// Classe che rappresenta un utente
public class Utente
{
    public string Nome { get; set; }

    public Utente(string nome)
    {
        Nome = nome;
    }

    public override string ToString()
    {
        return $"Utente: {Nome}";
    }
}

// Observer che simula un modulo di log
public class ModuloLog : IObserver
{
    public void NotificaCreazione(string nomeUtente)
    {
        Console.WriteLine($"Log: Utente {nomeUtente} creato.");
    }
}

// Observer che simula un modulo di marketing
public class ModuloMarketing : IObserver
{
    public void NotificaCreazione(string nomeUtente)
    {
        Console.WriteLine($"Marketing: Utente {nomeUtente} registrato.");
    }
}

// Classe principale del programma
public class Program
{
    public static void Main(string[] args)
    {
        // Crea il gestore e i moduli observer
        GestoreCreazioneUtente gestore = new GestoreCreazioneUtente();
        ModuloLog log = new ModuloLog();
        ModuloMarketing marketing = new ModuloMarketing();

        // Registra i moduli observer al gestore
        gestore.Registra(log);
        gestore.Registra(marketing);

        bool continua = true;
        while (continua)
        {
            // Menu per l'utente
            Console.WriteLine(" Scegli una delle opzioni \n[1] Crea un nuovo utente \n[2] Esci");
            string? sceltaInput = Console.ReadLine(); // Può essere null
            string scelta = sceltaInput ?? ""; // Se null, usa stringa vuota

            switch (scelta)
            {
                case "1":
                    Console.Write("Inserisci il nome dell'utente: ");
                    string? nomeUtenteInput = Console.ReadLine(); // Può essere null
                    string nomeUtente = nomeUtenteInput ?? ""; // Se null, usa stringa vuota
                    gestore.CreaUtente(nomeUtente); // Crea utente e notifica gli observer
                    Console.WriteLine("Notifiche inviate agli observer.");
                    break;
                case "2":
                    continua = false; // Esce dal ciclo
                    break;
                default:
                    Console.WriteLine("Opzione non valida, riprova.");
                    break;
            }
        }
    }
}
