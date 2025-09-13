using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergedUIwithLogic
{
    internal class MainMenu
    {
        public static void MainMenuShow()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Clear();
            Console.CursorVisible = false;
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

            ConsoleKey consoleKey;
            Console.SetCursorPosition(30, 15);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Make sure your consoles screen is in the indicated area!");
            Console.SetCursorPosition(45, 18);
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Press ENTER ⏎ To Continue");
            do
            {
                consoleKey = Console.ReadKey(true).Key;
                
            } while (consoleKey != ConsoleKey.Enter);
            
            int position = 0;
            string[] options = { "Play", "Guide", "Exit" };

            ConsoleKey key;
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

            Console.WriteLine($"You selected: {options[position]}");
        }
        public static void MakeFrame()
        {
            // * 114 *
            // some rows down
            // * 114 *
        }
    }

}
