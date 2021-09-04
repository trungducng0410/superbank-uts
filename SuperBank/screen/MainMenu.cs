using System;
using SuperBank.model;
namespace SuperBank.screen
{
    public class MainMenu
    {
        private readonly Login login;
        private readonly CreateAccount createAccount;
        private readonly SearchAccount searchAccount;
        private readonly Deposit deposit;
        private readonly Withdraw withdraw;
        private readonly Statement statement;
        private readonly Delete delete;

        private Cursor inputCursor;
        private Cursor errorCursor;

        public MainMenu(Login login)
        {
            this.login = login;
            createAccount = new CreateAccount(this);
            searchAccount = new SearchAccount(this);
            deposit = new Deposit(this);
            withdraw = new Withdraw(this);
            statement = new Statement(this);
            delete = new Delete(this);
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
            inputCursor = new Cursor();
            Console.WriteLine("\t\t |");
            Console.WriteLine("\t\t==================================================");
            Console.WriteLine("\n");
            Console.Write("\t\t");
            errorCursor = new Cursor();

            Console.SetCursorPosition(inputCursor.x, inputCursor.y);
            string choice = Console.ReadLine();
            ValidateChoice(choice);
        }

        private void ValidateChoice(string choice)
        {
            try
            {
                int select = Convert.ToInt32(choice);

                switch (select)
                {
                    case 1:
                        createAccount.ShowInterface();
                        break;
                    case 2:
                        searchAccount.ShowInterface();
                        break;
                    case 3:
                        deposit.ShowInterface();
                        break;
                    case 4:
                        withdraw.ShowInterface();
                        break;
                    case 5:
                        statement.ShowInterface();
                        break;
                    case 6:
                        delete.ShowInterface();
                        break;
                    case 7:
                        Exit();
                        break;
                    default:
                        PrintErrorMessage();
                        break;
                }
            } catch (Exception)
            {
                PrintErrorMessage();
            }
        }

        private void PrintErrorMessage()
        {
            Console.SetCursorPosition(errorCursor.x, errorCursor.y);
            Console.WriteLine("Please enter number from 1 to 7.");
            Console.ReadKey();
            ShowMainMenu();
        }

        private void Exit()
        {
            login.ShowLoginScreen();
        }
    }
}
