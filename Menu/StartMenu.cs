namespace _2048.Menu;

public class StartMenu : Menu
{
    public StartMenu()
    {
        const string _2048_title = "#yellow#2048";
        
        Title = _2048_title;
        Subtitle = $"#cyan#Welcome to {_2048_title} !";
        Options = [
            new MenuOption("#green#Easy", () =>
            {
                new Game(1);
            }, 1),
            new MenuOption("#cyan#Medium", () =>
            {
                new Game(2);
            }, 2),
            new MenuOption("#yellow#Hard (Original)", () =>
            {
                new Game(3);
            }, 3),
            new MenuOption("#red#Hardcore", () =>
            {
                new Game(4);
            }, 4),
            new MenuOption("#darkred#Exit", () =>
            {
                Environment.Exit(0);
            }, 5)
        ];
        Centered = true;
    }
}