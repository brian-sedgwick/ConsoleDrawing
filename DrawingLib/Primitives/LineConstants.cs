namespace DrawingLib.Primitives
{
    internal static class LineConstants
    {
        // The following arrays have values that are intended to be indexed with the LineType enum.
        public static readonly char[] HorizontalLine = { '═', '─' };
        public static readonly char[] VerticalLine = { '║', '│' };
        public static readonly char[] LowerLeftCorner = { '╚', '└' };
        public static readonly char[] LowerRightCorner = { '╝', '┘' };
        public static readonly char[] UpperLeftCorner = { '╔', '┌' };
        public static readonly char[] UpperRightCorner = { '╗', '┐' };
    }
    
    public enum LineType
    {
        DoubleLine = 0,
        SingleLine = 1
    }
}