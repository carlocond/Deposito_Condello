using System;

//Creazione della classe principale
public class Veicolo
{
    public string modelloV;
    public string marcaV;

//Costruttore della classe
    public Veicolo(string modello, string marca)
    {
        modelloV = modello;
        marcaV = marca;
    }

//Creazione del metodo di stampa delle informazioni
    public virtual string toString()
    {
        return $"La marca è: {marcaV}, il modello è {modelloV}";
    }
}

//Creazione della prima classe ereditaria
public class Auto : Veicolo
{
    //Aggiunta di un'altra variabile non ereditata
    public int numeroPorte;

    public Auto(string modello, string marca, int numPorte) : base(modello, marca)
    {
        numeroPorte = numPorte;
    }

    //Override del metodo di stampa in base al veicolo specifico
    public override string toString()
    {
        return $"Il modello dell'auto {marcaV} è {modelloV}, ha {numeroPorte} porte";
    }
}
//Creazione della seconda classe ereditaria
public class Moto : Veicolo
{
    //Aggiunta di un'altra variabile non ereditata
    public string tipoManubrio;

    public Moto(string modello, string marca, string manubrio) : base(modello, marca)
    {
        tipoManubrio = manubrio;
    }

//Override del metodo di stampa in base al veicolo specifico
    public override string toString()
    {
        return $"Il modello della moto {marcaV} è {modelloV}, ha un manubrio stile {tipoManubrio}";
    }
}

//Creazione della classe del programma
public class Program
{
    public static void Main(string[] args)
    {
        List<Veicolo> garage = new List<Veicolo>();

        bool continua = true;

//Creazione del ciclo del menù di scelta
        while (continua)
        {
            Console.WriteLine("Scegli una tra le 3 opzioni");
            Console.WriteLine("[1] Inserisci una moto \n[2] Inserisci un'auto \n[3] Visualizza i veicoli del garage \n[4] Esci dal programma");
            int scelta = int.Parse(Console.ReadLine());

            switch (scelta)
            {
                case 1:
//Inizializzazione variabili della moto
                    Console.WriteLine("Inserisci la marca");
                    string marcaMoto = Console.ReadLine();

                    Console.WriteLine("Inserisci il modello");
                    string modelloMoto = Console.ReadLine();

                    Console.WriteLine("Inserisci lo stile del manubrio");
                    string stileManubrio = Console.ReadLine();

//Creazione oggetto e aggiunta alla lista
                    Moto nuovaMoto = new Moto(marcaMoto, modelloMoto, stileManubrio);
                    garage.Add(nuovaMoto);
                    break;

                case 2:
//Inizializzazione delle variabili dell'auto
                    Console.WriteLine("Inserisci la marca");
                    string marcaAuto = Console.ReadLine();

                    Console.WriteLine("Inserisci il modello");
                    string modelloAuto = Console.ReadLine();

                    Console.WriteLine("Inserisci il numero delle porte");
                    int numPorte = int.Parse(Console.ReadLine());

//Creazione oggetto e aggiunta alla lista
                    Auto nuovaAuto = new Auto(marcaAuto, modelloAuto, numPorte);
                    garage.Add(nuovaAuto);

                    break;


                case 3:
//Visualizzazione di ogni veicolo presente nel garage
                    Console.WriteLine("Ecco i veicoli presenti in garage");

                    foreach (Veicolo v in garage)
                    {
                        Console.WriteLine(v.ToString());
                    }
                    break;

                case 4:
//Chiusura del programma
                    Console.WriteLine("Arrivederci");
                    continua = false;
                    break;

                default:
//Chiusura forzata del programma
                    Console.WriteLine("ERRORE");
                    continua = false;
                    break;
            }
        }

    }

}

