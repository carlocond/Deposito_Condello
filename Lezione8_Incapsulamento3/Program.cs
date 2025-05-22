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
    public VoloAereo(int postiOcc)
    {
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
            Console.WriteLine($"Prenotazione di {numeroPosti} posti effettuata");
            postiOccupati += numeroPosti;
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
        else if (numeroPosti <= PostiOccupati)
        {
            Console.WriteLine($"Annullamento di {numeroPosti} posti effettuata");
            postiOccupati -= numeroPosti;
        }
        else
        {
            Console.WriteLine("Impossibile annullare più posti di quelli occupati");
        }
    }

    public void VisualizzaStato()
    {
        Console.WriteLine($"Il codice del volo è {CodiceVolo}, i posti occupati sono {PostiOccupati}, i posti liberi sono {PostiLiberi}");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        bool continua = false;
        int codiceVoloCliente = 0;
        VoloAereo volo = new VoloAereo();

        do
        {
            Console.WriteLine("Scegli una delle 3 operazioni: [1] Effettua una prenotazione \n[2] Annulla prenotazione \n[3] Visualizza lo stato del volo \n[4] Esci dal programma");
            int scelta = int.Parse(Console.ReadLine());

            switch (scelta)
            {
                case 1:
                    Console.WriteLine("Inserisci il numero di posti da prenotare:");
                    int numeroPosti = int.Parse(Console.ReadLine());
                    codiceVoloCliente = volo.
                    volo.EffettuaPrenotazione(numeroPosti);
                    break;
                case 2:
                    Console.WriteLine("Inserisci il numero di posti da annullare:");
                    int postiDaAnnullare = int.Parse(Console.ReadLine());
                    volo.CodiceVolo = codiceVoloCliente;
                    volo.AnnullaPrenotazione(postiDaAnnullare);
                    break;
                case 3:

                    volo.CodiceVolo = codiceVoloCliente;
                    volo.VisualizzaStato();
                    break;
                case 4:
                    Console.WriteLine("Uscita dal programma.");
                    continua = false;
                    break;
            }
        } while (!continua);
    }
}