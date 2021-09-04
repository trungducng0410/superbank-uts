using System;
using SuperBank.model;
namespace SuperBank.utils
{
    public class UIHelpers
    {
        // 2 tab + 50 character "="
        public const int SCREEN_WIDTH = 66;

        public static void PrintRemainSpace(Cursor cursor)
        {
            for (int i = 0; i < SCREEN_WIDTH - cursor.x - 1; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine("|");
        }

    }
}
