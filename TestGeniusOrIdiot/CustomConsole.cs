using System;
using System.Collections.Generic;
using System.Text;

namespace TestGeniusOrIdiot
{
    internal static class CustomConsole
    {
        public static void ErrorLine(object message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
        }
        public static void Error(object message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(message);
        }

        public static void SuccessLine(object message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
        }
        public static void Success(object message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(message);
        }

        public static void MessageLine(object message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
        }
        public static void Message(object message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(message);
        }

        public static void QuestionLine(object message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(message);
        }
        public static void Question(object message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(message);
        }

        public static void InfoLine(object message)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(message);
        }
        public static void Info(object message)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(message);
        }

        public static void Title(object message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"|{message?.ToString()?.ToUpper()}|");
        }

        public static void SkipLine()
        {
            Console.WriteLine();
        }
        public static void SkipLines(int count)
        {
            for(int i = 0; i < count; i++) Console.WriteLine();
        }

        public static string ReadInput()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            return Console.ReadLine() ?? "";
        }

        public static void Clear()
        {
            Console.Clear();
        }

        public static void ReadKey()
        {
            Console.ReadKey();
        }
    }
}
