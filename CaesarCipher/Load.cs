using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CaesarCipher
{
    static class Load
    {
        private static List<string> wordList = new List<string>();


        public static string Message(string fileName)
        {
            TextReader textIn = new StreamReader(fileName);
            string text = "";
            string input;

            while ((input = textIn.ReadLine()) != null)
            {
                text += input;
            }
            textIn.Close();

            return text;
        }
        
        public static List<string> Words(string fileName)
        {
            TextReader textIn = new StreamReader(fileName);
            string text;

            while ((text = textIn.ReadLine()) != null)
            {
                text = text.ToUpper();
                WordList.Add(text);
            }

            textIn.Close();

            return WordList;
        }

        public static List<string> WordList
        {
            get { return wordList; }
            set { wordList = value; }
        }
    }
}
