namespace ShittyDesmos;

public static class Program
{
    public static void Main(string[] args)
    {
        do
        {
            var graph = new Graph();
            
            graph.DrawFunction(x => x, ConsoleColor.Green);
            graph.DrawFunction(x => x / 2, ConsoleColor.Red);
            graph.DrawFunction(x => x * x / 20, ConsoleColor.Blue);
            
            graph.Display();
            
        } while (Console.ReadKey(true).Key == ConsoleKey.R);
    }
}
