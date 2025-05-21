using System;

public class Veicolo
{
    public string modelloV;
    public string marcaV;


    public Veicolo(string modello, string marca)
    {
        modelloV = modello;
        marcaV = marca;
    }

       public virtual string toString()
    {
        return $"La marca è: {marcaV}, il modello è {modelloV}";
    }
}

public class Auto : Veicolo
{
    public int numeroPorte;

    public Auto(string modello, string marca, int numPorte) : base(modello, marca)
    {
        numeroPorte = numPorte;
    }

    public override string toString()
    {
        return $"Il modello dell'auto {marcaV} è {modelloV}, ha {numeroPorte} porte";
    }
}
public class Moto : Veicolo
{
    public string tipoManubrio;

    public Moto(string modello, string marca, string manubrio) : base(modello, marca)
    {
        tipoManubrio = manubrio;
    }

    public override string toString()
    {
        return $"Il modello della moto {marcaV} è {modelloV}, ha un manubrio stile {tipoManubrio}";
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        List<Veicolo> garage = new List<Veicolo>();

        bool continua = true;

        while (continua)
        {
            Console.WriteLine("Scegli una tra le 3 opzioni");
            Console.WriteLine("[1] Inserisci una moto \n[2] Inserisci un'auto \n[3] Visualizza i veicoli del garage \n[4] Esci dal programma");
            int scelta = int.Parse(Console.ReadLine());

            switch (scelta)
            {
                case 1:

                Console.WriteLine("Inserisci la marca");
                string marcaMoto = Console.ReadLine();

                Console.WriteLine("Inserisci il modello");
                string modelloMoto = Console.ReadLine();

                Console.WriteLine("Inserisci lo stile del manubrio");
                string stileManubrio = Console.ReadLine();

                Moto nuovaMoto = new Moto(marcaMoto, modelloMoto, stileManubrio);
                garage.Add(nuovaMoto);
                break;

            case 2:

                Console.WriteLine("Inserisci la marca");
                string marcaAuto = Console.ReadLine();

                Console.WriteLine("Inserisci il modello");
                string modelloAuto = Console.ReadLine();

                Console.WriteLine("Inserisci il numero delle porte");
                int numPorte = int.Parse(Console.ReadLine());

                Auto nuovaAuto = new Auto(marcaAuto, modelloAuto, numPorte);

                garage.Add(nuovaAuto);

                break;


            case 3:

            Console.WriteLine("Ecco i veicoli presenti in garage");

                    foreach (Veicolo v in garage)
                    {
                        Console.WriteLine(v.ToString());
                    }
                    break;

            case 4:

                Console.WriteLine("Arrivederci");
                continua = false;
                break;

            default:
            
                Console.WriteLine("ERRORE");
                continua = false;
                break;
        }
    }
            
}

}

