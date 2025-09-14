using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlankTest
{
    internal class Joker
    {
        public static string[] JokerModel(string name, bool isUsed)
        {
            string[] used = { "╭──╮", "|❌|", "╰──╯" };

            if (name == "Viewers" && !isUsed)
                return new[] { "╭──╮", "|👥│", "╰──╯" };
            else if (name == "Telephone" && !isUsed)
                return new[] { "╭──╮", "|📞│", "╰──╯" };
            else if (name == "Fifty" && !isUsed)
                return new[] { "╭──╮", "|50│", "╰──╯" };
            else if (name == "TwoAnswer" && !isUsed)
                return new[] { "╭──╮", "|x2|", "╰──╯" };

            return used;
        }

        public static void JokerInitialCreate()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.White;

            string[][] jokers = new string[][]
            {
                Joker.JokerModel("Viewers", false),
                Joker.JokerModel("Telephone", false),
                Joker.JokerModel("Fifty", false),
                Joker.JokerModel("TwoAnswer", false)
            };

            int spacing = 0; // start spacing
            int step = 1;    // how much space to add per frame

            for (int i = 0; i < 5; i++) // animate 5 frames
            {
                //Console.Clear();

                for (int row = 0; row < 3; row++) // 3 rows tall
                {
                    for (int j = 0; j < jokers.Length; j++)
                    {
                        Console.SetCursorPosition(j * spacing, row);
                        Console.Write(jokers[j][row]);
                    }
                }

                spacing += step; // grow spacing
                Thread.Sleep(50);
            }

            Console.SetCursorPosition(0, 5);
            Console.ResetColor();
        }
        public static void JokerCreate(bool viewers, bool telephone, bool fifty, bool twoAnswer)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.White;

            string[][] jokers = new string[][]
            {
                Joker.JokerModel("Viewers", viewers),
                Joker.JokerModel("Telephone", telephone),
                Joker.JokerModel("Fifty", fifty),
                Joker.JokerModel("TwoAnswer", twoAnswer)
            };

            int spacing = 4; // start spacing
            int step = 1;    // how much space to add per frame

            for (int i = 0; i < 5; i++) // animate 5 frames
            {
                //Console.Clear();

                for (int row = 0; row < 3; row++) // 3 rows tall
                {
                    for (int j = 0; j < jokers.Length; j++)
                    {
                        Console.SetCursorPosition(j * spacing, row);
                        Console.Write(jokers[j][row]);
                    }
                }
            }
            Console.ResetColor();
        }
    }
}
