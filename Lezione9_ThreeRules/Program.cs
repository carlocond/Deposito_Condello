using System;

public class Operatore
{
    private string nome;
    private string turno;

    public string Nome
    {
        get { return nome; }
        set { nome = value; }
    }
    public string Turno
    {
        get { return turno; }
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

    public virtual void EseguiCompito()
    {
        Console.WriteLine($"Nome operatore:{Nome} \nIn servizio nel turno di {Turno}, Compito generico");
    }
}

public class OperatoreEmergenza : Operatore
{
    private int livelloUrgenza;
    public int LivelloUrgenza
    {
        get { return livelloUrgenza; }
        set {
            if (value >= 1 || value <= 5)
            {
                livelloUrgenza = value;
            }
            else
            {
                Console.WriteLine("Il livello d'urgenza deve essere specificato tra 1 e 5");
            }
        ;}
    }
    public override void EseguiCompito()
    {
        Console.WriteLine($"Nome operatore: {Nome} \nGestione di urgenza di livello: {LivelloUrgenza}");
    }
}

public class OperatoreSicurezza : Operatore
{

    private string areaSorvegliata;
    public string AreaSorvegliata
    {
        get { return areaSorvegliata; }
        set { areaSorvegliata = value; }
    }

    public override void EseguiCompito()
    {
        Console.WriteLine($"Nome operatore: {Nome} \nSorveglianza dell'area: {areaSorvegliata}");
    }
}

public class OperatoreLogistica : Operatore
{
    private int numeroConsegne;
    public int NumeroConsegne
    {
        get { return numeroConsegne; }
        set
        {
            if (value >= 0)
            {
                numeroConsegne = value;
            }
            else
            {
                Console.WriteLine("Il numero delle consegne non è valido");
            }
        }
    }
    public override void EseguiCompito()
    {
        Console.WriteLine($"Nome operatore {Nome} \n Compito: Coordinamento di {numeroConsegne} consegne");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        bool continua = true;

        List<Operatore> operatori = new List<Operatore>();

        while (continua)
        {
            Console.WriteLine("Scegli una delle 5 opzioni \n[1] Inserisci Operatore d'Emergenza \n[2] Inserisci Operatore di Sicurezza \n[3] Inserisci Operatore di Logistica \n[4] Visualizza tutti \n[5] Esci dal programma");
            int scelta = int.Parse(Console.ReadLine());

            switch (scelta)
            {
                case 1:
                    OperatoreEmergenza oe = new OperatoreEmergenza();

                    Console.WriteLine("Inserisci il nome dell'operatore d'emergenza");
                    oe.Nome = Console.ReadLine();

                    Console.WriteLine("Inserisci il turno dell'operatore");
                    oe.Turno = Console.ReadLine();

                    Console.WriteLine("Inserisci il livello d'urgenza");
                    oe.LivelloUrgenza = int.Parse(Console.ReadLine());

                    operatori.Add(oe);
                    break;
                case 2:
                    OperatoreSicurezza os = new OperatoreSicurezza();

                    Console.WriteLine("Inserisci il nome dell'operatore di sicurezza");
                    os.Nome = Console.ReadLine();

                    Console.WriteLine("Inserisci il turno dell'operatore");
                    os.Turno = Console.ReadLine();

                    Console.WriteLine("Inserisci l'area da sorvegliare");
                    os.AreaSorvegliata = Console.ReadLine();

                    operatori.Add(os);
                    break;
                    
                case 3:
                    OperatoreLogistica ol = new OperatoreLogistica();

                    Console.WriteLine("Inserisci il nome dell'operatore di logistica");
                    ol.Nome = Console.ReadLine();

                    Console.WriteLine("Inserisci il turno dell'operatore");
                    ol.Turno = Console.ReadLine();

                    Console.WriteLine("Inserisci il livello d'urgenza");
                    ol.NumeroConsegne = int.Parse(Console.ReadLine());

                    operatori.Add(ol);
                    break;
                    
                case 4:
                    Console.WriteLine("Visualizzazione degli operatori");
                    foreach (Operatore o in operatori)
                    {
                        Console.WriteLine();
                        o.EseguiCompito();
                        Console.WriteLine();
                    }
                    break;
                case 5:
                    Console.WriteLine("Arrivederci campione");
                    continua = false;
                    break;
                default:
                    Console.WriteLine("Errore, hai inserito un'opzione non valida. Riprova!");
                    break;
                

            }
        }
    }
}
