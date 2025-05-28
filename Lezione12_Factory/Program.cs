using System;

//Product che definisce l'interfaccia del prodotto
public interface IProduct
{
    void Operation();
}
//ConcreteProductA che implementa l'interfaccia del prodotto
public class ConcreteProductA : IProduct
{
    public void Operation()
    {
        Console.WriteLine("Esecuzione dell'operazione del ConcreteProductA(ConcreteProductA.Operation())");
    }
}

//ConcreteProductB che implementa l'interfaccia del prodotto
public class ConcreteProductB : IProduct
{
    public void Operation()
    {
        Console.WriteLine("Esecuzione dell'operazione del ConcreteProductB(ConcreteProductB.Operation())");
    }
}

//Creator che definisce il metodo factory
public abstract class Creator
{
    //Metodo che restituisce un prodotto
    public abstract IProduct FactoryMethod();

    //Metodo che utilizza il prodotto
    public void SomeOperation()
    {
        //Creazione del prodotto tramite il metodo factory
        IProduct product = FactoryMethod();
        //Esecuzione dell'operazione del prodotto
        product.Operation();
    }
}

//ConcreteCreatorA implementa il metodo factory per creare ConcreteProductA
public class ConcreteCreatorA : Creator
{
    public override IProduct FactoryMethod()
    {
        return new ConcreteProductA();
    }
}
//ConcreteCreatorB implementa il metodo factory per creare ConcreteProductB
public class ConcreteCreatorB : Creator
{
    public override IProduct FactoryMethod()
    {
        return new ConcreteProductB();
    }
}

//Esempio di utilizzo del Factory Method
public class Program
{
    public static void Main(string[] args)
    {
        //Creazione del creator A e utilizzo del prodotto
        Creator creatorA = new ConcreteCreatorA();
        creatorA.SomeOperation();

        //Creazione del creator B e utilizzo del prodotto
        Creator creatorB = new ConcreteCreatorB();
        creatorB.SomeOperation();
    }
}
