using System;
using Microsoft.VisualBasic;

public sealed class ConfigurazioneSistema
{
    //Creazione dell'unica istanza (Singleton)
    private static ConfigurazioneSistema istanza;
    internal Dictionary<string, string> configurazioni;

    //Costruttore privato che impedisce di istanziare la classe dall'esterno
    //Inizializza il dizionario delle chiavi
    private ConfigurazioneSistema()
    {
        configurazioni = new Dictionary<string, string>();
    }

    //Proprietà statica che crea l'istanza se non esiste, ovviamente UNICA
    public static ConfigurazioneSistema Istanza
    {
        get
        {
            if (istanza == null)
                istanza = new ConfigurazioneSistema();
            return istanza;
        }
    }

    //Metodo che serve ad impostare una configurazione
    public void Imposta(string chiave, string valore)
    {
        configurazioni[chiave] = valore;
    }

    //Metodo che legge una configurazione e controlla se esiste la chiave
    public string Leggi(string chiave)
    {
        return configurazioni.ContainsKey(chiave) ? configurazioni[chiave] : "(Chiave non esistente)";
    }

    //Metodo che stampa le configurazioni inserite
    public void StampaConf()
    {
        foreach (var conf in configurazioni)
        {
            Console.WriteLine($"Configurazioni disponibili: {conf.Key} | {conf.Value}");
        }
    }
}

//Creazione della classe modulo1 che contiene il metodo che imposta le configurazioni
public class Modulo1
{
    public void Imposta()
    {
        var imposta = ConfigurazioneSistema.Istanza;
        imposta.Imposta("Pippo", "Diamond IV");
        imposta.Imposta("100LP", "Yasuo");
    }
}

//Creazione di un altro modulo che esegue le stesse operazioni
public class Modulo2
{
    public void Imposta()
    {
        var imposta = ConfigurazioneSistema.Istanza;
        imposta.Imposta("Continente", "EU");
        imposta.Imposta("Lingua", "ITA");
    }
}

//Creazione del main
public class Program
{
    public static void Main(string[] args)
    {
        //Istanzio i due moduli
        Modulo1 modulo1 = new Modulo1();
        Modulo2 modulo2 = new Modulo2();

        //Imposto le configurazioni 
        modulo1.Imposta();
        modulo2.Imposta();

        //Stampa di tutte le configurazioni
        ConfigurazioneSistema.Istanza.StampaConf();

        //Controllo se l'istanza è unica
        Console.WriteLine($"Sono i due moduli uguali? {ConfigurazioneSistema.Istanza == ConfigurazioneSistema.Istanza}");


    }
}
