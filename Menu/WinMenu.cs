namespace _2048.Menu;

public class WinMenu : Menu
{
    public WinMenu(int score)
    {
        const string _2048_title = "#yellow#2048";
        
        Title = _2048_title;
        Subtitle = $"#cyan#You win with a score of {score} !";
        Options = [
            new MenuOption("#cyan# Play Again", () =>
            {
                var startMenu = new StartMenu();
                startMenu.Run();
            }, 1),
            new MenuOption("#red#Exit", () =>
            {
                Environment.Exit(0);
            }, 5)
        ];
        Centered = true;
    }
}