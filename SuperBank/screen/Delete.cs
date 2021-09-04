using System;
using SuperBank.model;
using SuperBank.utils;
namespace SuperBank.screen
{
    public class Delete: SearchAccount
    {
        public Delete(MainMenu mainMenu) : base(mainMenu)
        {
            this.mainMenu = mainMenu;
        }

        public override void ShowInterface()
        {
            Console.Clear();
            Console.WriteLine("\t\t==================================================");
            Console.WriteLine("\t\t|                DELETE AN ACCOUNT               |");
            Console.WriteLine("\t\t==================================================");
            Console.WriteLine("\t\t|                ENTER THE DETAILS               |");
            Console.WriteLine("\t\t|                                                |");
            Console.Write("\t\t|    Account number: ");
            inputCuror = new Cursor();
            Console.WriteLine("\t\t\t\t |");
            Console.WriteLine("\t\t==================================================\n\n");
            errorCursor = new Cursor();

            GetInput();
        }

        protected override void Search(string accountNumber)
        {
            try
            {
                Account account = AccountService.SearchAccountByAccountNumber(accountNumber);
                Console.WriteLine("\n\nAccount found! Details displayed below...");
                account.PrintToConsole();
                Console.Write("Delete (y/n - default) ");
                string choice = Console.ReadLine();
                if (choice.Equals("y"))
                {
                    FileHelpers.DeleteFile(account.GetAccountNumber());
                    Console.WriteLine("Account deleted!...");
                }
                ContinueToSearch();
            }
            catch (Exception)
            {
                Console.SetCursorPosition(errorCursor.x, errorCursor.y);
                Console.WriteLine("Account not found!");
                ContinueToSearch();
            }
        }
    }
}
