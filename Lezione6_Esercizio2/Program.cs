using System;

public class Persona
{
    public string Nome;
    public string Cognome;
    public int AnnoDiNascita;



    public Persona(string nome, string cognome, int anno) {
        Nome = nome;
        Cognome = cognome;
        AnnoDiNascita = anno;

    }
    public void StampaDati()
    {
        Console.WriteLine($"Nome: {Nome} \n Cognome: {Cognome} \n Anno di nascita: {AnnoDiNascita}");
    }
    public override string ToString()
    {
        return $"Nome: {Nome} Cognome: {Cognome} Anno di nascita {AnnoDiNascita} ";
    }

    public static void Main(string[] args)
    {
        string nome = "";
        string cognome = "";
        int anno = 0;
        int pers = 1;

        while (pers <= 3)
        {

            Console.WriteLine("Inserisci il nome della persona");
            nome = Console.ReadLine();
            Console.WriteLine("Inserisci il cognome della persona");
            cognome = Console.ReadLine();
            Console.WriteLine("Inserisci l'anno di nascita");
            anno = int.Parse(Console.ReadLine());

            if (pers == 1)
            {
                Persona persona1 = new Persona(nome, cognome, anno);
                persona1.StampaDati();
            }
            else if (pers == 2)
            {
                Persona persona2 = new Persona(nome, cognome, anno);
                persona2.StampaDati();
            }
            else
            {
                Persona persona3 = new Persona(nome, cognome, anno);
                Console.WriteLine(persona3);
            }
            pers++;


        }



    }
}
