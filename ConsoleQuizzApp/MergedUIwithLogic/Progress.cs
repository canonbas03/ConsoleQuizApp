using ConsoleQuizzApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergedUIwithLogic
{
    internal class Progress
    {
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
            Console.WriteLine("\n\n");
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
        }
        public static void ResultMarker(char answer, Question question)
        {
            int collumn = 0;
            int row = 0;
            switch (answer)
            {
                case 'a':
                    collumn = 28;
                    row = 24;
                    break;
                case 'b':
                    collumn = 61;
                    row = 24;
                    break;
                case 'c':
                    collumn = 28;
                    row = 26;
                    break;
                case 'd':
                    collumn = 61;
                    row = 26;
                    break;
                default:
                    break;
            }
                    ;
            int questionIndex = answer - 'a';
            //string optionToWrite = question.Options[2];
            Console.SetCursorPosition(collumn, row);
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write($"  ◆ {char.ToUpper(answer)}: {question.Options[questionIndex]}          ");
            Console.ResetColor();
            Thread.Sleep(3000);
        }
        public static void CorrectAnswerShower(Question question)
        {
            int collumn = 0;
            int row = 0;
            char correctOption = question.CorrectOption;
            switch (correctOption)
            {
                case 'a':
                    collumn = 28;
                    row = 24;
                    break;
                case 'b':
                    collumn = 61;
                    row = 24;
                    break;
                case 'c':
                    collumn = 28;
                    row = 26;
                    break;
                case 'd':
                    collumn = 61;
                    row = 26;
                    break;
                default:
                    break;
            }
                    ;
            int questionIndex = correctOption - 'a';
            //string optionToWrite = question.Options[2];
            Console.SetCursorPosition(collumn, row);
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"  ◆ {char.ToUpper(correctOption)}: {question.Options[questionIndex]}          ");
            Thread.Sleep(200);
            Console.SetCursorPosition(collumn, row);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"  ◆ {char.ToUpper(correctOption)}: {question.Options[questionIndex]}          ");
            Thread.Sleep(200);
            Console.SetCursorPosition(collumn, row);
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"  ◆ {char.ToUpper(correctOption)}: {question.Options[questionIndex]}          ");
            Thread.Sleep(200);
            Console.SetCursorPosition(collumn, row);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"  ◆ {char.ToUpper(correctOption)}: {question.Options[questionIndex]}          ");
            Thread.Sleep(200);
            Console.SetCursorPosition(collumn, row);
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"  ◆ {char.ToUpper(correctOption)}: {question.Options[questionIndex]}          ");
            Console.ResetColor();
            Thread.Sleep(0);
        }
        public static string TimeRemover(CancellationToken token)
        {
            Thread.Sleep(2000);
            int cursorColumn = 28;
            int cursorRow = 20;
            Console.CursorVisible = false;
            bool tick = true;
            for (int i = 0; i < 10; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                if (token.IsCancellationRequested) break; // stop early
                Console.SetCursorPosition(cursorColumn, cursorRow);
                Console.Write("○");
                Console.SetCursorPosition(13, 28);
                Console.ForegroundColor = ConsoleColor.Yellow;
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
            return (string)null;
        }
    }
}
