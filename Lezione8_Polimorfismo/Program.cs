using System;

//Creazione classe base con metodo virtuale
public class Animale
{
    public virtual void FaiVerso()
    {
        Console.WriteLine("L'animale fa un verso");
    }
}
//Creazione classe derivata con override del metodo
public class Cane : Animale
{
    public override void FaiVerso()
    {
        Console.WriteLine("Il cane abbaia");
    }
}
//Altra classe derivata con override del metodo
public class Gatto : Animale
{
    public override void FaiVerso()
    {
        Console.WriteLine("Il gatto miagola");
    }
}

//Creazione del main
public class Program
{
    public static void Main(string[] args)
    {
        //Creazione della lista di animali
        List<Animale> animali = new List<Animale>();
        animali.Add(new Cane());
        animali.Add(new Gatto());

        //Polimorfismo in azione : ogni oggetto chiama la sua versione di FaiVerso()
        foreach (Animale a in animali)
        {
            a.FaiVerso(); //Comportamento specifico di Cane o Gatto
        }

//Creazione di un oggetto per un test dell'operatore is
        Animale c = new Cane();
        if (c is Cane)
        {
            ((Cane)c).FaiVerso();
        }
    }
}
