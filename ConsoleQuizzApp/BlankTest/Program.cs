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
            Console.ResetColor();
            int question = 15;
            ProgressGraph(question);
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

        public static void ProgressGraph(int question)
        {
            string[] graph = { "\t\t\t\t\t\t\t\t15      $1 000 000  ",
                               "\r\n\t\t\t\t\t\t\t\t\t\t14      $500 000   ",
                               "\r\n \t\t\t\t\t\t\t\t\t\t13      $250 000   ",
                               "\r\n \t\t\t\t\t\t\t\t\t\t12      $125 000   ",
                               "\r\n\t\t\t\t\t\t\t\t\t\t11      $64 000   ",
                               "\r\n\t\t\t\t\t\t\t\t\t\t10      $32 000   ",
                               "\r\n\t\t\t\t\t\t\t\t\t\t 9      $16 000   ",
                               "\r\n\t\t\t\t\t\t\t\t\t\t 8      $8000      ",
                               "\r\n\t\t\t\t\t\t\t\t\t\t 7      $4000      ",
                               "\r\n\t\t\t\t\t\t\t\t\t\t 6      $2000      ",
                               "\r\n\t\t\t\t\t\t\t\t\t\t 5      $1000      ",
                               "\r\n\t\t\t\t\t\t\t\t\t\t 4      $500        ",
                               "\r\n\t\t\t\t\t\t\t\t\t\t 3      $300        ",
                               "\r\n\t\t\t\t\t\t\t\t\t\t 2      $200        ",
                               "\r\n\t\t\t\t\t\t\t\t\t\t 1      $100        \n"
            };
            for (int i = 0; i < 15; i++)
            {
                int[] whiteColored = { 15, 10, 5 };
                if (whiteColored.Contains(15 - i))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                if (question == 15 - i)
                {
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.Write(graph[i]);
                Console.ResetColor();
            }
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("\t\t\t    ● ● ● ● ● ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("● ● ● ● ● ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("● ● ● ● ● ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("● ● ● ● ● ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("● ● ● ● ● ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("● ● ● ● ●");
            Console.ResetColor();
            Console.WriteLine("\n\n—---------------------------{              What is the capital of France?             }-----------------------------\r\n");
            Console.WriteLine("\t◆ A:  London\t\t\t\t       ◆ B:  Berlin\n");
            Console.WriteLine("\t◆ C:  Sofia\t\t\t\t       ◆ D:  Paris\r\n");
            TimeRemover();
            Console.SetCursorPosition(0, 27);
            //foreach (var question in )
            //{

            //}
        }

        public static void TimeRemover()
        {
            Thread.Sleep(2000);
            int cursorColumn = 28;
            int cursorRow = 17;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.CursorVisible = false;
            bool tick = true;
            for (int i = 0; i < 30; i++)
            {
                Console.SetCursorPosition(cursorColumn, cursorRow);
                Console.Write("○");
                cursorColumn += 2;
                tick = tick == true ? false : true;
                if (!tick)
                {
                    Console.Beep(1661, 200);
                }
                else
                {

                    Console.Beep(1479, 200);
                }
                //g#6 1661, f#6 1479
                Thread.Sleep(800);
            }

        }


    }
}
