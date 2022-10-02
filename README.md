# ShittyDesmos
A graphing calculator that renders the graph in the terminal.

# Example Code
```cs
var graph = new Graph();

graph.DrawFunction(x => x, ConsoleColor.Green);
graph.DrawFunction(x => x / 2, ConsoleColor.Red);
graph.DrawFunction(x => x * x / 20, ConsoleColor.Blue);

graph.Display();
```
Output:
![A graph in the terminal showcasing the output of the drawn functions](https://i.imgur.com/MHDqTkZ.png)
