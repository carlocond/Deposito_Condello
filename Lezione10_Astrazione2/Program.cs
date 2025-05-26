public abstract class DispositivoElettronico
{
    private string modello;
    public string Modello
    {
        get { return modello; }
        set { modello = value; }
    }
    public DispositivoElettronico(string modello)
    {
        Modello = modello;
    }

    public abstract void Accendi();

    public abstract void Spegni();

    public virtual void MostraInfo()
    {
        Console.WriteLine($"Modello: {Modello}");
    }
}

public class Computer : DispositivoElettronico
{
    public Computer(string modello) : base(modello) { }
    public override void Accendi()
    {
        Console.WriteLine("Il computer si avvia");
    }
    public override void Spegni()
    {
        Console.WriteLine("Il computer si spegne");
    }
    public override void MostraInfo()
    {
        Console.WriteLine($"Il computer {Modello} monta una RTX 5090, sei pieno di soldi");
    }
}
public class Stampante : DispositivoElettronico
{
    public Stampante(string modello) : base(modello) { }
    public override void Accendi()
    {
        Console.WriteLine("La stampante si accende");
    }
    public override void Spegni()
    {
        Console.WriteLine("La stampante va in standby");
    }
    public override void MostraInfo()
    {
        Console.WriteLine($"La stampante {Modello} ha una velocità di stampa eccezionale");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        List<DispositivoElettronico> dispositivi = new List<DispositivoElettronico>();

        bool continua = true;

        while (continua)
        {
            Console.WriteLine("Scegli l'operazione da effettuare \n[1] Aggiungi un computer \n[2] Aggiungi una stampante \n[3] Accendi i dispositivi \n[4] Spegni i dispositivi \n[5] Mostra Informazioni \n[0] Esci ");
            int scelta = int.Parse(Console.ReadLine());

            switch (scelta)
            {
                case 1:
                    Console.WriteLine("Inserisci il modello del computer");
                    string modelloPC = Console.ReadLine();
                    dispositivi.Add(new Computer(modelloPC));
                    break;

                case 2:
                    Console.WriteLine("Inserisci il modello della stampante");
                    string modelloST = Console.ReadLine();
                    dispositivi.Add(new Stampante(modelloST));
                    break;

                case 3:
                    Console.WriteLine("Vuoi accendere i dispositivi? s o n");
                    string acc = Console.ReadLine();
                    if (acc == "s")
                    {
                        foreach (DispositivoElettronico de in dispositivi)
                        {
                            de.Accendi();
                        }

                    }
                    else if (acc == "n")
                    {
                        break;
                    }
                    break;

                case 4:
                    Console.WriteLine("Vuoi spegnere i dispositivi? s o n");
                    string spegni = Console.ReadLine();
                    if (spegni == "s")
                    {
                        foreach (DispositivoElettronico de in dispositivi)
                        {
                            de.Spegni();
                        }
                    }
                    else if (spegni == "n")
                    {
                        break;
                    }
                    break;

                case 5:
                    foreach (DispositivoElettronico de in dispositivi)
                    {
                        de.MostraInfo();
                    }
                    break;

                case 0:
                    Console.WriteLine("Arrivederci");
                    continua = false;
                    break;
            }
        }
    }
}
