//Creazione classe astratta
public abstract class Veicolo
{
    public abstract void Avvia();
}

//Classe concreta che eredita da quella astratta
public class Auto : Veicolo
{
    public override void Avvia()
    {
        Console.WriteLine("L'auto si accende");
    }
}
//Interfaccia
public interface IVeicoloElettrico
{
    void Ricarica();
}

//Classe che implementa l'interfaccia
public class ScooterElettrico : IVeicoloElettrico
{
    public void Ricarica()
    {
        Console.WriteLine($"Scooter in carica");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Veicolo auto1 = new Auto();
        auto1.Avvia();

        IVeicoloElettrico scooter1 = new ScooterElettrico();
        scooter1.Ricarica();
    }
}
