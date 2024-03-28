using _2048.utils;

namespace _2048.Menu;

public class Menu
{
    protected bool _centered = true;
    protected string _title = "title";
    protected string _subtitle = "subtitle";
    protected List<MenuOption> _options = [];
    private bool _isRunning = true;
    
    public void Display()
    {
        Console.Clear();
        if (_centered) Console.SetCursorPosition(Console.WindowWidth / 2 - ColorWrite.GetTextLength(_title) / 2, 1);
        ColorWrite.Parser(_title);
        
        if (_centered) Console.SetCursorPosition(Console.WindowWidth / 2 - ColorWrite.GetTextLength(_subtitle) / 2, 2);
        ColorWrite.Parser(_subtitle);
        
        foreach (var option in _options)
        {
            option.Display();
        }
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
                var previous = _options.Find(option => option.Selected);
                previous!.Selected = false;
                var index = _options.IndexOf(previous);
                if (index == 0)
                {
                    _options.Last().Selected = true;
                }
                else
                {
                    _options[index - 1].Selected = true;
                }
                break;
            case ConsoleKey.DownArrow:
                var next = _options.Find(option => option.Selected);
                next!.Selected = false;
                var nextIndex = _options.IndexOf(next);
                if (nextIndex == _options.Count - 1)
                {
                    _options.First().Selected = true;
                }
                else
                {
                    _options[nextIndex + 1].Selected = true;
                }
                break;
            case ConsoleKey.Enter:
                var selected = _options.Find(option => option.Selected);
                // selected.Action();
                break;
        }
    }

    public void Run()
    {
        Console.CursorVisible = false;
        
        _options.First().Selected = true;
        while (_isRunning)
        {
            Display();
            HandleInput();
            Thread.Sleep(200);
        }
    }
}