using System;
using System.Runtime.Versioning;

public class Veicolo
{
    private string marca;
    public string Marca
    {
        get { return marca; }
        set { marca = value; }
    }
    private string modello;
    public string Modello
    {
        get { return modello; }
        set { modello = value; }
    }
    private int annoImmatricolazione;
    public int AnnoImmatricolazione
    {
        get { return annoImmatricolazione; }
        set { annoImmatricolazione = value; }
    }

    public virtual void StampaInfo()
    {
        Console.WriteLine("Ciao Mirko");
    }
}

public class AutoAziendale : Veicolo
{
    private string targa;
    public string Targa
    {
        get { return targa; }
        set { targa = value; }
    }
    private bool usoPrivato;
    public bool UsoPrivato
    {
        get { return usoPrivato; }
        set { usoPrivato = value; }
    }

    public override void StampaInfo()
    {
        Console.WriteLine($"Il veicolo in utilizzo è una {Marca}, modello {Modello}, immatricolata nel {AnnoImmatricolazione}. La sua targa è {Targa}, Utilizzo privato : {UsoPrivato}");
    }
}

public class FurgoneAziendale : Veicolo
{
    private int capacitaCarico;
    public int CapacitaCarico
    {
        get { return capacitaCarico; }
        set { capacitaCarico = value; }
    }

    public override void StampaInfo()
    {
        Console.WriteLine($"Il veicolo utilizzato è una {Marca}, modello {Modello}, immatricolata nel {AnnoImmatricolazione}. La capacità carico è: {capacitaCarico}");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        List<Veicolo> garageAziendale = new List<Veicolo>();

        bool continua = true;

        while (continua)
        {
            Console.WriteLine("\n--- MENU GARAGE ---");
            Console.WriteLine("Scegli una delle opzioni \n[1]. Inserisci Auto \n[2].Inserisci Moto \n[3] Mostra tutti i veicoli \n[4] Esci");
            string scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                    AutoAziendale auto = new AutoAziendale();
                    Console.Write("Inserisci la marca: ");
                    auto.Marca = Console.ReadLine();
                    Console.Write("Inserisci il modello: ");
                    auto.Modello = Console.ReadLine();
                    Console.WriteLine("Inserisci l'anno di immatricolazione");
                    auto.AnnoImmatricolazione = int.Parse(Console.ReadLine());

                    Console.Write("Inserisci la targa: ");
                    auto.Targa = Console.ReadLine();
                    Console.WriteLine("E' di utilizzo privato? s o n");
                    string risposta = Console.ReadLine();

                    if (risposta == "s")
                    {
                        auto.UsoPrivato = true;
                    }
                    else if (risposta == "n")
                    {
                        auto.UsoPrivato = false;
                    }
                    else
                    {
                        Console.Write("Errore.");
                    }

                    garageAziendale.Add(auto);
                    break;

                case "2":
                    FurgoneAziendale furgone = new FurgoneAziendale();

                    Console.Write("Inserisci la marca: ");
                    furgone.Marca = Console.ReadLine();
                    Console.Write("Inserisci il modello: ");
                    furgone.Modello = Console.ReadLine();
                    Console.WriteLine("Inserisci l'anno di immatricolazione");
                    furgone.AnnoImmatricolazione = int.Parse(Console.ReadLine());

                    Console.Write("Inserisci il valore del carico: ");
                    furgone.CapacitaCarico = int.Parse(Console.ReadLine());

                    garageAziendale.Add(furgone);
                    break;

                case "3":
                    Console.WriteLine("\n--- VEICOLI IN GARAGE ---");
                    foreach (Veicolo v in garageAziendale)
                    {
                        Console.WriteLine();
                        v.StampaInfo(); // Polimorfismo
                        Console.WriteLine();
                    }
                    break;

                case "4":
                    Console.WriteLine("Ciao campione");
                    continua = false;
                    break;

                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
        }
    }
}