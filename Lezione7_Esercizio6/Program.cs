using System;

public class Program
{
    public static void Main(string[] args)
    {
        //Dichiarazione della grandezza dell'array
        int numVoti = 5;

        //Dichiarazione dell'array
        int[] voti = new int[numVoti];

        //Inizio del ciclo per inserire i numeri
        for (int i = 0; i < numVoti; i++)
        {
            Console.WriteLine("Inserisci i voti");
            voti[i] = int.Parse(Console.ReadLine());
        }

        //Dichiarazione di variabili di riferimento

        int votoMax = voti[0];
        int votoMin = voti[0];
        int somma = 0;


        //Creazione del ciclo di controllo di ogni voto

        for (int i = 0; i < voti.Length; i++)
        {
            if (voti[i] > votoMax)
            {
                votoMax = voti[i];
            }
            else if (voti[i] < votoMin)
            {
                votoMin = voti[i];
            }
            somma += voti[i];
            
        }
        double media = somma / numVoti;
        //Stampa dei voti

        Console.WriteLine($"Il voto più alto è {votoMax}");
        Console.WriteLine($"Il voto più basso è {votoMin}");
        Console.WriteLine($"La media di tutti i voti è {media}");
    }
}
