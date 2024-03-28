using System.Text;
using _2048.utils;

namespace _2048;

public class Game
{
    public static bool Running = true;
    public static Map Map { get; set; } = new (4, 4);
    public static bool Updated { get; set; } = true;
    public static bool Win { get; set; } = false;
    public static int Score { get; set; } = 0;
    public static int MaxValue { get; set; } = 2048;
    
    public Game(int difficulty)
    {
        Updated = true;
        Console.OutputEncoding = Encoding.UTF8;
        Console.CursorVisible = false;

        Reset();
        
        switch (difficulty)
        {
            case 1:
                Map = new Map(8, 8);
                MaxValue = 8192;
                break;
            case 2:
                Map = new Map(6, 6);
                MaxValue = 4096;
                break;
            case 3:
                Map = new Map(4, 4);
                MaxValue = 2048;
                break;
            case 4:
                Map = new Map(3, 3);
                MaxValue = 1024;
                break;
            default:
                Map = new Map(4, 4);
                MaxValue = 2048;
                break;
        }

        Loop();
    }

    private static void Reset()
    {
        Updated = true;
        Win = false;
        Running = true;
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

    private void HandleInput()
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