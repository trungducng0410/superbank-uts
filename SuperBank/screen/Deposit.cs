using System;
using SuperBank.model;
using SuperBank.utils;
namespace SuperBank.screen
{
    public class Deposit
    {
        protected MainMenu mainMenu;

        protected Account account;
        protected string accountInput;

        protected Cursor accountCursor;
        protected Cursor amountCursor;
        protected Cursor errorCursor;

        public Deposit(MainMenu mainMenu)
        {
            this.mainMenu = mainMenu;
        }

        public virtual void ShowInterface()
        {
            Console.Clear();
            Console.WriteLine("\t\t==================================================");
            Console.WriteLine("\t\t|                     DEPOSIT                    |");
            Console.WriteLine("\t\t==================================================");
            Console.WriteLine("\t\t|                ENTER THE DETAILS               |");
            Console.WriteLine("\t\t|                                                |");
            Console.Write("\t\t|    Account Number: ");
            accountCursor = new Cursor();
            if (accountInput != null)
            {
                Console.Write(accountInput);

            }
            UIHelpers.PrintRemainSpace(new Cursor());

            Console.Write("\t\t|    Amount: $");
            amountCursor = new Cursor();
            UIHelpers.PrintRemainSpace(amountCursor);

            Console.WriteLine("\t\t==================================================\n\n");
            errorCursor = new Cursor();

            GetInput();
        }

        protected void GetInput()
        {
            if (accountInput == null)
            {
                GetAccount();
            }

            GetAmount();
        }

        protected void GetAccount()
        {
            Console.SetCursorPosition(accountCursor.x, accountCursor.y);
            accountInput = Console.ReadLine();
            if (!int.TryParse(accountInput, out _) || accountInput.Length > 10)
            {
                Console.SetCursorPosition(errorCursor.x, errorCursor.y);
                Console.WriteLine("The account number must be integer or not more than 10 characters... Press enter");
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    accountInput = null;
                    ShowInterface();
                }
            }

            Console.SetCursorPosition(errorCursor.x, errorCursor.y);
            try
            {
                account = AccountService.SearchAccountByAccountNumber(accountInput);
                Console.WriteLine("Account found! Enter the amount");
            }
            catch (Exception)
            {
                Console.WriteLine("Account not found!");
                Retry();
            }
        }

        protected virtual void GetAmount()
        {
            Console.SetCursorPosition(amountCursor.x, amountCursor.y);
            string sAmount = Console.ReadLine();
            Console.SetCursorPosition(errorCursor.x, errorCursor.y + 1);
            if (!int.TryParse(sAmount, out int amount) || amount < 0)
            {
                Console.WriteLine("Invalid amount... Press enter");
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    ShowInterface();
                }
            }
            else
            {
                account.Deposit(amount);
                Console.WriteLine("Deposit successful! Go back to main menu... Press enter");
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    accountInput = null;
                    mainMenu.ShowMainMenu();
                }
            }
        }

        protected void Retry()
        {
            Console.Write("Retry (y - default/n)? ");
            accountInput = null;
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
