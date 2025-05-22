using System;
using System.Runtime.Intrinsics.Arm;

public class Soldato
{
    private string nomeS;
    private string gradoS;
    private int anniServizioS;

    public string Nome
    {
        get { return nomeS; }
        set { nomeS = value; }
    }
    public string Grado
    {
        get { return gradoS; }
        set { gradoS = value; }
    }
    public int AnniServizio
    {
        get { return anniServizioS; }
        set
        {
            if (value >= 0)
            {
                anniServizioS = value;
            }
            else
            {
                Console.WriteLine("Anni di servizio non validi");
            }
        }
    }
 

    public virtual void Descrizione()
    {
        Console.WriteLine($"Il nome del soldato è {Nome}, il grado è {Grado}, gli anni di servizio sono {AnniServizio}");
    }
}

public class Fante : Soldato
{
    private string arma;

    public string Arma
    {
        get { return arma; }
        set { arma = value; }
    }



    public override void Descrizione()
    {
        Console.WriteLine($"Il nome del soldato è  {Nome} il grado è {Grado}, gli anni di servizio sono {AnniServizio} e la sua arma è {Arma}");
    }
}

public class Artigliere : Soldato
{
    private int calibro;
    public int Calibro
    {
        get { return calibro; }
        set {
            if (value > 0)
            {
                calibro = value;
            }
            else
            {
                Console.WriteLine("Calibro non valido");
            }
        }
    }


    public override void Descrizione()
    {
        Console.WriteLine($"Il nome del soldato è {Nome}, il grado è {Grado}, gli anni di servizio sono {AnniServizio} e il suo calibro è {Calibro}");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        List<Soldato> esercito = new List<Soldato>();
        bool continua = true;

        while (continua)
        {
            Console.WriteLine("Scegli una delle 4 opzioni: [A] Aggiungi un fante \n[B] Aggiungi un artigliere \n[C] Visualizza tutti i soldati \n[D] Esci dal programma");
            string scelta = Console.ReadLine();

            switch (scelta)
            {
                case "A":
                    Fante f = new Fante();
                    Console.WriteLine("Inserisci il nome del fante");
                     f.Nome = Console.ReadLine();

                    Console.WriteLine("Inserisci il grado del fante");
                    f.Grado = Console.ReadLine();

                    Console.WriteLine("Inserisci gli anni di servizio");
                    f.AnniServizio = int.Parse(Console.ReadLine());

                    Console.WriteLine("Inserisci l'arma utilizzata");
                    f.Arma = Console.ReadLine();
                    esercito.Add(f);

                    break;
                case "B":
                    Artigliere a = new Artigliere();
                    Console.WriteLine("Inserisci il nome dell'artigliere");
                    a.Nome = Console.ReadLine();

                    Console.WriteLine("Inserisci il grado dell'artigliere");
                    a.Grado = Console.ReadLine();

                    Console.WriteLine("Inserisci gli anni di servizio");
                    a.AnniServizio = int.Parse(Console.ReadLine());

                    Console.WriteLine("Inserisci il valore del calibro (mm)");
                    a.Calibro = int.Parse(Console.ReadLine());
                    esercito.Add(a);
                    break;

                    
                case "C":
                    Console.WriteLine("Ecco i soldati presenti all'interno dell'esercito");
                    foreach (Soldato s in esercito)
                    {
                        s.Descrizione();
                    }
                    break;
                case "D":
                    Console.WriteLine("Arrivederci");
                    continua = false;
                    break;

                default:
                    Console.WriteLine("Errore scelta non valida");
                    break;
            }
        }
    }
}


