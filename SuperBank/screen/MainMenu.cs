using System;
namespace SuperBank.screen
{
    public class MainMenu
    {

        private int inputCurorX;
        private int inputCurorY;
        private int errorCursorX;
        private int errorCursorY;

        public MainMenu()
        {
        }

        public void ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine("\t\t==================================================");
            Console.WriteLine("\t\t|          WELCOME TO SUPER BANK SYSTEM          |");
            Console.WriteLine("\t\t==================================================");
            Console.WriteLine("\t\t|    1. Create a new account                     |");
            Console.WriteLine("\t\t|    2. Search for an account                    |");
            Console.WriteLine("\t\t|    3. Deposit                                  |");
            Console.WriteLine("\t\t|    4. Withdraw                                 |");
            Console.WriteLine("\t\t|    5. A/C statement                            |");
            Console.WriteLine("\t\t|    6. Delete account                           |");
            Console.WriteLine("\t\t|    7. Exit                                     |");
            Console.WriteLine("\t\t==================================================");
            Console.Write("\t\t|\t Enter your choice (1-7): ");
            inputCurorX = Console.CursorLeft;
            inputCurorY = Console.CursorTop - 1;
            Console.WriteLine("\t\t |");
            Console.WriteLine("\t\t==================================================");
            Console.WriteLine("\n");
            Console.Write("\t\t");
            errorCursorY = Console.CursorTop - 1;
            errorCursorX = Console.CursorLeft;

            Console.SetCursorPosition(inputCurorX, inputCurorY);
            string choice = Console.ReadLine();
            ValidateChoice(choice);
        }

        private void ValidateChoice(string choice)
        {
            Console.WriteLine("Valid choice");
        }
    }
}
