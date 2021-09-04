using System;
using SuperBank.model;
using SuperBank.utils;
namespace SuperBank.screen
{
    public class Withdraw
    {
        private MainMenu mainMenu;

        private Account account;
        private string accountInput;

        private Cursor accountCursor;
        private Cursor amountCursor;
        private Cursor errorCursor;

        public Withdraw(MainMenu mainMenu)
        {
            this.mainMenu = mainMenu;
        }

        public void ShowInterface()
        {
            Console.Clear();
            Console.WriteLine("\t\t==================================================");
            Console.WriteLine("\t\t|                     WITHDRAW                   |");
            Console.WriteLine("\t\t==================================================");
            Console.WriteLine("\t\t|                 ENTER THE DETAILS              |");
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

        private void GetInput()
        {
            if (accountInput == null)
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

            Console.SetCursorPosition(amountCursor.x, amountCursor.y);
            string sAmount = Console.ReadLine();
            Console.SetCursorPosition(errorCursor.x, errorCursor.y + 1);
            if (!int.TryParse(sAmount, out int amount) || amount <= 0)
            {
                Console.WriteLine("Invalid amount... Press enter");
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    ShowInterface();
                }
            }
            else
            {
                try
                {
                    account.Withdraw(amount);
                    Console.WriteLine("Withdraw successful! Go back to main menu... Press enter");
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        accountInput = null;
                        mainMenu.ShowMainMenu();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Your balance is not enough to withdraw... Try smaller amount");
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        ShowInterface();
                    }
                }

            }
        }

        private void Retry()
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
