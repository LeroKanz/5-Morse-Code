using System;

namespace MorseCode
{
    class Program
    {
        static void Main(string[] args)
        {
            string textToCode = Translator.TranslateToMorse("TestCase");
            Console.WriteLine(textToCode);

            string codeToText = Translator.TranslateToText(".- -... -.-. -.. . ..-. --. .... .. .--- -.- .-.. ");
            Console.WriteLine(codeToText);
        }
    }
}
