using System;
using Microsoft.VisualBasic;


public class Operazioni
{

    //Metodo per sommare due numeri
    public int Somma(int a, int b)
    {
        int somma = a + b;
        return somma;
    }
        
    //Metodo per moltiplicare due numeri    
    public int Moltiplica(int a, int b)
    {
        int prodotto = a * b;
        return prodotto;
    }


    // Metodo per stampare il risultato dell'operazione
    public void StampaRisultato(string operazione, int risultato)
    {
        Console.WriteLine($"Il risultato della {operazione} è: {risultato}.");

    }

    public static void Main(string[] args)
    {
        Operazioni op = new Operazioni();

        Console.WriteLine("Inserisci il primo numero"); // Creo un oggetto della classe Operazioni
        int a = int.Parse(Console.ReadLine());

        Console.WriteLine("Inserisci il secondo numero");
        int b = int.Parse(Console.ReadLine());

        Console.WriteLine("Quale operazione vuoi effettuare? Somma(s) o Moltiplicazione(m)");
        string risposta = Console.ReadLine();

        switch (risposta.ToLower()) // per accettare anche lettere maiuscole
        {
            case "s":
                Console.WriteLine(b);
                int somma = op.Somma(a, b);
                op.StampaRisultato("Somma ", somma);
                break;

            case "m":
                int prodotto = op.Moltiplica(a, b);
                op.StampaRisultato("Moltiplicazione ", prodotto);
                break;

            default:
                Console.WriteLine("Hai inserito un valore non valido, Scegli tra Somma e Moltiplicazione");
                break;
        }
       
    
    }
}
