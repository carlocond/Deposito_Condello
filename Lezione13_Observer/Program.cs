using System;

//Observer: interfaccia che definisce il metodo di notifica
public interface IObserver
{
    void Update(int newState);
}

//Subject: interfaccia che permette di aggiungere/rimuovere observer e notificare
public interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify();
}

//ConcreteSubject: implementa l'interfaccia ISubject e mantiene lo stato osservato
public class ConcreteSubject : ISubject
{
    private readonly List<IObserver> _observers = new List<IObserver>();
    private int _state;

    // Proprietà che rappresenta lo stato del soggetto
    // e notifica gli osservatori quando cambia
    public int State
    {
        get => _state;
        set
        {
            _state = value;
            Notify();
        }
    }

    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in _observers)
        {
            observer.Update(_state);
        }
    }
}
//ConcreteObserver: implementa la logia di reazione alla notifica
public class ConcreteObserver : IObserver
{
    private readonly string _name;
    private int _observerState;

    public ConcreteObserver(string name)
    {
        _name = name;
    }

    //Viene chiamato dal Subject con il nuovo stato
    public void Update(int newState)
    {
        _observerState = newState;
        Console.WriteLine($"Osservatore {_name} ha ricevuto la notifica: nuovo stato = {_observerState}");
    }
}

//Client: crea il subject e alcuni observer e modella i cambi di stato
public class Program
{
    public static void Main(string[] args)
    {
        // Crea il soggetto
        var subject = new ConcreteSubject();

        // Crea alcuni observer
        var observer1 = new ConcreteObserver("Osservatore 1");
        var observer2 = new ConcreteObserver("Osservatore 2");

        // Registrazione degli observer
        subject.Attach(observer1);
        subject.Attach(observer2);

        // Modifica lo stato innesca Notify() e chiama Update() su tutti gli altri observer
        subject.State = 5;
        subject.State = 10;

        // Rimuovi un osservatore e modifica nuovamente lo stato solo Observer2 riceverà la notifica
        subject.Detach(observer1);

        subject.State = 15;
    }
}