using System;
using System.Collections.Generic;
using System.Text;

namespace CaesarCipher
{
    class Cipher
    {
        public string Decrypt(string message)
        {
            string shiftedMessage;
            string[] wordsInMessage;

            for (int key = 1; key <= 26; key++)
            {
                float correctWords = 0;
                shiftedMessage = Encrypt(key, message);
                wordsInMessage = shiftedMessage.Split(' ');
                
                foreach (string word in wordsInMessage)
                {
                    if (Load.WordList.Contains(word))
                        correctWords++;
                }

                if ((correctWords / (float)wordsInMessage.Length) * 100 > 50)
                {
                    return shiftedMessage;
                }
            }

            return null;
        }
        public string Decrypt(int key, string message)
        {
            try
            {
                if (key < 0)
                    return Decrypt(message);

                return Shift(key, message);
            }
            catch
            {
                return null;
            }
        }
        public string Encrypt(int key, string message)
        {
            try
            {
                return Shift(-key, message);
            }
            catch
            {
                return null;
            }
        }
        public string Shift(int shift, string message)
        {
            message = message.ToUpper();
            char[] letters = message.ToCharArray();

            for (int currLetter = 0; currLetter < letters.Length; currLetter++)
            {
                if (letters[currLetter] < 'A' || letters[currLetter] > 'Z')
                    continue;

                char letter = letters[currLetter];

                letter = (char)(letter + shift);

                if (letter < 'A')
                {
                    letter = (char)(letter + 26);
                }
                else if (letter > 'Z')
                {
                    letter = (char)(letter - 26);
                }

                letters[currLetter] = letter;
            }

            message = new string(letters);

            return message;
        }

        public string Message
        { get; set; }
    }
}
