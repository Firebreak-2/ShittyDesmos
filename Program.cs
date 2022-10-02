namespace ShittyDesmos;

public static class Program
{
    public static void Main(string[] args)
    {
        ConsoleKeyInfo lastPressedKey;
        
        var graph = new Graph();
        
        graph.DrawFunction(x => x, ConsoleColor.Green);
        graph.DrawFunction(x => x / 2, ConsoleColor.Red);
        graph.DrawFunction(x => x * x / 20, ConsoleColor.Blue);
        
        do
        {
            graph.Display();

            lastPressedKey = Console.ReadKey(true);

            // -- handle camera movement --
            
            const int movement = 2;

            switch (lastPressedKey.Key)
            {
                case ConsoleKey.RightArrow:
                    graph.Move(movement, 0);
                    break;
                case ConsoleKey.LeftArrow:
                    graph.Move(-movement, 0);
                    break;
                case ConsoleKey.UpArrow:
                    graph.Move(0, -movement);
                    break;
                case ConsoleKey.DownArrow:
                    graph.Move(0, movement);
                    break;
            }
            
        } while (lastPressedKey.Key != ConsoleKey.Spacebar);
    }
}
