using System;

//Creazione della classe base
public class Dipendente
{
    //Dichiarazione attributi
    private string nome;
    public string Nome
    {
        get { return nome; }
        set { nome = value; }
    }
    private int eta;
    public int Eta
    {
        get { return eta; }
        set
        {
            if (value >= 18)
            {
                eta = value;
            }
            else
            {
                Console.WriteLine("Età non consentita");
            }
        }
    }
    public Dipendente(string nome, int eta)
    {
        Nome = nome;
        Eta = eta;
    }
    //Metodo di stampa basico che verrà sovrascritto dalle derivate
    public virtual void EseguiCompito()
    {
        Console.WriteLine("Compito generico del dipendente");
    }

    //Metodo di stampa basico che verrà sovrascritto dalle derivate
    public virtual void StampaInfo()
    {
        Console.Write($"Nome: {Nome}, età: {Eta}");
    }
}
//Creazione classe derivata
public class Autista : Dipendente
{
    //Campo aggiuntivo della classe
    private string patente;
    public string Patente
    {
        get { return patente; }
        set { patente = value; }
    }
    //Costruttore che dichiara i valori della derivata
    public Autista(string nome, int eta, string patente) : base(nome, eta)
    {
        Patente = patente;
    }
    //Sovrascrittura del metodo di stampa specifico per la classe derivata
    public override void EseguiCompito()
    {
        Console.WriteLine($"{Nome} sta guidando il veicolo con la patente {Patente}");
    }
    //Sovrascrittura del metodo stampa informazioni
    public override void StampaInfo()
    {
        Console.Write($"Nome: {Nome}| Età: {Eta} | Patente {Patente} \n");
    }
}

//Creazione seconda classe derivata
public class Meccanico : Dipendente
{
    //Campo aggiuntivo della classe
    private string specializzazione;
    public string Specializzazione
    {
        get { return specializzazione; }
        set { specializzazione = value; }
    }
    //Costruttore che dichiara i valori della derivata
    public Meccanico(string nome, int eta, string specializzazione) : base(nome, eta)
    {
        Specializzazione = specializzazione;
    }

    //Sovrascrittura del metodo di stampa specifico per la classe derivata
    public override void EseguiCompito()
    {
        Console.WriteLine($"{Nome} ripara mezzi specializzati in {Specializzazione}.");
    }
    //Sovrascrittura del metodo stampa informazioni
    public override void StampaInfo()
    {
        Console.Write($"Nome: {Nome} | Età: {Eta} | Specializzazione: {Specializzazione} \n");
    }
}
//Creazione classe derivata
public class OperatoreCentrale : Dipendente
{
    //Campo aggiuntivo della classe
    private string turno;
    public string Turno
    {
        get { return turno; }
        //Controllo del valore stringa inserito durante la creazione dell'oggetto
        set
        {
            if (value == "giorno" || value == "notte")
            {
                turno = value;
            }
            else
            {
                Console.WriteLine("Il turno deve essere 'giorno' oppure 'notte'");
            }
        }
    }
    //Costruttore che dichiara i valori della derivata
    public OperatoreCentrale(string nome, int eta, string patente) : base(nome, eta)
    {
        Turno = turno;
    }
    //Sovrascrittura del metodo esegui compito
    public override void EseguiCompito()
    {
        Console.WriteLine($"Il turno {turno} viene coperto da {Nome}");
    }
    //Sovrascrittura del metodo stampa informazioni
    public override void StampaInfo()
    {
        Console.Write($"Nome: {Nome} | Età: {Eta} | Turno: {Turno} \n");
    }
}

//Creazione della classe principale
public class Program
{
    public static void Main(string[] args)
    {
        //Lista di dipendenti
        List<Dipendente> dipendenti = new List<Dipendente>();
        //Variabile booleana che permette l'utilizzo del menù
        bool continua = true;

        //Inizio del menù
        while (continua)
        {
            Console.WriteLine("Scegli una delle opzioni: \n[1] Aggiungi autista \n[2] Aggiungi meccanico \n[3] Aggiungi operatore centrale \n[4] Visualizza tutti i dipendenti \n[5] Visualizza compiti dipententi \n[0] Esci");

            int scelta = int.Parse(Console.ReadLine());

            switch (scelta)
            {
                //Creazione dell'autista e inserimento dati nella lista
                case 1:
                    Console.WriteLine("Inserisci il nome dell'autista");
                    string nome = Console.ReadLine();
                    Console.WriteLine("Inserisci l'età dell'autista");
                    int eta = int.Parse(Console.ReadLine());
                    Console.WriteLine("Inserisci la patente");
                    string patente = Console.ReadLine();

                    dipendenti.Add(new Autista(nome, eta, patente));
                    break;
                //Creazione del meccanico e inserimento dati nella lista
                case 2:
                    Console.WriteLine("Inserisci il nome del meccanico");
                    nome = Console.ReadLine();
                    Console.WriteLine("Inserisci l'età del meccanico");
                    eta = int.Parse(Console.ReadLine());
                    Console.WriteLine("Inserisci la specializzazione");
                    string specializzazione = Console.ReadLine();

                    dipendenti.Add(new Meccanico(nome, eta, specializzazione));
                    break;
                //Creazione dell'operatore e inserimento dati nella lista
                case 3:
                    Console.WriteLine("Inserisci il nome dell'operatore");
                    nome = Console.ReadLine();
                    Console.WriteLine("Inserisci l'età dell'operatore");
                    eta = int.Parse(Console.ReadLine());
                    Console.WriteLine("Inserisci il turno");
                    string turno = Console.ReadLine();

                    dipendenti.Add(new OperatoreCentrale(nome, eta, turno));
                    break;
                case 4:
                    //Controllo di tutti i dipendenti presenti nella lista e stampa delle informazioni
                    foreach (Dipendente d in dipendenti)
                    {
                        d.StampaInfo();
                    }
                    break;
                case 5:
                    //Controllo di tutti i dipendenti presenti nella lista e stampa dei compiti eseguiti
                    foreach (Dipendente d in dipendenti)
                    {
                        d.EseguiCompito();
                    }
                    break;
                case 0:
                    //Chiusura del programma
                    Console.WriteLine("Arrivederci!");
                    continua = false;
                    break;
                default:
                    //Riavvio automatico del programma
                    Console.WriteLine("Opzione non valida");
                    break;
            }

        }
    }
}
