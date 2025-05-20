using System;

public class Persona
{
    public string Nome;
    public int Eta;

    //Costruttore con i parametri

    public Persona(string nome, int eta)
    {
        Nome = nome;
        Eta = eta;
    }

    public void Presentati()
    {
        Console.WriteLine($"Ciao! Ti chiami {Nome} e hai {Eta} anni");
    }

    public class Programma
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Come ti chiami?");
            string nome = Console.ReadLine();

            Console.WriteLine($"Ok {nome}, quanti anni hai?");
            int eta = int.Parse(Console.ReadLine());

            //Creazione dell'oggetto con costruttore
            Persona persona1 = new Persona(nome, eta);

            //Chiamata del metodo sull'oggetto
            persona1.Presentati();
        }
    }
}
