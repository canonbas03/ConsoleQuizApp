using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace BlankTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool ViewerUsed = false;
            bool TelephoneUsed = false;
            bool FiftyUsed = false;
            bool TwoAnswerUsed = false;
            Joker.JokerInitialCreate();
            Joker.JokerCreate(ViewerUsed, TelephoneUsed, FiftyUsed, TwoAnswerUsed);
            string input;
            do
            {
                string message = string.Empty;
                input = Console.ReadLine();
                if (input == "1")
                {
                    if (ViewerUsed)
                    {
                        Warning("Viewer joker is already used!");
                        continue;
                    }
                    ViewerUsed = true;
                    Joker.JokerCreate(ViewerUsed, TelephoneUsed, FiftyUsed, TwoAnswerUsed);
                }
                else if (input == "2")
                {
                    if (TelephoneUsed)
                    {
                        Warning("Telephone joker is already used!");
                        continue;
                    }
                    TelephoneUsed = true;
                    Joker.JokerCreate(ViewerUsed, TelephoneUsed, FiftyUsed, TwoAnswerUsed);
                }
                else if (input == "3")
                {
                    if (FiftyUsed)
                    {
                        Warning("50:50 joker is already used!");
                        continue;
                    }
                    FiftyUsed = true;
                    Joker.JokerCreate(ViewerUsed, TelephoneUsed, FiftyUsed, TwoAnswerUsed);
                }
                else if (input == "4")
                {
                    if (TwoAnswerUsed)
                    {
                        Warning("x2 joker is already used!");
                        continue;
                    }
                    TwoAnswerUsed = true;
                    Joker.JokerCreate(ViewerUsed, TelephoneUsed, FiftyUsed, TwoAnswerUsed);
                }
                else
                {
                    Warning("Invalid choice!");
                }
            } while (input != "end");
        }

        public static void Warning(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ResetColor();
        }


    }
}
