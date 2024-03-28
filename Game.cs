using System.Text;
using _2048.utils;

namespace _2048;

public class Game
{
    public static bool Running = true;
    public static Map Map { get; set; } = new Map(4, 4);
    public static bool Updated { get; set; } = true;
    public static bool Win { get; set; } = false;
    
    public Game()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.CursorVisible = false;

        Loop();
    }
    
    private void Loop()
    {
        while (Running)
        {
            Console.SetCursorPosition(0, 0);

            if (Updated)
            {
                Console.Clear();
                Map.Draw();
                Updated = false;
            }
            HandleInput();
            
            Thread.Sleep(100);
        }
        Console.Clear();
        Console.WriteLine(Win ? "You won!" : "You lost!");
    }
    
    public void HandleInput()
    {
        if (!Console.KeyAvailable) return;
        
        var key = Console
            .ReadKey(intercept: true)
            .Key;
        
        switch (key)
        {
            case ConsoleKey.UpArrow:
                Map.Move(Direction.Up);
                Updated = true;
                break;
            case ConsoleKey.DownArrow:
                Map.Move(Direction.Down);
                Updated = true;
                break;
            case ConsoleKey.LeftArrow:
                Map.Move(Direction.Left);
                Updated = true;
                break;
            case ConsoleKey.RightArrow:
                Map.Move(Direction.Right);
                Updated = true;
                break;
        }
    }
    
}