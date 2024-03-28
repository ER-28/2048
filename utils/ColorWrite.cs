namespace _2048.utils;

public class ColorWrite
{
    private static void PrintColor (string text, ConsoleColor color, bool newLine = false)
    {
        Console.ForegroundColor = color;
        if (newLine)
        {
            Console.WriteLine(text);
        }
        else
        {
            Console.Write(text);
        }
        Console.ResetColor();
    }
    
    public static void Parser (string text)
    {
        var splitText = text.Split("#");
        
        for (var i = 0; i < splitText.Length; i++)
        {
            switch (splitText[i])
            {
                case "black":
                    PrintColor(splitText[i + 1], ConsoleColor.Black);
                    i++;
                    break;
                case "darkblue":
                    PrintColor(splitText[i + 1], ConsoleColor.DarkBlue);
                    i++;
                    break;
                case "darkgreen":
                    PrintColor(splitText[i + 1], ConsoleColor.DarkGreen);
                    i++;
                    break;
                case "darkred":
                    PrintColor(splitText[i + 1], ConsoleColor.DarkRed);
                    i++;
                    break;
                case "darkmagenta":
                    PrintColor(splitText[i + 1], ConsoleColor.DarkMagenta);
                    i++;
                    break;
                case "darkyellow":
                    PrintColor(splitText[i + 1], ConsoleColor.DarkYellow);
                    i++;
                    break;
                case "darkcyan":
                    PrintColor(splitText[i + 1], ConsoleColor.DarkCyan);
                    i++;
                    break;
                case "gray":
                    PrintColor(splitText[i + 1], ConsoleColor.Gray);
                    i++;
                    break;
                case "darkgray":
                    PrintColor(splitText[i + 1], ConsoleColor.DarkGray);
                    i++;
                    break;
                case "blue":
                    PrintColor(splitText[i + 1], ConsoleColor.Blue);
                    i++;
                    break;
                case "green":
                    PrintColor(splitText[i + 1], ConsoleColor.Green);
                    i++;
                    break;
                case "cyan":
                    PrintColor(splitText[i + 1], ConsoleColor.Cyan);
                    i++;
                    break;
                case "red":
                    PrintColor(splitText[i + 1], ConsoleColor.Red);
                    i++;
                    break;
                case "magenta":
                    PrintColor(splitText[i + 1], ConsoleColor.Magenta);
                    i++;
                    break;
                case "yellow":
                    PrintColor(splitText[i + 1], ConsoleColor.Yellow);
                    i++;
                    break;
                case "white":
                    PrintColor(splitText[i + 1], ConsoleColor.White);
                    i++;
                    break;
                default:
                    Console.Write(splitText[i]);
                    break;
            }
        }
    }
    
    public static int GetTextLength (string text)
    {
        var length = 0;
        foreach (var word in text.Split("#"))
        {
            if (word == "red" || word == "blue" || word == "green" || word == "yellow" || word == "magenta" || word == "cyan" || word == "white" || word == "black" || word == "darkblue" || word == "darkgreen" || word == "darkred" || word == "darkyellow" || word == "darkmagenta" || word == "darkcyan" || word == "gray" || word == "darkgray")
            {
                continue;
            }
            length += word.Length;
        }
        
        return length;
    }
    
}