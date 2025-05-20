using System;

public class Libro
{
    public string titolo;
    public string autore;
    public int annoPubblicazione;

    public override string ToString()
    {
        return $"Titolo del libro: {titolo}\nNome dell'autore: {autore}";
    }

    public override bool Equals(object? obj)
    {
        if (obj is Libro other)
        {
            return this.titolo == other.titolo && this.autore == other.autore && this.annoPubblicazione == other.annoPubblicazione;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(titolo, autore, annoPubblicazione);
    }


}
    public class Program
    {
    public static void Main(string[] args)
    {

        Libro libro1 = new Libro { titolo = "Come (non) diventare un programmatore", autore = "Carlo Condello", annoPubblicazione = 2025 };
        Libro libro2 = new Libro { titolo = "Come (non) diventare un programmatore", autore = "Carlo Condello", annoPubblicazione = 2025 };
        Libro libro3 = new Libro { titolo = "Marcia su Roma", autore = "Benito Mussolini", annoPubblicazione = 1922 };

        Console.WriteLine(libro1.GetHashCode());
        Console.WriteLine(libro2.GetHashCode());
        Console.WriteLine(libro3.GetHashCode());
        Console.WriteLine(libro1.Equals(libro2));
        Console.WriteLine(libro2.Equals(libro3));

        Console.WriteLine(libro1);
        Console.WriteLine(libro2);
        Console.WriteLine(libro3);

    }
}
