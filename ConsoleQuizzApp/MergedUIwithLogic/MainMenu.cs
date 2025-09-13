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
            Console.Clear();
            Console.CursorVisible = false;
            int position = 0;
            string[] options = { "Play", "Settings", "Exit" };

            ConsoleKey key;
            do
            {
                int column = 58;
                int row = 20;
                Console.Clear();
                for (int i = 0; i < options.Length; i++)
                {
                    if (i == position)
                    {
                        Console.SetCursorPosition(58, 20 + i);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write($"{options[i]} <");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.SetCursorPosition(58, 20 + i);

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
