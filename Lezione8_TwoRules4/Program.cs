using System;
using System.Runtime.Intrinsics.Arm;

public class Soldato
{
    private string nomeS;
    private string gradoS;
    private int anniServizioS;

    public string Nome
    {
        get { return nomeS; }
        set { nomeS = value; }
    }
    public string Grado { get; set; }
    private int AnniServizio
    {
        get { return anniServizioS; }
        set
        {
            if (value >= 0)
            {
                anniServizioS = value;
            }
            else
            {
                Console.WriteLine("Errore");
            }
        }
    }
    public Soldato(string nome, string grado, int anniServizio)
    {
        nomeS = nome;
        gradoS = grado;
        anniServizioS = anniServizio;
    }

    public virtual void Descrizione()
    {
        Console.WriteLine($"Il nome del soldato è {Nome}, il grado è {Grado}, gli anni di servizio sono {AnniServizio}");
    }
}

public class Fante : Soldato
{
    private string arma;

    public string Arma { get; set; }

    public Fante(string nome, string grado, int anniServizio, string armaPosseduta) : base(nome, grado, anniServizio)
    {
        arma = armaPosseduta;
    }

    public override void Descrizione()
    {
        Console.WriteLine("Il nome del soldato è " + get.nomeS + " il grado è {grado}, gli anni di servizio sono {anniServizio}");
    }
}


