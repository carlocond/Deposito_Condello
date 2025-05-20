using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;

public class Program()
{



    public static void Main(string[] args)
    {
        //--------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------

        // int bonus = 50;


        // Console.WriteLine("Inserisci il Primo punteggio");
        // int punteggio1 = int.Parse(Console.ReadLine());

        // Console.WriteLine("Inserisci il Secondo punteggio");
        // int punteggio2 = int.Parse(Console.ReadLine());

        // Console.WriteLine("Inserisci il Terzo punteggio");
        // int punteggio3 = int.Parse(Console.ReadLine());

        // AggiornaPunteggio(ref punteggio1, ref punteggio2, ref punteggio3, out int punteggioTot, out int punteggioMedio, bonus);

        // Console.WriteLine($"Primo punteggio aggiornato: {punteggio1}");
        // Console.WriteLine($"Secondo punteggio aggiornato: {punteggio2}");
        // Console.WriteLine($"Terzo punteggio aggiornato: {punteggio3}");

        // Console.WriteLine($"Il totale dei punteggi è {punteggioTot}, mentre la media è {punteggioMedio}");

        //--------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------

        // Console.WriteLine("Inserisci il tuo nome");
        // string nome = Console.ReadLine();


        // Console.WriteLine("Inserisci il primo voto");
        // int voto1 = int.Parse(Console.ReadLine());


        // Console.WriteLine("Inserisci il secondo voto");
        // int voto2 = int.Parse(Console.ReadLine());



        // Console.Write($"Ciao {nome}, ");
        // ElaboraStudente(nome, ref voto1, ref voto2, out int media);

        //--------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------



        // Console.WriteLine(Somma(3, 4));
        // Console.WriteLine(Somma(10.10, 20.10));
        // Console.WriteLine(Somma(3, 4, 5));

        // Console.WriteLine(Analizza("ciao compare"));
        // Console.WriteLine(Analizza("Ciao compare", 'c'));
        // Console.WriteLine($"Il numero delle vocali è { Analizza("Ciao compare", true)} ");
        // Console.WriteLine($"Il numero delle consonanti è {Analizza("Ciao compare", false)} ");

        //--------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------

        //RichiestaNumeri();

        //Dividi();

        Somma();







    }

    static void AggiornaPunteggio(ref int punteggio1, ref int punteggio2, ref int punteggio3, out int punteggioTot, out int punteggioMedio, int bonus)
    {

        punteggio1 += bonus;

        punteggio2 += bonus;

        punteggio3 += bonus;


        punteggioTot = punteggio1 + punteggio2 + punteggio3;

        punteggioMedio = punteggioTot / 3;
    }

    static void ElaboraStudente(string nome, ref int voto1, ref int voto2, out int media)
    {

        media = voto1 + voto2 / 2;

        if (media > 6)
        {
            Console.WriteLine("sei stato promosso");
        }
        else
        {
            Console.WriteLine("sei stato bocciato, come Edoardo");
        }
    }

    static int Somma(int numero1, int numero2)
    {
        int somma = numero1 + numero2;

        return somma;
    }

    static double Somma(double numero11, double numero22)
    {
        double somma = numero11 + numero22;

        return somma;
    }

    static int Somma(int a, int b, int c)
    {
        int somma = a + b + c;

        return somma;
    }

    static int Analizza(string testo)
    {
        int numCaratteri = 0;

        foreach (char c in testo)
        {
            if (!char.IsWhiteSpace(c))
            {
                numCaratteri++;
            }
        }
        return numCaratteri;
    }

    static int Analizza(string testo, char carattere)
    {
        int contaCarattere = 0;

        foreach (char c in testo)
        {
            if (char.ToLower(c) == carattere)
            {
                contaCarattere++;
            }
        }
        return contaCarattere;
    }

    static int Analizza(string testo, bool contaVocali)
    {
        int numVocali = 0;
        int numConsonanti = 0;

        string vocali = "aeiou";

        foreach (char c in testo)
        {
            if (char.IsLetter(c))
            {
                if (vocali.Contains(char.ToLower(c)))
                {
                    numVocali++;
                }
                else
                {
                    numConsonanti++;
                }

            }

        }
        if (contaVocali == true)
        {
            return numVocali;
        }
        else
        {
            return numConsonanti;
        }

    }

    static void RichiestaNumeri()
    {
        int stringToNumero1 = 0;

        int stringToNumero2 = 0;

        try
        {
            Console.WriteLine("Inserisci il primo numero");
            stringToNumero1 = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Inserisci il secondo numero");
            stringToNumero2 = int.Parse(Console.ReadLine());

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Errore fai schifo {ex}");
        }
        finally
        {
            Console.WriteLine("Finalmente l'hai capito");
        }





    }

    static void Dividi()
    {
        
        int numero1 = 0;
        
        int numero2 = 0;

        try
        {
            Console.WriteLine("Inserisci il primo numero (sto carburando)");
            numero1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Inserisci il secondo numero (quasi arrivato)");
            numero2 = int.Parse(Console.ReadLine());

            int risultato = numero1 / numero2;
            Console.WriteLine($"Il risultato della divisione è {risultato} (mi sono acceso)");
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Non puoi dividere per 0! {ex} (fundia u muturi)");
        }
        finally
        {
            Console.WriteLine("bravo compare (partia)");
        }
    }

    static void Somma()
    {
        int numeroInserito = 0;
        int somma = 0;


        for (int i = 0; i < 5; i++)
        {
            try
            {
                Console.WriteLine("Inserisci un numero");
                numeroInserito = int.Parse(Console.ReadLine());

                somma += numeroInserito;

            }
            catch
            {
                Console.WriteLine("Non hai inserito un numero valido");
            }
        }
        Console.WriteLine($"La somma totale dei numeri inseriti è {somma}");


    }
}







