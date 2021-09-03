﻿using System;
namespace SuperBank.screen
{
    public class MainMenu
    {
        private Login login;
        private CreateAccount createAccount;

        private int inputCurorX;
        private int inputCurorY;
        private int errorCursorX;
        private int errorCursorY;

        public MainMenu(Login login)
        {
            this.login = login;
            createAccount = new CreateAccount(this);
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
            inputCurorY = Console.CursorTop;
            Console.WriteLine("\t\t |");
            Console.WriteLine("\t\t==================================================");
            Console.WriteLine("\n");
            Console.Write("\t\t");
            errorCursorY = Console.CursorTop;
            errorCursorX = Console.CursorLeft;

            Console.SetCursorPosition(inputCurorX, inputCurorY);
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
                        Console.WriteLine("Search");
                        break;
                    case 3:
                        Console.WriteLine("Deposit");
                        break;
                    case 4:
                        Console.WriteLine("Withdraw");
                        break;
                    case 5:
                        Console.WriteLine("A/C statement");
                        break;
                    case 6:
                        Console.WriteLine("Delete account");
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
            Console.SetCursorPosition(errorCursorX, errorCursorY);
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
