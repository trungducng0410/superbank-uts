using System;
using SuperBank.model;
using SuperBank.utils;
namespace SuperBank.screen
{
    public class SearchAccount
    {
        protected MainMenu mainMenu;

        protected Cursor inputCuror;
        protected Cursor errorCursor;

        public SearchAccount(MainMenu mainMenu)
        {
            this.mainMenu = mainMenu;
        }

        public virtual void ShowInterface()
        {
            Console.Clear();
            Console.WriteLine("\t\t==================================================");
            Console.WriteLine("\t\t|                SEARCH AN ACCOUNT               |");
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

        protected void GetInput()
        {
            Console.SetCursorPosition(inputCuror.x, inputCuror.y);
            string accountNumber = Console.ReadLine();
            if (!int.TryParse(accountNumber, out _) || accountNumber.Length > 10)
            {
                Console.SetCursorPosition(errorCursor.x, errorCursor.y);
                Console.WriteLine("The account number must be integer or not more than 10 characters... Press enter");
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    ShowInterface();
                }
            }

            Search(accountNumber);
        }

        protected virtual void Search(string accountNumber)
        {
            try
            {
                Account account = AccountService.SearchAccountByAccountNumber(accountNumber);
                Console.WriteLine("\n\nAccount found!");
                account.PrintToConsole();
                ContinueToSearch();
            }
            catch (Exception)
            {
                Console.SetCursorPosition(errorCursor.x, errorCursor.y);
                Console.WriteLine("Account not found!");
                ContinueToSearch();
            }
        }

        protected void ContinueToSearch()
        {
            Console.Write("Check another account (y - default/n)? ");
            string choice = Console.ReadLine();
            if (choice.Equals("n"))
            {
                mainMenu.ShowMainMenu();
            }
            else
            {
                ShowInterface();
            }
        }
    }
}
