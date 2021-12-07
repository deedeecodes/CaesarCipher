using System;
using System.Text;
using System.Text.RegularExpressions;

namespace CaesarCipher
{
    public class Program
    {
        public static string Encrypt(string message, int key)
        {

            char[] encryptedMessage = new char[message.Length];

            for (int i = 0; i < message.Length; i++)
            {
                if (Char.IsLetter(message[i]))
                {
                    encryptedMessage[i] = message[i] >= 97 ? (char)('a' + (message[i] + key - 'a') % 26) : (char)('A' + (message[i] + key - 'A') % 26);
                }
                else
                {
                    encryptedMessage[i] = message[i];
                }
            }

            return String.Join("", encryptedMessage);
        }

        public static string Decrypt(string message, int key)
        {
            char[] decryptedMessage = new char[message.Length];

            for (int i = 0; i < message.Length; i++)
            {
                if (Char.IsLetter(message[i]))
                {
                    decryptedMessage[i] = message[i] >= 97 ? (char)('a' + (message[i] + 26 - key - 'a') % 26) : (char)('A' + (message[i] + 26 - key - 'A') % 26);
                }
                else
                {
                    decryptedMessage[i] = message[i];
                }
            }

            return String.Join("", decryptedMessage);
        }

        public static void Main(string[] args)
        {
            bool exitMenu = false;

            while(exitMenu == false)
            {
                Console.WriteLine("Welcome to your own Caesar's Cipher tool!");
                Console.WriteLine("Choose your action:\n 1. ENCRYPT a message\n 2. DECRYPT a message\n 3. EXIT");
                string option = Console.ReadLine().ToUpper();

                switch(option)
                {
                    case "ENCRYPT":
                        Console.Write("Your message: ");
                        string encryptMessage = Console.ReadLine();
                        Console.Write("Your key (a number): ");
                        int encryptKey = Int32.Parse(Console.ReadLine());
                        Console.WriteLine($"\n\nYour message was encrypted to:\n {Encrypt(encryptMessage, encryptKey)}\n\n");
                        break;
                    case "DECRYPT":
                        Console.Write("Your message: ");
                        string decryptMessage = Console.ReadLine();
                        Console.Write("Your key (a number): ");
                        int decryptKey = Int32.Parse(Console.ReadLine());
                        Console.WriteLine($"\nYour message was decrypted to:\n {Decrypt(decryptMessage, decryptKey)}\n\n");
                        break;
                    case "EXIT":
                        exitMenu = true;
                        break;
                    default:
                        Console.WriteLine("Please choose a valid option. \"ENCRYPT\" , \"DECRYPT\" or \"EXIT\"!!\n\n");
                        break;
                }
            }
        }
    }
}
