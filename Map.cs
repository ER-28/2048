using _2048.utils;

namespace _2048;

public class Map
{
    private List<List<int>> _map = [];
    private int _width;
    private int _height;
    
    public Map(int width, int height)
    {
        _width = width;
        _height = height;
        
        for (var y = 0; y < height; y++)
        {
            _map.Add([]);
            
            for (var x = 0; x < width; x++)
            {
                _map[y].Add(0);
            }
        }
        AddRandomTile();
    }

    private void AddRandomTile()
    {
        List<Position> emptyTiles = [];
        
        for (var y = 0; y < _map.Count; y++)
        {
            for (var x = 0; x < _map[y].Count; x++)
            {
                if (_map[y][x] == 0)
                {
                    emptyTiles.Add(new Position(x, y));
                }
            }
        }
        
        if (emptyTiles.Count == 0) return;
        
        var randomTile = emptyTiles[new Random().Next(0, emptyTiles.Count)];
        var value = new Random().Next(0, 10) < 6 ? 2 : 4;
        _map[randomTile.Y][randomTile.X] = value;
    }

    public void Draw()
    {
        var mapWidth = _map[0].Count * 7;
        var startX = (Console.WindowWidth - mapWidth) / 2;

        Console.SetCursorPosition(Console.WindowWidth / 2 - ColorWrite.GetTextLength(Game.Score.ToString()) / 2, Console.WindowHeight);
        ColorWrite.Parser($"#yellow#Score: {Game.Score}");
        
        Console.SetCursorPosition(0, 0);
        
        foreach (var row in _map)
        {
            Console.SetCursorPosition(startX, Console.CursorTop);

            for (var x = 0; x < row.Count; x++)
            {
                Console.Write("┌─────┐");
            }

            Console.WriteLine();

            Console.SetCursorPosition(startX, Console.CursorTop);

            for (var x = 0; x < row.Count; x++)
            {
                Console.Write("│");
                var color = row[x] switch
                {
                    0 => "#black#",
                    2 => "#green#",
                    4 => "#blue#",
                    8 => "#cyan#",
                    16 => "#red#",
                    32 => "#magenta#",
                    64 => "#yellow#",
                    128 => "#white#",
                    256 => "#black#",
                    512 => "#green#",
                    1024 => "#blue#",
                    2048 => "#cyan#",
                    _ => "#red#"
                };
                
                if (row[x] == 0) Console.Write("     ");
                else ColorWrite.Parser(color + row[x].ToString().PadLeft(5) );
                
                Console.Write("│");
            }

            Console.WriteLine();

            Console.SetCursorPosition(startX, Console.CursorTop);

            for (var x = 0; x < row.Count; x++) Console.Write("└─────┘");

            Console.WriteLine();
        }
    }

    public void Move(int direction)
    {
        switch (direction)
        {
            case Direction.Up:
                MoveUp();
                break;
            case Direction.Down:
                MoveDown();
                break;
            case Direction.Left:
                MoveLeft();
                break;
            case Direction.Right:
                MoveRight();
                break;
        }
        AddRandomTile();
        if (CheckGameOver()) Game.Running = false;
    }

    private void MoveUp()
    {
        for (var x = 0; x < _width; x++)
        {
            for (var y = 0; y < _height; y++)
            {
                if (_map[y][x] == 0) continue;

                while (y - 1 >= 0 && _map[y - 1][x] == 0)
                {
                    _map[y - 1][x] = _map[y][x];
                    _map[y][x] = 0;
                    y--;
                }
                
                for (var y2 = y - 1; y2 >= 0; y2--)
                {
                    if (_map[y2][x] == 0)
                    {
                        _map[y2][x] = _map[y][x];
                        _map[y][x] = 0;
                    }
                    else if (_map[y2][x] == _map[y][x])
                    {
                        _map[y2][x] *= 2;
                        Game.Score += _map[y2][x];
                        _map[y][x] = 0;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
    
    private void MoveDown()
    {
        for (var x = 0; x < _width; x++)
        {
            for (var y = _height - 1; y >= 0; y--)
            {
                if (_map[y][x] == 0) continue;

                while (y + 1 < _height && _map[y + 1][x] == 0)
                {
                    _map[y + 1][x] = _map[y][x];
                    _map[y][x] = 0;
                    y++;
                }
                
                for (var y2 = y + 1; y2 < _height; y2++)
                {
                    if (_map[y2][x] == 0)
                    {
                        _map[y2][x] = _map[y][x];
                        _map[y][x] = 0;
                    }
                    else if (_map[y2][x] == _map[y][x])
                    {
                        _map[y2][x] *= 2;
                        Game.Score += _map[y2][x];
                        _map[y][x] = 0;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
    
    private void MoveLeft()
    {
        for (var y = 0; y < _height; y++)
        {
            for (var x = 0; x < _width; x++)
            {
                if (_map[y][x] == 0) continue;

                while (x - 1 >= 0 && _map[y][x - 1] == 0)
                {
                    _map[y][x - 1] = _map[y][x];
                    _map[y][x] = 0;
                    x--;
                }
                
                for (var x2 = x - 1; x2 >= 0; x2--)
                {
                    if (_map[y][x2] == 0)
                    {
                        _map[y][x2] = _map[y][x];
                        _map[y][x] = 0;
                    }
                    else if (_map[y][x2] == _map[y][x])
                    {
                        _map[y][x2] *= 2;
                        Game.Score += _map[y][x2];
                        _map[y][x] = 0;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
    
    private void MoveRight()
    {
        for (var y = 0; y < _height; y++)
        {
            for (var x = _width - 1; x >= 0; x--)
            {
                if (_map[y][x] == 0) continue;

                while (x + 1 < _width && _map[y][x + 1] == 0)
                {
                    _map[y][x + 1] = _map[y][x];
                    _map[y][x] = 0;
                    x++;
                }
                
                for (var x2 = x + 1; x2 < _width; x2++)
                {
                    if (_map[y][x2] == 0)
                    {
                        _map[y][x2] = _map[y][x];
                        _map[y][x] = 0;
                    }
                    else if (_map[y][x2] == _map[y][x])
                    {
                        _map[y][x2] *= 2;
                        Game.Score += _map[y][x2];
                        _map[y][x] = 0;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
    
    public bool CheckGameOver()
    {
        for (var y = 0; y < _height; y++)
        {
            for (var x = 0; x < _width; x++)
            {
                if (_map[y][x] == 0) return false;
                
                if (x + 1 < _width && _map[y][x] == _map[y][x + 1]) return false;
                if (y + 1 < _height && _map[y][x] == _map[y + 1][x]) return false;
            }
        }
        
        return true;
    }
}