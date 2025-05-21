using System;

//Creazione della classe film
public class Film
{
    //Assegnazione delle variabili
    public string titoloFilm;
    public string registaFilm;
    public int annoFilm;
    public string genereFilm;

    //Costruttore della classe
    public Film(string titolo, string regista, int anno, string genere)
    {
        titoloFilm = titolo;
        registaFilm = regista;
        annoFilm = anno;
        genereFilm = genere;
    }

    //Creazione del metodo per stampare le varie informazioni
    public void Informazioni()
    {
        Console.WriteLine($"Titolo: {titoloFilm} - Regista: {registaFilm} - Anno: {annoFilm} - Genere: {genereFilm}");
    }

}

//Creazione della classe 
public class Program
{
    public static void Main(string[] args)
    {
        //Creazione della lista
        List<Film> videoteca = new List<Film>();

        Console.WriteLine("Inserisci i dati dei film");

        //Ciclo di inserimento dati per ogni film
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("Titolo: ");
            string titolo = Console.ReadLine();

            Console.WriteLine("Regista: ");
            string regista = Console.ReadLine();

            Console.WriteLine("Anno: ");
            int anno = int.Parse(Console.ReadLine());

            Console.WriteLine("Genere: ");
            string genere = Console.ReadLine();

            Film nuovoFilm = new Film(titolo, regista, anno, genere);
            videoteca.Add(nuovoFilm);
        }

        //Creazione della condizione da rispettare
        bool continua = true;

        //Inizio ciclo per il menù di visualizzazione
        while (continua)
        {
            Console.WriteLine("Scegli una tra le 4 opzioni");
            Console.WriteLine("[1] Visualizza i film inseriti \n[2]Visualizza i film in base al genere \n[3] Esci dal programma");

            int scelta = int.Parse(Console.ReadLine());

            switch (scelta)
            {
                case 1:
                    Console.WriteLine("Elenco dei film:");
                    foreach (Film f in videoteca)
                    {
                        f.Informazioni();
                    }
                    break;

                case 2:
                    Console.WriteLine("Inserisci il genere da visualizzare");
                    string cercaGenere = Console.ReadLine();

                    Console.WriteLine($"Film del genere {cercaGenere} trovati:");

                    //Ciclo che permette di controllare se il genere corrisponde a quello inserito
                    foreach (Film f in videoteca)
                    {
                        if (f.genereFilm.ToLower() == cercaGenere.ToLower())
                        {
                            f.Informazioni();
                        }
                    }
                    break;
                //Chiusura del programma
                case 3:
                    Console.WriteLine("Arrivederci");
                    continua = false;
                    break;
                //Chiusura del programma forzata
                default:
                    Console.WriteLine("Valore inserito non valido, riprova!");
                    break;
            }
        }
    }
}
