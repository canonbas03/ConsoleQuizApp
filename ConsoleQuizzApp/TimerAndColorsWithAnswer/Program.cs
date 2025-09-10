using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleQuizzApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            // Example questions
            List<Question> questions = new List<Question>
            {
                new Question
                {
                    Text = "2 + 2 = ?",
                    Options = new[] { "3", "4", "5", "6" },
                    CorrectOption = "b"
                },
                new Question
                {
                    Text = "Capital of France?",
                    Options = new[] { "London", "Berlin", "Paris", "Rome" },
                    CorrectOption = "c"
                }
            };

            int score = 0;
            int questionNumber = 1;
            string[] optionFormat = { "   a. ", "   b. ", "   c. ", "   d. " };

            foreach (var quest in questions)
            {
                Console.Clear();

                // Reserve row 0 for the timer
                Console.WriteLine("Time left: 10 seconds");

                // Print question and answers below
                Console.WriteLine($"{questionNumber}. {quest.Text}");
                for (int i = 0; i < quest.Options.Length; i++)
                {
                    Console.WriteLine(optionFormat[i] + quest.Options[i]);
                }

                Console.Write("\nYour Answer: ");

                var cts = new CancellationTokenSource();
                var token = cts.Token;

                // Input task
                var inputTask = Task.Run(() => Console.ReadLine());

                // Timer task with cancellation support
                var timerTask = Task.Run(() =>
                {
                    for (int i = 10; i >= 0; i--)
                    {
                        if (token.IsCancellationRequested) break; // stop early

                        int curLeft = Console.CursorLeft;
                        int curTop = Console.CursorTop;

                        Console.SetCursorPosition(0, 0);
                        Console.ForegroundColor = i > 5 ? ConsoleColor.Green : ConsoleColor.Red;
                        Console.Write($"Time left: {i} seconds   ");
                        Console.ResetColor();

                        Console.SetCursorPosition(curLeft, curTop);

                        Thread.Sleep(1000);
                    }
                    return (string)null;
                }, token);

                // Wait for whichever finishes first
                var finished = Task.WhenAny(inputTask, timerTask).Result;
                string answer = finished == inputTask ? inputTask.Result : null;

                // Cancel timer so it stops writing
                cts.Cancel();

                Console.ResetColor();
                Console.WriteLine();

                if (answer == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("⏰ Time's up!");
                    Console.ResetColor();
                    break;
                }
                else if (quest.IsCorrect(answer))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("✅ Correct!");
                    Console.ResetColor();
                    score++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("❌ WRONG!");
                    Console.ResetColor();
                    break;
                }

                questionNumber++;
                Thread.Sleep(1500);
            }


            Console.ResetColor();
            Console.WriteLine();
            if (score == questions.Count)
            {
                Console.WriteLine("🎉 YOU WON!!!");
            }
            else
            {
                Console.WriteLine("👋 GOOD BYE!");
            }
        }
    }

    internal class Question
    {
        public string Text { get; set; }
        public string[] Options { get; set; }
        public string CorrectOption { get; set; } // "a", "b", "c", "d"

        public bool IsCorrect(string userAnswer)
        {
            return string.Equals(
                userAnswer?.Trim().ToLower(),
                CorrectOption.ToLower(),
                StringComparison.OrdinalIgnoreCase
            );
        }
    }
}
