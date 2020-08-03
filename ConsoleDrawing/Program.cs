using System;
using System.Collections.Generic;
using System.Threading;
using DrawingLib;
using DrawingLib.Primitives;

namespace ConsoleDrawing
{
    class Program
    {
        private static readonly ConsoleColor[] Colors =
        {
            ConsoleColor.Gray,
            ConsoleColor.Magenta,
            ConsoleColor.Blue,
            ConsoleColor.Cyan,
            ConsoleColor.Red,
            ConsoleColor.Yellow
        };
        
        static void Main(string[] args)
        {
            var manager = new CanvasManager();

            Console.CursorVisible = false;
            manager.DrawBox(
                Console.WindowHeight,
                Console.WindowWidth,
                0,
                0,
                LineType.DoubleLine,
                ConsoleColor.Yellow,
                ConsoleColor.DarkBlue
            );

            manager.Redraw();

            var rand = new Random();
            foreach (var prop in GetRandomBoxProps())
            {
                var foregroundColor = Colors[rand.Next(Colors.Length - 1)];
                var backgroundColor = Colors[rand.Next(Colors.Length - 1)];
                manager.DrawBox(prop.Height, prop.Width, prop.X, prop.Y, prop.LineType, foregroundColor, backgroundColor);
                manager.Redraw();
                Thread.Sleep(500);
            }

            Console.ResetColor();
            Console.ReadKey();
            Console.CursorVisible = true;
        }

        private static IEnumerable<BoxProp> GetRandomBoxProps()
        {
            var rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                BoxProp result = new BoxProp
                {
                    X = rand.Next(Console.WindowHeight - 1),
                    Y = rand.Next(Console.WindowWidth - 1),
                    LineType = (LineType)rand.Next(2)
                };
                
                result.Height = rand.Next(1, Console.WindowHeight - result.X);
                result.Width = rand.Next(1, Console.WindowWidth - result.Y);
                
                yield return result;
            }
        }
    }
}