using System;

public sealed class Singleton
{
    //Riferimento all'unica istanza (inizialmente null)
    private static Singleton _instance;

    //Oggetto di lock per garantire il thread-safety
    private static readonly object _lock = new object();

    //Costruttore privato: impedisce 'new Singleton()' da fuori
    private Singleton()
    {
        // Inizializzazione dell'istanza
    }

    //Punto di accessso globale all'istanza 
    public static Singleton Instance
    {
        get
        {
            //Primo controllo senza lock per migliorare le prestazioni
            if (_instance == null)
            {
                // Se due thread accedono, uno atterra nel lock
                lock (_lock)
                {
                    if (_instance == null) // Secondo controllo per evitare creazioni multiple
                    {
                        _instance = new Singleton();
                    }
                }
            }
            return _instance;
        }
    }

    //Metodo d'esempio che utilizza l'istanza Singleton
    public void DoSomething()
    {
        // Logica del metodo
        Console.WriteLine("Metodo DoSomething chiamato sull'istanza Singleton.");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Ottenere l'istanza Singleton
        Singleton st = Singleton.Instance;

        // Chiamare un metodo sull'istanza Singleton
        st.DoSomething();

        // Dimostrare che la stessa istanza è utilizzata
        Singleton a = Singleton.Instance;
        Console.WriteLine($"Stessa istanza: {ReferenceEquals(st, a)}");
    }
}
