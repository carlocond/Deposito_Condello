using System;
using System.Collections.Generic;

// Interfaccia Observer: chi riceve le news
public interface INewsObserver
{
    void Update(string message);
}

// Singleton Subject: gestisce la lista degli osservatori
public sealed class NewsAgency
{
    private static NewsAgency _instance;
    private readonly List<INewsObserver> _observers = new List<INewsObserver>();

    private NewsAgency() { }

    public static NewsAgency Instance
    {
        get
        {
            if (_instance == null)
                _instance = new NewsAgency();
            return _instance;
        }
    }

    public void Register(INewsObserver observer)
    {
        if(!_observers.Contains(observer))
            _observers.Add(observer);
    }

    public void Remove(INewsObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Notify(string message)
    {
        foreach (var observer in _observers)
        {
            observer.Update(message);
        }
    }

    public void PublishNews(string news)
    {
        Console.WriteLine($"[Agenzia] Pubblica: {news}");
        Notify(news);
    }
}

// Observer concreto: App Mobile
public class MobileApp : INewsObserver
{
    public void Update(string message)
    {
        Console.WriteLine($"[MobileApp] Notifica: {message}");
    }
}

// Observer concreto: Email
public class EmailClient : INewsObserver
{
    public void Update(string message)
    {
        Console.WriteLine($"[EmailClient] Email inviata: {message}");
    }
}

// Esempio di utilizzo
class Program
{
    static void Main(string[] args)
    {
        var mobile = new MobileApp();
        var email = new EmailClient();

        // Registra gli osservatori al Singleton
        NewsAgency.Instance.Register(mobile);
        NewsAgency.Instance.Register(email);

        // Simula pubblicazione di una notizia
        NewsAgency.Instance.PublishNews("Nuova breaking news!");

        // Rimuove un osservatore e pubblica di nuovo
        NewsAgency.Instance.Remove(email);
        NewsAgency.Instance.PublishNews("Aggiornamento in tempo reale!");

        // Output atteso:
        // [Agenzia] Pubblica: Nuova breaking news!
        // [MobileApp] Notifica: Nuova breaking news!
        // [EmailClient] Email inviata: Nuova breaking news!
        // [Agenzia] Pubblica: Aggiornamento in tempo reale!
        // [MobileApp] Notifica: Aggiornamento in tempo reale!
    }
}


/* 
Il tuo codice implementa sia l’Observer che il Singleton pattern, ma presenta alcune incongruenze:

Confusione tra interfacce: INewsAgency è sia “Publisher” che “Subscriber”, mentre nella semantica dell’Observer dovresti distinguere chi genera la notizia (Publisher/Subject) e chi la riceve (Observer).

La classe Osservati (Singleton) non è integrata col resto (non viene mai usata).

Non c’è un esempio funzionante nel Main.

Mancano i riferimenti ai namespace, tipo List<T>.

Redundant interfaces: INewsSubscriber dovrebbe essere l’oggetto osservato, non l’osservatore.

Incoerenza dei nomi: usi sia _subscribers che _osservatori e classi che fanno le stesse cose.


Observer: INewsObserver e le sue implementazioni (MobileApp, EmailClient) ricevono le news.

Singleton: NewsAgency ha costruttore privato e la proprietà statica Instance.

Gli observer si registrano via Register, si rimuovono via Remove.

Quando viene pubblicata una news, tutti gli osservatori registrati ricevono la notifica.

*/
