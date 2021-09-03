using System;
using System.Collections.Generic;
using System.IO;
using SuperBank.model;
namespace SuperBank.screen
{
    public class Login
    {
        private MainMenu mainMenu;

        private string usernameInput;
        private string passwordInput;

        private int userNameCursorY;
        private int userNameCursorX;
        private int passwordCursorY;
        private int passwordCursorX;
        private int errorCursorY;
        private int errorCursorX;

        public Login()
        {
            usernameInput = null;
            passwordInput = null;
            mainMenu = new MainMenu(this);
        }

        public void ShowLoginScreen()
        {
            Console.Clear();
            Console.WriteLine("\t\t==================================================");
            Console.WriteLine("\t\t|          WELCOME TO SUPER BANK SYSTEM          |");
            Console.WriteLine("\t\t==================================================");
            Console.WriteLine("\t\t|                LOGIN TO START                  |");
            Console.WriteLine("\t\t|                                                |");
            Console.Write("\t\t|\t Username: ");
            userNameCursorY = Console.CursorTop;
            userNameCursorX = Console.CursorLeft;
            Console.WriteLine("\t\t\t\t |");
            Console.Write("\t\t|\t Password: ");
            passwordCursorY = Console.CursorTop;
            passwordCursorX = Console.CursorLeft;
            Console.WriteLine("\t\t\t\t |");
            Console.WriteLine("\t\t==================================================");
            Console.WriteLine("\n");
            Console.Write("\t\t");
            errorCursorY = Console.CursorTop;
            errorCursorX = Console.CursorLeft;

            Console.SetCursorPosition(userNameCursorX, userNameCursorY);
            usernameInput = Console.ReadLine();
            passwordInput = ReadPassword();

            AttemptLogin();
        }

        private string ReadPassword()
        {
            string tmpPwd = null;
            ConsoleKey key;
            Console.SetCursorPosition(passwordCursorX, passwordCursorY);
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                // Backspace remove * and last character in password variable
                if (key == ConsoleKey.Backspace && tmpPwd.Length > 0)
                {
                    Console.Write("\b \b");
                    tmpPwd = tmpPwd[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    tmpPwd += keyInfo.KeyChar;
                }
            }
            while (key != ConsoleKey.Enter);
            return tmpPwd;
        }

        private void AttemptLogin()
        {
            List<User> users = GetUsers();
            bool notFound = true;
            foreach (User user in users)
            {
                if (user.GetUsername().Equals(usernameInput))
                {
                    notFound = false;
                    if (!user.Validate(usernameInput, passwordInput))
                    {
                        PrintErrorMessage("Invalid credentials");
                    } else
                    {
                        Console.SetCursorPosition(errorCursorX, errorCursorY);
                        Console.WriteLine("Valid credentials!... Please enter");
                        Console.ReadKey();
                        mainMenu.ShowMainMenu();
                    }
                }
            }

            if (notFound)
            {
                PrintErrorMessage("User not found");
            }
        }

        private void PrintErrorMessage(string message)
        {
            Console.SetCursorPosition(errorCursorX, errorCursorY);
            Console.WriteLine($"{message}!... Please enter");
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                usernameInput = null;
                passwordInput = null;
                ShowLoginScreen();
            }
        }

        private List<User> GetUsers()
        {
            List<User> users = new List<User>();
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = Path.Combine(sCurrentDirectory, @"../../../data/credentials/login.txt");
            string sFilePath = Path.GetFullPath(sFile);
            if (File.Exists(sFilePath))
            {
                StreamReader reader = new StreamReader(sFilePath);
                while (reader.Peek() >= 0)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split('|');
                    User user = new User(values[0], values[1]);
                    users.Add(user);
                }
                reader.Close();
            }
            return users;
        }
    }
}

