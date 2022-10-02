using System.Drawing;

namespace ShittyDesmos;

public class Graph
{
    private Dictionary<Func<double, double>, ConsoleColor> _drawList = new();
    private Point ViewOffest = new((-Console.WindowWidth / 2 - 1) / 2, (-Console.WindowHeight - 1) / 2);

    public void DrawFunction(Func<double, double> function, ConsoleColor color = ConsoleColor.White)
    {
        _drawList.Add(function, color);
    }

    public void Display()
    {
        int screenWidth = Console.WindowWidth / 2 - 1;
        int screenHeight = Console.WindowHeight - 1;

        for (int y = 0; y < screenHeight; y++)
        {
            for (int x = 0; x < screenWidth; x++)
            {
                var currentPoint = new Point(x + ViewOffest.X, y + ViewOffest.Y);

                string toWrite = "  ";
                
                if (currentPoint.X != currentPoint.Y)
                {
                    if (currentPoint.X == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        toWrite = "| ";
                    }
                    else if (currentPoint.Y == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        toWrite = "- ";
                    }
                }
                
                if (_drawList.TryFirst(f => Math.Abs(f.Key(currentPoint.X) - currentPoint.Y) < 1, out var func))
                {
                    Console.ForegroundColor = _drawList[func.Key];
                    toWrite = "# ";
                }

                Console.Write(toWrite);
            }

            Console.WriteLine();
        }
        
        Console.ResetColor();
    }

    public void Move(Point offest)
    {
        ViewOffest.X += offest.X;
        ViewOffest.Y += offest.Y;
    }

    public void Move(int x, int y) => Move(new Point(x, y));
}