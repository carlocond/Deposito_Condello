using System;

public delegate void Logger(string message);

class Program
{
    static void ConsoleLogger(string message)
    {
        Console.WriteLine($"Console Logger: {message}");
    }
    static void FileLogger(string message)
    {
        // Simulazione di scrittura su file
        Console.WriteLine($"File Logger: {message}");
    }
    public static void Main(string[] args)
    {
        Logger logger = ConsoleLogger;
        logger += FileLogger;

        logger("Messaggio di log");
    }
}
