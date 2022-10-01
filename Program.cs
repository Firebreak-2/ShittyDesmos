using System.Drawing;

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

public class Graph
{
    private Dictionary<Point, ConsoleColor> _drawList = new();

    public void DrawFunction(Func<double, double> function, ConsoleColor color = ConsoleColor.White)
    {
        int screenWidth = Console.WindowWidth / 2 - 1;
        int screenHeight = Console.WindowHeight - 1;

        for (int y = 0; y < screenHeight; y++)
        {
            for (int x = 0; x < screenWidth; x++)
            {
                if (Math.Abs((int) (y - function(x))) >= 1) 
                    continue;
                
                var currentPoint = new Point(x, y);

                if (!_drawList.ContainsKey(currentPoint))
                {
                    _drawList.Add(currentPoint, color);
                }
                else
                {
                    _drawList[currentPoint] = color;
                }
            }
        }
    }

    public void Display()
    {
        int screenWidth = Console.WindowWidth / 2 - 1;
        int screenHeight = Console.WindowHeight - 1;

        for (int y = 0; y < screenHeight; y++)
        {
            for (int x = 0; x < screenWidth; x++)
            {
                var currentPoint = new Point(x, y);
                
                if (_drawList.ContainsKey(currentPoint))
                {
                    Console.ForegroundColor = _drawList[currentPoint];
                    Console.Write("# ");
                }
                else
                {
                    Console.Write("  ");
                }
            }

            Console.WriteLine();
        }
        
        Console.ResetColor();
    }
}
