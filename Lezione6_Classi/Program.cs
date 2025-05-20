using System;

public class Cane    //Definizione della classe cane
{
    //Proprietà (campi)
    public string nome;
    public int eta;

    public void Abbaia()
    {
        Console.WriteLine(nome + " dice: Bau!");
    }

    public void Ringhia()
    {
        Console.WriteLine(nome + " non vuole essere toccato");
    }

    public void Accarezza()
    {
        Console.WriteLine("Stai accarezzando " + nome);
    }

    public void ScopriEta()
    {
        Console.WriteLine(nome + " ha " + eta + " anni");
    }

    public class Programma
    {
        public static void Main(string[] args)
        {
            //Creazione dell'oggetto
            Cane cane1 = new Cane();

            //Assegnazione dei valori delle proprietà

            cane1.nome = "Ciccio";
            cane1.eta = 3;

            //Chiamata di un metodo sull'oggetto

            cane1.Abbaia(); //Output: Ciccio dice: Bau!
            cane1.Ringhia();
            cane1.ScopriEta();


            Console.WriteLine("Inserisci 1 per accarezzarlo, 2 per andartene");
            int numScelta = int.Parse(Console.ReadLine());

            if (numScelta == 1)
            {
                cane1.Accarezza();
            }
            else
            {
                Console.WriteLine("Te ne sei andato");
            }


        }


    }
}