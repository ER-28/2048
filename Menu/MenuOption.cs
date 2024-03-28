using _2048.utils;

namespace _2048.Menu;

public class MenuOption
{
    public string Label { get; set; }
    public bool Centered { get; set; }
    public int Index { get; set; }
    public bool Selected { get; set; }
    
    public MenuOption(string label, Action action, int index, bool centered = true)
    {
        Label = label;
        // Action = action;
        Centered = centered;
        Index = index;
    }
    
    public void Display()
    {
        if (Centered) Console.SetCursorPosition(Console.WindowWidth / 2 - (ColorWrite.GetTextLength(Label) / 2), Console.WindowHeight / 2 + Index);
        ColorWrite.Parser(Selected ? $"#yellow#> {Label}" : Label);
    }
}