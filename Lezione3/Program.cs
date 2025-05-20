using System;
using System.Net.Http.Headers;
using Microsoft.VisualBasic;



public class Program()
{



    static void Main(string[] args)
    {

        //PrimoEsercizio();
        //SecondoEsercizio();
        //TerzoEsercizio();

        //QuartoEsercizio();
        //QuintoEsercizio();
        //SestoEsercizio();
        //SettimoEsercizio();
        //OttavoEsercizio();

    }
    static void PrimoEsercizio()
    {

        Console.WriteLine("Inserisci un numero intero");
        int numero = int.Parse(Console.ReadLine());

        Console.WriteLine("Risultato della tabellina");

        for (int i = 0; i < 11; i++)
        {
            Console.WriteLine(numero * i);
        }


    }

    static void SecondoEsercizio()
    {

        double somma = 0;

        Console.WriteLine("Quanti numeri interi vuoi inserire?");
        double numero = int.Parse(Console.ReadLine());

        Console.WriteLine($"Inserisci {numero} numeri");

        for (int i = 0; i < numero; i++)
        {
            double numeri = int.Parse(Console.ReadLine());

            somma += numeri;
        }
        double media = somma / numero;

        Console.WriteLine($"La media dei numeri inseriti è {media}");
    }

    static void TerzoEsercizio()
    {

        int fattoriale = 1;

        Console.WriteLine("Scegli un numero");
        int numero = int.Parse(Console.ReadLine());

        if (numero > 0)
        {

            for (int i = 1; i <= numero; i++)
            {

                fattoriale *= i;
            }
            Console.WriteLine($"Il risultato del fattoriale è {fattoriale}");

        }
        else
        {

            Console.WriteLine("Errore");

        }


    }

    static void QuartoEsercizio(){

        int conteggio = 0;

        Console.WriteLine("Inserisci una frase");
        string frase = Console.ReadLine();

        foreach (char cifre in frase){

            if (char.IsDigit(cifre)){
                conteggio++;
            }
        }

        Console.WriteLine($"Le cifre presenti nella frase sono {conteggio}");
        
    }

    static void QuintoEsercizio()
    {

        Console.WriteLine("Inserisci una frase");

        string frase = Console.ReadLine();

            string nuovaFrase = frase.Replace(" ", "");

        Console.WriteLine(nuovaFrase);

    }

    static void SestoEsercizio(){

        string vocali = "aeiou";
        int conteggio = 0;

        Console.WriteLine("Inserisci una stringa");
        string stringa = Console.ReadLine().ToLower();

        foreach(char c in stringa){
            if (vocali.Contains(c)){
                conteggio++;
            }
            
        }
        Console.WriteLine($"Il numero delle vocali contenute nella stringa è {conteggio}");

    }

    static void SettimoEsercizio()
    {

        bool maiuscola = false;
        bool cifra = false;
        bool sbagliata = true;



        Console.WriteLine("Inserisci una password, che soddisfi i requisiti");
        Console.WriteLine("Almeno una lettera maiuscola\nAlmeno una cifra\nAlmeno 8 caratteri\nNon deve iniziare o finire con uno spazio");


        do
        {

            string passwordInserita = Console.ReadLine();

            if (passwordInserita.Length <= 8 || passwordInserita.StartsWith(" ") || passwordInserita.EndsWith(" "))
            {
                Console.WriteLine("La password non è valida");
                continue;
            }

            foreach (char c in passwordInserita)
            {

                if (char.IsUpper(c))
                {
                    maiuscola = true;
                    continue;

                }
                else if (char.IsDigit(c))
                {
                    cifra = true;
                    continue;
                }

            }
            if (maiuscola && cifra)
            {
                sbagliata = false;

            }
            else
            {
                Console.WriteLine("La password non è corretta");
                Console.WriteLine("Riprova con un'altra");
            }

        } while (sbagliata);

        Console.WriteLine("La password è corretta");
    }

    static void OttavoEsercizio(){
        int numParole = 0;
        int numCaratteri = 0;
        int numSpazi = 0;
        int numPunti = 0;



        Console.WriteLine("Inserisci una stringa");
        string stringa = Console.ReadLine();

        foreach (char c in stringa){
            if (char.IsLetter(c)){
                numCaratteri++;
            } else if(char.IsWhiteSpace(c)){
                numSpazi++;
            } else if(char.IsPunctuation(c)){
                numPunti++;
            }
        }

        numParole = stringa.Split(' ').Length;

        Console.WriteLine($"Numero Parole: {numParole}");
        Console.WriteLine($"Numero Caratteri: {numCaratteri}");
        Console.WriteLine($"Numero Spazi: {numSpazi}");
        Console.WriteLine($"Numero Punti: {numPunti}");

    }
}



