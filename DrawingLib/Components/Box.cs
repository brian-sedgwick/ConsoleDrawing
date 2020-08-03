using System;
using DrawingLib.Models;
using DrawingLib.Primitives;

namespace DrawingLib.Components
{
    internal class Box : ComponentBase
    {
        private readonly int _height;
        private readonly int _width;
        private readonly int _x;
        private readonly int _y;
        private readonly LineType _lineType;
        private readonly ConsoleColor _foreground;
        private readonly ConsoleColor _background;

        /// <summary>
        /// Create a new box with double line characters.
        /// </summary>
        /// <param name="height">The number of characters high</param>
        /// <param name="width">The number of characters wide</param>
        /// <param name="x">Top left x coordinate of box</param>
        /// <param name="y">Top left y coordinate of box</param>
        /// <param name="lineType">The type of line to draw the box with</param>
        public Box(int height, int width, int x, int y, LineType lineType, ConsoleColor foreground, ConsoleColor background)
        {
            _height = height;
            _width = width;
            _x = x;
            _y = y;
            _lineType = lineType;
            _foreground = foreground;
            _background = background;
            InitializeBox();
        }

        private void InitializeBox()
        {
            Characters.Add(new CharCoordinate
            {
                C = LineConstants.UpperLeftCorner[(int)_lineType],
                X = _x,
                Y = _y,
                BackgroundColor = _background,
                ForegroundColor = _foreground
            });
            
            Characters.Add(new CharCoordinate
            {
                C = LineConstants.UpperRightCorner[(int)_lineType],
                X = _x,
                Y = _y + _width - 1,
                BackgroundColor = _background,
                ForegroundColor = _foreground
            });
            
            Characters.Add(new CharCoordinate
            {
                C = LineConstants.LowerLeftCorner[(int)_lineType],
                X = _x + _height - 1,
                Y = _y,
                BackgroundColor = _background,
                ForegroundColor = _foreground
            });
            
            Characters.Add(new CharCoordinate
            {
                C = LineConstants.LowerRightCorner[(int)_lineType],
                X = _x + _height - 1,
                Y = _y + _width - 1,
                BackgroundColor = _background,
                ForegroundColor = _foreground
            });
            
            for(int i = 1; i < _width - 1; i++)
            {
                Characters.Add(new CharCoordinate
                {
                    C = LineConstants.HorizontalLine[(int)_lineType],
                    X = _x,
                    Y = _y + i,
                    BackgroundColor = _background,
                    ForegroundColor = _foreground
                });
                Characters.Add(new CharCoordinate
                {
                    C = LineConstants.HorizontalLine[(int)_lineType],
                    X = _x + _height - 1,
                    Y = _y + i,
                    BackgroundColor = _background,
                    ForegroundColor = _foreground
                });
            }

            for (int i = 1; i < _height - 1; i++)
            {
                Characters.Add(new CharCoordinate
                {
                    C = LineConstants.VerticalLine[(int)_lineType],
                    X = _x + i,
                    Y = _y,
                    BackgroundColor = _background,
                    ForegroundColor = _foreground
                });
                Characters.Add(new CharCoordinate
                {
                    C = LineConstants.VerticalLine[(int)_lineType],
                    X = _x + i,
                    Y = _y + _width - 1,
                    BackgroundColor = _background,
                    ForegroundColor = _foreground
                });
            }
        }
    }
}