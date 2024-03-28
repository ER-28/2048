namespace _2048.Menu;

public class StartMenu : Menu
{
    public StartMenu()
    {
        const string _2048_title = "#yellow#2048";
        
        Title = _2048_title;
        Subtitle = $"#cyan#Welcome to {_2048_title} !";
        Options = [
            new MenuOption("#cyan#Start Game", () =>
            {
                new Game();
            }, 1),
            new MenuOption("#red#Exit", () =>
            {
                Environment.Exit(0);
            }, 2)
        ];
        Centered = true;
    }
}