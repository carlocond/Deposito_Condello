using System;

public interface INewsAgency
{
    void News(string novità);
}

public interface INewsSubscriber
{
    void Registra(INewsAgency osservatore);
    void Rimuovi(INewsAgency osservatore);
    void Notifica(string messaggio);
}

public class NewsAgency : INewsSubscriber
{
    private readonly List<INewsAgency> _subscribers = new List<INewsAgency>();

    public void Registra(INewsAgency osservatore)
    {
        _subscribers.Add(osservatore);
    }

    public void Rimuovi(INewsAgency osservatore)
    {
        _subscribers.Remove(osservatore);
    }

    public void Notifica(string messaggio)
    {
        foreach (var subscriber in _subscribers)
        {
            subscriber.News(messaggio);
        }
    }

    public void AggiornaNews(string news)
    {
        Console.WriteLine($"Aggiornamento notizie: {news}");
        Notifica(news);
    }
}
public class MobileApp : INewsAgency
{
    public void News(string messaggio)
    {
        Console.WriteLine($"Notification on mobile: {messaggio}");
    }
}

public class EmailClient : INewsAgency
{

    public void News(string messaggio)
    {
        Console.WriteLine($"Email sent: {messaggio}");
    }
}

public sealed class Osservati
{
    private static Osservati _istanza;
    private readonly List<INewsAgency> _osservatori = new List<INewsAgency>();

    private Osservati() { }

    public static Osservati Istanza
    {
        get
        {
            if (_istanza == null)
                _istanza = new Osservati();
            return _istanza;
        }
    }

    public void Registra(INewsAgency osservatore)
    {
        _osservatori.Add(osservatore);
    }

    public void Rimuovi(INewsAgency osservatore)
    {
        _osservatori.Remove(osservatore);
    }

    public void Notifica(string messaggio)
    {
        foreach (var osservatore in _osservatori)
        {
            osservatore.News(messaggio);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        
    }
}
