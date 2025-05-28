using System.Drawing;

public interface IShape
{
    void Draw();
}
public class Circle : IShape
{
    public void Draw()
    {
        Console.WriteLine("Disegno di un Cerchio");
    }
}
public class Square : IShape
{
    public void Draw()
    {
        Console.WriteLine("Disegno di un Quadrato");
    }
}
public class Rectangle : IShape
{
    public void Draw()
    {
        Console.WriteLine("Disegno di un Rettangolo");
    }
}
public abstract class ShapeCreatorCircle
{
    // Metodo statico che crea un veicolo in base al tipo richiesto
    public static IShape CreateShape(string type)
    {
        switch (type)
        {
            case "circle":
                return new Circle(); // Ritorna un oggetto Circle
            default:
                // Se il tipo non è valido, viene sollevata un'eccezione
                throw new ArgumentException("Inserisci una forma valida: circle, square o rectangle.");
        }
    }
}
public abstract class ShapeCreatorSquare
{
    // Metodo statico che crea un veicolo in base al tipo richiesto
    public static IShape CreateShape(string type)
    {
        switch (type)
        {
            case "square":
                return new Square(); // Ritorna un oggetto Square
            default:
                // Se il tipo non è valido, viene sollevata un'eccezione
                throw new ArgumentException("Inserisci una forma valida: circle, square o rectangle.");
        }
    }
}
public abstract class ShapeCreatorRectangle
{
    // Metodo statico che crea un veicolo in base al tipo richiesto
    public static IShape CreateShape(string type)
    {
        switch (type)
        {
            case "rectangle":
                return new Rectangle(); // Ritorna un oggetto Rectangle
            default:
                // Se il tipo non è valido, viene sollevata un'eccezione
                throw new ArgumentException("Inserisci una forma valida: circle, square o rectangle.");
        }
    }
}

// Classe principale del programma
public class Program
{
    public static void Main(string[] args)
    {
        // Chiede all'utente di inserire il tipo di veicolo desiderato
        Console.WriteLine("Inserisci una forma circle, square o rectangle:");
        string input = Console.ReadLine();

        switch (input)
        {
            case "circle":
                Console.WriteLine("Hai scelto un cerchio.");
                ShapeCreatorCircle.CreateShape(input);
                IShape formaCerchio = ShapeCreatorCircle.CreateShape(input);
                formaCerchio.Draw(); // Disegna il cerchio
                break;

            case "square":
                ShapeCreatorSquare.CreateShape(input);
                IShape formaQuadrato = ShapeCreatorSquare.CreateShape(input);
                formaQuadrato.Draw(); // Disegna il quadrato
                Console.WriteLine("Hai scelto un quadrato.");
                break;

            case "rectangle":
                ShapeCreatorRectangle.CreateShape(input);
                IShape formaRettangolo = ShapeCreatorRectangle.CreateShape(input);
                formaRettangolo.Draw(); // Disegna il rettangolo
                Console.WriteLine("Hai scelto un rettangolo.");
                break;

            default:
                Console.WriteLine("Forma non valida. Inserisci circle, square o rectangle.");
                return; // Esce dal programma se l'input non è valido
        }
    }
}