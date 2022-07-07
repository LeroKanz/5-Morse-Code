using System;
using System.Globalization;
using System.Text;

namespace MorseCode
{
    public static class Translator
    {
        public static string TranslateToMorse(string message)
        {
            if (message is null)
            {
                throw new ArgumentNullException(nameof(message));
            }
            StringBuilder morse = new StringBuilder();
            WriteMorse(MorseCode.CodeTable, message, morse);

            return morse.ToString();
        }

        public static string TranslateToText(string morseMessage)
        {
            if (morseMessage is null)
            {
                throw new ArgumentNullException(nameof(morseMessage));
            }
            StringBuilder text = new StringBuilder();
            WriteText(MorseCode.CodeTable, morseMessage, text);

            return text.ToString();
        }

        public static void WriteMorse(char[][] codeTable, string message, StringBuilder morseMessageBuilder, char dot = '.', char dash = '-', char separator = ' ')
        {
            if (codeTable is null)
            {
                throw new ArgumentNullException(nameof(codeTable));
            }

            if (message is null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            if (morseMessageBuilder is null)
            {
                throw new ArgumentNullException(nameof(morseMessageBuilder));
            }

            if (string.IsNullOrEmpty(message))
            {
                morseMessageBuilder.Append(' ');
            }

            char[] wordSpliter = new char[] { ' ', '-', ',', '*', '.', '!', '\t', '?', ':' };
            var cleanMessage = message.Split(wordSpliter, StringSplitOptions.RemoveEmptyEntries);
            var newMessage = string.Concat(cleanMessage);

            for (int i = 0; i < newMessage.Length; i++)
            {
                for (int j = 0; j < codeTable.Length; j++)
                {
                    if (char.ToUpper(newMessage[i], CultureInfo.CurrentCulture) == codeTable[j][0])
                    {
                        for (int k = 1; k < codeTable[j].Length; k++)
                        {
                            morseMessageBuilder.Append(codeTable[j][k]);
                        }

                        morseMessageBuilder.Append(' ');
                        break;
                    }
                }
            }

            morseMessageBuilder.Remove(morseMessageBuilder.Length - 1, 1);

            if (dot != '.')
            {
                morseMessageBuilder.Replace('.', dot);
            }

            if (dash != '-')
            {
                morseMessageBuilder.Replace('-', dash);
            }

            if (separator != ' ')
            {
                morseMessageBuilder.Replace(' ', separator);
            }
        }

        public static void WriteText(char[][] codeTable, string morseMessage, StringBuilder messageBuilder, char dot = '.', char dash = '-', char separator = ' ')
        {
            if (codeTable is null)
            {
                throw new ArgumentNullException(nameof(codeTable));
            }

            if (morseMessage is null)
            {
                throw new ArgumentNullException(nameof(morseMessage));
            }

            if (messageBuilder is null)
            {
                throw new ArgumentNullException(nameof(messageBuilder));
            }

            if (string.IsNullOrEmpty(morseMessage))
            {
                messageBuilder.Clear();
            }

            if (separator != ' ')
            {
                morseMessage = morseMessage.Replace(separator, ' ');
            }

            if (dot != '.')
            {
                morseMessage = morseMessage.Replace(dot, '.');
            }

            if (dash != '-')
            {
                morseMessage = morseMessage.Replace(dash, '-');
            }

            string[] mosreLetter = morseMessage.Split(' ');

            for (int i = 0; i < mosreLetter.Length; i++)
            {
                for (int j = 0; j < codeTable.Length; j++)
                {
                    string codeInTable = string.Concat(codeTable[j]);
                    if (mosreLetter[i] == codeInTable[1..^0])
                    {
                        messageBuilder.Append(codeTable[j][0]);

                        break;
                    }
                }
            }
        }
    }
}
