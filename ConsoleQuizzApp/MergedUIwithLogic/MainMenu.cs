using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp
{
    internal class MainMenu
    {
        public static void MainMenuShow()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Clear();
            Console.CursorVisible = false;
            MakeFrame();
            ShowMenuItems();
        }

        public static void ShowMenuItems()
        {
            ConsoleKey key;

            int position = 0;
            string[] options = { "Play", "Guide", "Exit" };

            do
            {
                int column = 54;
                int row = 14;
                Console.Clear();
                for (int i = 0; i < options.Length; i++)
                {
                    if (i == position)
                    {
                        Console.SetCursorPosition(column, row + i);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write($"{options[i]} <");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.SetCursorPosition(column, row + i);

                        Console.Write(options[i]);
                    }
                }

                key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow && position > 0)
                {
                    position--;
                }
                else if (key == ConsoleKey.DownArrow && position < options.Length - 1)
                {
                    position++;
                }

            } while (key != ConsoleKey.Enter);
            switch (position)
            {
                case 0:
                    break;
                case 1:
                    ShowGuide();
                    break;
                case 2:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }

        private static void ShowGuide()
        {
            Console.Clear();
            Console.WriteLine("You have your jokers on the top left, to use type \"1\", \"2\", \"3\" or \"4\" and press ENTER ⏎");
            Console.WriteLine("To answer a question press a, b, c or d and ENTER ⏎");
            Console.WriteLine("To leave early you can press \"e\" and ENTER ⏎, you will earn the amount from the last question");
            Console.WriteLine("If your answer is not correct, you will recieve the amount from the safety net (if you passed it), safety net questions are colored white");
            Console.WriteLine("Press ENTER ⏎ to continue");
            ConsoleKey key;
            do
            {
                key = Console.ReadKey(true).Key;
            } while (key != ConsoleKey.Enter);
            ShowMenuItems();
        }

        public static void MakeFrame()
        {
            ConsoleKey key;

            Console.Write("▓▓");
            Console.Write(new string(' ', 116));
            Console.Write("▓▓");
            Console.WriteLine();
            Console.Write("▓");

            Console.Write(new string(' ', 118));
            Console.Write("▓");
            Console.SetCursorPosition(0, 27);
            Console.WriteLine();
            Console.Write("▓");
            Console.Write(new string(' ', 118));
            Console.Write("▓");
            Console.WriteLine();

            Console.Write("▓▓");
            Console.Write(new string(' ', 116));
            Console.Write("▓▓");
            Console.SetCursorPosition(30, 15);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Make sure your consoles screen is in the indicated area!");
            Console.SetCursorPosition(45, 18);
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Press ENTER ⏎ To Continue");
            do
            {
                key = Console.ReadKey(true).Key;

            } while (key != ConsoleKey.Enter);
        }
    }

}
