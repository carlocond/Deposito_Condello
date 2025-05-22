using System;

public class PrenotazioneViaggio
{
    private int postiPrenotati = 0;
    private const int maxPosti = 0;

    public string Destinazione { get; set; }

    public int PostiPrenotati
    {
        get { return postiPrenotati; }
    }

    public int PostiDisponibili
    {
        get { return maxPosti - postiPrenotati; }
    }

    public void PrenotaPosti(int numero)
    {
        if (numero <= 0)
        {
            Console.WriteLine("Numero inserito non valido");
        }
        else if (numero <= PostiDisponibili)
        {
            postiPrenotati += numero;
            Console.WriteLine($"{numero} posti prenotati con successo");
        }
        else
        {
            Console.WriteLine("Posti insufficienti");
        }
    }

    public void AnnullaPrenotazione(int numero)
    {
        if (numero <= 0)
        {
            Console.WriteLine("Numero inserito non valido");
        }
        else if (numero <= PostiPrenotati)
        {
            postiPrenotati -= numero;
            Console.WriteLine($"{numero} prenotazioni sono state annullate");
        }
        else
        {
            Console.WriteLine("Non puoi annullare più posti di quelli prenotati");
        }
    }

    public string toString()
    {
        return $"Destinazione: {Destinazione} \nPosti Prenotati: {PostiPrenotati} \nPosti Disponibili: {PostiDisponibili}";
    }

}

public class Program
{
    public static void Main(string[] args)
    {
        List<string> Viaggi = new List<string>();
    }
}
