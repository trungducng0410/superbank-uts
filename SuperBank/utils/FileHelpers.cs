using System;
using System.IO;

namespace SuperBank.utils
{
    public class FileHelpers
    {
        public static string GetAccountFilePath(string accountNumber)
        {
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFolder = Path.Combine(sCurrentDirectory, @"../../../data/accounts/");
            string sFolderPath = Path.GetFullPath(sFolder);
            string sFilePath = sFolderPath + $"{accountNumber}.txt";
            return sFilePath;
        }
    }
}
