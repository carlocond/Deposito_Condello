using System;

public class Punto
{
    public int x;
    public int y;

    //Sovrascrive Equals per confrontare le coordinate assegnate
    public override bool Equals(object? obj)
    {
        if (obj is Punto other)
        {
            return this.x == other.x && this.y == other.y;
        }
        return false;
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Punto a = new Punto { x = 1, y = 2 };
            Punto b = new Punto { x = 2, y = 3 };

            Console.WriteLine(a.Equals(b));
            //Output false (diversi oggetti differenti)

            Punto c = new Punto { x = 1, y = 2 };
            Console.WriteLine(a.Equals(c));
            //Output true (diversi oggetti uguali)
        }
    }
}
