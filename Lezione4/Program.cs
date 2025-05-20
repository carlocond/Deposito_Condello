using System;
using System.Runtime.Intrinsics.Arm;
using Microsoft.VisualBasic;

public class Program()
{

    public static void Main(string[] args)
    {

        // Console.WriteLine($"Inserisci il tuo nome");
        // string nomeUtente = Console.ReadLine();

        // string saluto = StampaSaluto(nomeUtente);
        // Console.WriteLine(saluto);

        // //-----------------------------------------------------------------------------
        // Spazio();
        // //-----------------------------------------------------------------------------

        // Console.WriteLine("Inserisci un numero per verificare se è pari o dispari");
        // int numeroInserito = int.Parse(Console.ReadLine());

        // bool verifica = VerificaPari(numeroInserito);

        // //-----------------------------------------------------------------------------
        // Spazio();
        // //-----------------------------------------------------------------------------

        // Console.WriteLine("Inserisci un numero");
        // int numeroBase = int.Parse(Console.ReadLine());

        // Console.WriteLine("Inserisci un esponente");
        // int esponente = int.Parse(Console.ReadLine());

        // Console.WriteLine($"Il risultato è {CalcolaPontenza(numeroBase, esponente)}");

        // //-----------------------------------------------------------------------------
        // Spazio();
        // //-----------------------------------------------------------------------------

        // Console.WriteLine("Inserisci un numero per raddoppiarlo");
        // int numero = int.Parse(Console.ReadLine());
        // Console.WriteLine($"Il numero pre-raddoppio è  {numero}");
        // Raddoppia(ref numero);
        // Console.WriteLine($"Il numero post-raddoppio è {numero}");

        // //-----------------------------------------------------------------------------
        // Spazio();
        // //-----------------------------------------------------------------------------

        // Console.WriteLine("Inserisci il giorno");
        // int d = int.Parse(Console.ReadLine());
        // Console.WriteLine("Inserisci il mese");
        // int m = int.Parse(Console.ReadLine());
        // Console.WriteLine("Inserisci l'anno");
        // int y = int.Parse(Console.ReadLine());

        // AggiustaData(ref d, ref m, ref y);  
        // Console.WriteLine($"La nuova data è {d}/{m}/{y}");




        Console.WriteLine("Inserisci una parola per contare: Vocali, Consonanti, Spazi");
        string parola = Console.ReadLine();

        AnalizzaParola(parola, out int vocali, out int consonanti, out int spazi);

        Console.WriteLine($"Il numero delle vocali è {vocali}, delle consonanti è {consonanti}, e degli spazi è {spazi}");



    }

    static string StampaSaluto(string nome)
    {

        return $"Ciao {nome}";

    }

    static bool VerificaPari(int numero)
    {
        bool risultato = false;

        if (numero % 2 == 0)
        {
            Console.WriteLine("Il numero è pari");
            risultato = true;
        }
        else
        {
            Console.WriteLine("Il numero è dispari");
        }
        return risultato;

    }

    static int CalcolaPontenza(int baseNumero, int numEsponente)
    {
        int risEsponente = (int)Math.Pow(baseNumero, numEsponente);

        return risEsponente;
    }

    static void Spazio()
    {
        Console.WriteLine("");
        Console.WriteLine("");
    }

    static void Raddoppia(ref int valore)
    {
        valore *= 2;
    }

    static void AggiustaData(ref int giorno, ref int mese, ref int anno)
    {

        if (giorno > 30)
        {
            mese++;
            giorno = 1;
        }

        if (mese <= 12)
        {
            mese++;

        }

        if (mese > 12)
        {
            anno++;
            mese = 1;
        }

    }

    static void Dividi(int dividendo, int divisore, out int quoziente, out int resto){
        quoziente = dividendo / divisore;
        resto = dividendo % divisore;
    }

    static void AnalizzaParola(string parola, out int vocali, out int consonanti, out int spazi)
    {
        vocali = 0;
        consonanti = 0;
        spazi = 0;

        string cercaVocali = "aeiouAEIOU";
        string cercaCons = "B, C, D, F, G, H, L, M, N, P, Q, R, S, T, V ,Z, J, K , W, X, Y";

        foreach (char c in parola)
        {
            if (cercaVocali.Contains(c))
            {
                vocali++;
            }

            if (cercaCons.ToLower().Contains(char.ToLower(c)))
            {
                consonanti++;
            }

            if (char.IsWhiteSpace(c))
            {
                spazi++;
            }
        }
    }







}
