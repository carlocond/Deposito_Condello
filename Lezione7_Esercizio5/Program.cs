using System;

//creazione della classe macchina e del costruttore
public class Macchina
{
    public string motore;
    public int sospensioniMax;
    public float velocitaMax;
    public int nrModifiche;

    public Macchina(string nomMotore, int sospMax, float velocMax, int numMod)
    {
        motore = nomMotore;
        sospensioniMax = sospMax;
        velocitaMax = velocMax;
        nrModifiche = numMod;
    }
    //creazione del metodo tostring per poter stampare tutte le caratteristiche della macchina
    public override string ToString()
    {
        return $"Nome motore: {motore} \nSospensioni Max: {sospensioniMax}\n Velocità Max: {velocitaMax} \nNumero Modifiche: {nrModifiche}";
    }

}

//Creazione della classe utente e del costruttore
public class Utente
{

    public string nomeUtente;
    public int creditoUtente;

    public Utente(string nome, int credito)
    {
        nomeUtente = nome;
        creditoUtente = credito;
    }

}

//Creazione della classe program per poter inserire il funzionamento di tutto il programma
public class Program
{
    public static void Main(string[] args)
    {
        //Inserimento dei dati dell'utente
        Console.WriteLine("Inserisci il nome dell'utente");
        string nome = Console.ReadLine();

        Console.WriteLine("Quanti crediti hai?");
        int crediti = int.Parse(Console.ReadLine());

        //Creazione dell'oggetto 
        Utente utente1 = new Utente(nome, crediti);

        //Inizializzazione base delle variabili che determinano le caratteristiche della macchina
        int velocita = 0;
        int sospensioni = 0;
        int numModifiche = 0;
        string nomeMotore = " ";

        //Ciclo per scegliere quale operazione fare sulla macchina dell'utente
        for (int i = 0; i < utente1.creditoUtente; i++)
        {
            Console.WriteLine("Fai una scelta fra \n[1]Modifica sospensioni \n[2]Modifica velocità  \n[3]Nome motore");
            int scelta = int.Parse(Console.ReadLine());
            if (scelta == 1)
            {
                sospensioni += 10;
                numModifiche++;
                crediti--;
            }
            else if (scelta == 2)
            {
                velocita += 10;
                numModifiche++;
                crediti--;
            }
            else if (scelta == 3)
            {
                Console.WriteLine("Inserisci il nome del motore");
                nomeMotore = Console.ReadLine();
                numModifiche++;
                crediti--;
            }
            else
            {
                Console.WriteLine("Valore inserito errato");
                break;
            }

        }
        //Creazione e stampa dell'oggetto 
        Macchina macchina1 = new Macchina(nomeMotore, sospensioni, velocita, numModifiche);
        Console.WriteLine(macchina1);
    }
}