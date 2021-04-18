using System;
using System.IO;

namespace CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            int key;
            string choice;
            string input;
            string message;
            Cipher cipher = new Cipher();
            Load.Words(Path.GetFullPath("Words.txt"));

            Console.WriteLine("Enter message in file: " + Path.GetFullPath("Message.txt"));
            message = Load.Message(Path.GetFullPath("Message.txt"));

            do
            {
                Console.WriteLine("Enter one of the following options:");
                Console.WriteLine("\tE - ENCRYPT");
                Console.WriteLine("\tD - DECRYPT");
                input = Console.ReadLine();
                choice = input.ToUpper();
            } while (choice is not ("D" or "E"));

            do
            {
                Console.WriteLine("Enter key or -1 if unknown:");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out key));

            switch (choice)
            {
                case "D":
                    message = cipher.Decrypt(key, message);
                    break;
                case "E":
                    message = cipher.Encrypt(key, message);
                    break;
            }

            Console.WriteLine(message);
        }
    }
}
