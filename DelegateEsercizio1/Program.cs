using System;

public delegate int Operazione(int a, int b);

class Program
{
    static int Somma(int a, int b)
    {
        return a + b;
    }

    static int Moltiplicazione(int a, int b)
    {
        return a * b;
    }

    static void Main()
    {
        bool esci = false;
        
        // ciclo principale del menù
        while (!esci)
        {
            Console.WriteLine("\n-- Menù --");
            Console.WriteLine("1. Fai una somma di due numeri ");
            Console.WriteLine("2. Fai una moltiplicazione di due numeri");
            Console.WriteLine("0. Esci dal programma");

            Console.Write("Scelta: ");
            string scelta = Console.ReadLine();
        
            switch (scelta)
            {
                case "1":
                Operazione operazione = Somma;
                    Console.Write("Inserisci il primo numero: ");
                    int a = int.Parse(Console.ReadLine());
                    Console.Write("Inserisci il secondo numero: ");
                    int b = int.Parse(Console.ReadLine());
                    int risultatoSomma = operazione(a, b);
                    Console.WriteLine($"Risultato della somma: {risultatoSomma}");
                    break;
        
                case "2":
                    operazione = Moltiplicazione;
                    Console.Write("Inserisci il primo numero: ");
                    a = int.Parse(Console.ReadLine());
                    Console.Write("Inserisci il secondo numero: ");
                    b = int.Parse(Console.ReadLine());
                    int risultatoMoltiplicazione = operazione(a, b);
                    Console.WriteLine($"Risultato della moltiplicazione: {risultatoMoltiplicazione}");
                    
                    break;
        
                case "0":
                    esci = true;
                    break;
        
                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
        }
    }
}
