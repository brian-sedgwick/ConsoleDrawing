using System;

namespace DrawingLib.Models
{
    internal class CharCoordinate
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char C { get; set; }
        public ConsoleColor ForegroundColor { get; set; }
        public ConsoleColor BackgroundColor { get; set; }
    }
}