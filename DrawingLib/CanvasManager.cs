using System;
using System.Collections.Generic;
using DrawingLib.Components;
using DrawingLib.Primitives;

namespace DrawingLib
{
    public class CanvasManager
    {
        private readonly Canvas _canvas;
        private readonly List<ComponentBase> _components;
        public CanvasManager()
        {
            _canvas = new Canvas();
            _components = new List<ComponentBase>();
        }

        ~CanvasManager()
        {
            ClearScreen();
            Console.SetCursorPosition(0, 0);
        }

        private void ClearScreen()
        {
            
        }

        public void Redraw()
        {
            DrawComponentsOnCanvas();
            OutputCanvasToConsole();
        }

        private void OutputCanvasToConsole()
        {
            Console.SetCursorPosition(0, 0);
            for(int i = 0; i < _canvas.Height; i++)
            {
                for (int j = 0; j < _canvas.Width; j++)
                {
                    Console.BackgroundColor = _canvas.GetBackgroundColor(i, j);
                    Console.ForegroundColor = _canvas.GetForegroundColor(i, j);
                    Console.Write(_canvas.GetChar(i, j));
                }
                if(i < _canvas.Height - 1) Console.WriteLine();
            }
        }

        private void DrawComponentsOnCanvas()
        {
            foreach (var component in _components)
            {
                foreach (var character in component.Characters)
                {
                    _canvas.SetChar(character.X, character.Y, character.C, character.ForegroundColor, character.BackgroundColor);
                }
            }
        }

        /// <summary>
        /// Add a box to the canvas.
        /// </summary>
        /// <param name="height">Height of the box</param>
        /// <param name="width">Width of the box</param>
        /// <param name="x">X coordinate of upper left corner</param>
        /// <param name="y">Y coordinate of upper left corner</param>
        /// <param name="lineType">The style of line to draw the box with</param>
        /// <param name="foreground">The foreground color of the box</param>
        /// <param name="background">The background color of the box</param>
        public void DrawBox(int height, int width, int x, int y, LineType lineType, ConsoleColor foreground, ConsoleColor background)
        {
            var box = new Box(height, width, x, y, lineType, foreground, background);
            _components.Add(box);
        }
    }
}