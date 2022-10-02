using System.Drawing;

namespace ShittyDesmos;

public class Graph
{
    private Dictionary<Func<double, BigDecimal>, ConsoleColor> _drawList = new();
    public Point ViewOffset = new((-Console.WindowWidth / 2 - 1) / 2, (-Console.WindowHeight - 1) / 2);

    /// <summary>
    /// Add a function to be drawn on the graph
    /// </summary>
    /// <param name="function">The function to draw</param>
    /// <param name="color">The color of the line of this function</param>
    public void DrawFunction(Func<double, BigDecimal> function, ConsoleColor color = ConsoleColor.White)
    {
        _drawList.Add(function, color);
    }

    /// <summary>
    /// Clears the console and draws an ascii representation of the graph
    /// </summary>
    public void Display()
    {
        int screenWidth = Console.WindowWidth / 2 - 1;
        int screenHeight = Console.WindowHeight - 1;

        for (int y = screenHeight - 1; y >= 0; y--)
        {
            for (int x = 0; x < screenWidth; x++)
            {
                // gets the current point with the camera offset
                var currentPoint = new Point(x + ViewOffset.X, y + ViewOffset.Y);

                string toWrite = "  ";
                
                // draws the axis lines if y == 0 or x == 0
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
                else if (currentPoint.X == 0) // origin
                {
                    toWrite = "O";
                }
                
                // checks if any function draws on the current pixel and uses its color
                if (_drawList.TryFirst(f => BigDecimal.Abs(f.Key(currentPoint.X) - currentPoint.Y) < 1, out var func))
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

    public void Move(Point offset)
    {
        ViewOffset.X += offset.X;
        ViewOffset.Y += offset.Y;
    }

    public void Move(int x, int y) => Move(new Point(x, y));
}