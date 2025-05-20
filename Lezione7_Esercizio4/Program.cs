using System;
using System.Security.Cryptography.X509Certificates;

public class Utente
{
    public string password;
    public int etaUtente;
    public string username;


    public Utente(string passw, int eta, string nickname)
    {
        password = passw;
        etaUtente = eta;
        username = nickname;
    }
}
public class Calcolatrice {

    public int somma;
    public int moltiplicazione;
    public double divisione;

    public int selezione;

}
public class Program
{
    public static void Main(string[] args)
    {

    }
}
