using System;

//Classe base
public class Veicolo
{
    //Proprietà targa con get e set auto implementati
    public string Targa { get; set; }

//Costruttore del veicolo
    public Veicolo(string targa)
    {
        Targa = targa;
    }
    //Metodo virtuale base che verrà sovrascritto dalle classi derivate
    public virtual void Ripara()
    {
        Console.WriteLine("Il veicolo viene controllato");
    }
}

//Classe derivata
public class Auto : Veicolo
{
    
    public Auto(string targa) : base(targa) { }

    public override void Ripara()
    {
        Console.WriteLine($"Auto con targa: {Targa} \nControllo olio, freni e motore dell'auto");
    }
}

public class Moto : Veicolo
{
    public Moto(string targa) : base(targa){}

    public override void Ripara()
    {
        Console.WriteLine($"Moto con targa: {Targa} \nControllo catena, freni e gomme della moto");
    }
}

public class Camion : Veicolo
{
    public Camion(string targa) : base(targa) { }

    public override void Ripara()
    {
        Console.WriteLine($"Camion con targa {Targa} \nControllo sospensioni, freni rinforzati e carico del camion");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        bool continua = true;

        List<Veicolo> veicoli = new List<Veicolo>();


        while (continua)
        {
            Console.WriteLine("Scegli una delle 5 opzioni \n[1] Inserisci l'auto \n[2] Inserisci la moto \n[3] Inserisci il camion \n[4] Ripara tutto \n[5] Esci dal programma");
            int scelta = int.Parse(Console.ReadLine());

            switch (scelta)
            {
                case 1:
                    Console.WriteLine("Inserisci la targa dell'auto");
                    string targaAuto = Console.ReadLine();
                    veicoli.Add(new Auto(targaAuto));
                    break;
                case 2:
                    Console.WriteLine("Inserisci la targa della moto");
                    string targaMoto = Console.ReadLine();
                    veicoli.Add(new Moto(targaMoto));
                    break;
                case 3:
                    Console.WriteLine("Inserisci la targa del camion");
                    string targaCamion = Console.ReadLine();
                    veicoli.Add(new Camion(targaCamion));
                    break;
                case 4:
                    Console.WriteLine("Riparazioni in corso...");
                    foreach (Veicolo v in veicoli)
                    {
                        Console.WriteLine();
                        v.Ripara();
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