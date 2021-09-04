using System;
namespace SuperBank.model
{
    public class Cursor
    {
        public int x;
        public int y;

        public Cursor()
        {
            x = Console.CursorLeft;
            y = Console.CursorTop;
        }
    }
}
