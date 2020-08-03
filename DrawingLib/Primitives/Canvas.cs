using System;

namespace DrawingLib.Primitives
{
    class Canvas
    {
        private readonly char[][] _canvas;
        private readonly ConsoleColor[][] _foregroundColors;
        private readonly ConsoleColor[][] _backgroundColors;
        
        public Canvas() : this(Console.WindowHeight, Console.WindowWidth) { }

        public Canvas(int height, int width)
        {
            Height = height;
            Width = width;
            
            // Initialize empty canvas
            _canvas = new char[height][];
            _foregroundColors = new ConsoleColor[height][];
            _backgroundColors = new ConsoleColor[height][];

            for (int i = 0; i < height; i++)
            {
                _canvas[i] = new char[width];
                _foregroundColors[i] = new ConsoleColor[width];
                _backgroundColors[i] = new ConsoleColor[width];
            }

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    _canvas[i][j] = ' ';
                    _foregroundColors[i][j] = Console.ForegroundColor;
                    _backgroundColors[i][j] = Console.BackgroundColor;
                }
            }
        }
        
        public int Height { get; private set; }
        public int Width { get; private set; }

        public void SetChar(int x, int y, char c, ConsoleColor foreground, ConsoleColor background)
        {
            try
            {
                _canvas[x][y] = c;
                _foregroundColors[x][y] = foreground;
                _backgroundColors[x][y] = background;
            }
            catch (Exception e)
            {
                throw new Exception($"Invalid canvas index, [{x}][{y}], canvas size is [{Height}][{Width}]", e);
            }
        }

        public char GetChar(int x, int y)
        {
            return _canvas[x][y];
        }

        public ConsoleColor GetBackgroundColor(int x, int y)
        {
            return _backgroundColors[x][y];
        }

        public ConsoleColor GetForegroundColor(int x, int y)
        {
            return _foregroundColors[x][y];
        }
    }
}