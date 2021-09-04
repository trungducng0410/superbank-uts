using System;
using SuperBank.model;
using SuperBank.utils;
namespace SuperBank.screen
{
    public class Withdraw : Deposit
    {
        public Withdraw(MainMenu mainMenu) : base(mainMenu)
        {
            this.mainMenu = mainMenu;
        }

        public override void ShowInterface()
        {
            Console.Clear();
            Console.WriteLine("\t\t==================================================");
            Console.WriteLine("\t\t|                    WITHDRAW                    |");
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

        protected override void GetAmount()
        {
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
    }
}
