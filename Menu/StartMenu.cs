namespace _2048.Menu;

public class StartMenu : Menu
{
    public StartMenu()
    {
        const string _2048_title = "#yellow#2048";
        
        _title = _2048_title;
        _subtitle = $"#cyan#Welcome to {_2048_title} !";
        _options = [
            new MenuOption("#cyan#Start Game", () => { Console.WriteLine("test"); }, 1),
            new MenuOption("#red#Exit", () => { Console.WriteLine("test"); }, 2)
        ];
        _centered = true;
    }
}