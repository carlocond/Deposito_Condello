using System;

public class Soldato
{
    private string nome;
    private int anniServizio;

    public string Nome
    {
        get { return nome; }
        set { nome = value; }
    }

    public string Grado { get; set; }

    public int AnniServizio
    {
        get { return anniServizio; }
        set
        {
            if (value >= 0)
            {
                anniServizio = value;
            }
            else
            {
                Console.WriteLine("Errore: anni di servizio non validi.");
            }
        }
    }

    public Soldato(string nome, string grado, int anniServizio)
    {
        Nome = nome;
        Grado = grado;
        AnniServizio = anniServizio;
    }

    public virtual void Descrizione()
    {
        Console.WriteLine($"Il nome del soldato è {Nome}, il grado è {Grado}, gli anni di servizio sono {AnniServizio}");
    }
}

public class Fante : Soldato
{
    public string Arma { get; set; }

    public Fante(string nome, string grado, int anniServizio, string armaPosseduta)
        : base(nome, grado, anniServizio)
    {
        Arma = armaPosseduta;
    }

    public override void Descrizione()
    {
        Console.WriteLine($"Il nome del fante è {Nome}, il grado è {Grado}, gli anni di servizio sono {AnniServizio}, e utilizza l'arma: {Arma}");
    }
}


