using System;

public class VoloAereo
{
    private int postiOccupati = 0;
    const int maxPosti = 150;

    public string CodiceVolo { get; set; }

    public int PostiOccupati
    {
        get { return postiOccupati; }
    }

    public int PostiLiberi
    {
        get { return maxPosti - postiOccupati; }
    }

    // Costruttore con codice volo e posti occupati iniziali
    public VoloAereo(string codice, int postiOcc)
    {
        CodiceVolo = codice;
        postiOccupati = postiOcc;
    }

    public void EffettuaPrenotazione(int numeroPosti)
    {
        if (numeroPosti <= 0)
        {
            Console.WriteLine("Numero non valido");
        }
        else if (numeroPosti <= PostiLiberi)
        {
            postiOccupati += numeroPosti;
            Console.WriteLine($"Prenotazione di {numeroPosti} posti effettuata.");
        }
        else
        {
            Console.WriteLine("Posti insufficienti");
        }
    }

    public void AnnullaPrenotazione(int numeroPosti)
    {
        if (numeroPosti <= 0)
        {
            Console.WriteLine("Numero non valido");
        }
        else if (numeroPosti <= postiOccupati)
        {
            postiOccupati -= numeroPosti;
            Console.WriteLine($"Annullamento di {numeroPosti} posti effettuato.");
        }
        else
        {
            Console.WriteLine("Impossibile annullare più posti di quelli occupati");
        }
    }

    public void VisualizzaStato()
    {
        Console.WriteLine($"Codice volo: {CodiceVolo}, Posti occupati: {PostiOccupati}, Posti liberi: {PostiLiberi}");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Inserisci il codice del volo:");
        string codice = Console.ReadLine();

        Console.WriteLine("Inserisci il numero iniziale di posti occupati:");
        int iniziali = int.Parse(Console.ReadLine());

        VoloAereo volo = new VoloAereo(codice, iniziali);

        bool continua = true;

        while (continua)
        {
            Console.WriteLine("\nScegli un'operazione:");
            Console.WriteLine("[1] Effettua una prenotazione");
            Console.WriteLine("[2] Annulla prenotazione");
            Console.WriteLine("[3] Visualizza lo stato del volo");
            Console.WriteLine("[4] Esci dal programma");

            int scelta = int.Parse(Console.ReadLine());

            switch (scelta)
            {
                case 1:
                    Console.WriteLine("Inserisci il numero di posti da prenotare:");
                    int prenota = int.Parse(Console.ReadLine());
                    volo.EffettuaPrenotazione(prenota);
                    break;

                case 2:
                    Console.WriteLine("Inserisci il numero di posti da annullare:");
                    int annulla = int.Parse(Console.ReadLine());
                    volo.AnnullaPrenotazione(annulla);
                    break;

                case 3:
                    volo.VisualizzaStato();
                    break;

                case 4:
                    Console.WriteLine("Uscita dal programma.");
                    continua = false;
                    break;

                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
        }
    }
}
