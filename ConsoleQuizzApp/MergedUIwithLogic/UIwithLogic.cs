using ConsoleQuizzApp;
using BlankTest;

namespace MergedUIwithLogic
{
    internal class UIwithLogic
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            List<Question> questions = QuizData.Questions.ToList();
            bool ViewerUsed = false;
            bool TelephoneUsed = false;
            bool FiftyUsed = false;
            bool TwoAnswerUsed = false;
            bool jokerIsUsed = false;
            Joker.JokerInitialCreate();

            string input;
            int score = 0;
            int questionNumber = 1;
            string[] walidAnswers = new[] { "a", "b", "c", "d" };

            foreach (var quest in questions)
            {

                //  START OF SECOND
                Console.Clear();
                Joker.JokerCreate(ViewerUsed, TelephoneUsed, FiftyUsed, TwoAnswerUsed);
                ProgressGraph(questionNumber);
                WriteQuestion(quest);


                Console.Write("\nYour Answer: ");
                

                var cts = new CancellationTokenSource();
                var token = cts.Token;

                // Input task
                var inputTask = Task.Run(() =>
                {
                    do
                    {
                        string message = string.Empty;
                        input = Console.ReadLine();
                        if (input == "1")
                        {
                            if (ViewerUsed)
                            {
                                Warning("Viewer joker is already used!");
                                //continue;
                                continue;
                            }
                            ViewerUsed = true;
                            jokerIsUsed = true;
                            Joker.JokerCreate(ViewerUsed, TelephoneUsed, FiftyUsed, TwoAnswerUsed);
                            break;
                        }
                        else if (input == "2")
                        {
                            if (TelephoneUsed)
                            {
                                Warning("Telephone joker is already used!");
                                continue;
                            }
                            TelephoneUsed = true;
                            jokerIsUsed = true;
                            Joker.JokerCreate(ViewerUsed, TelephoneUsed, FiftyUsed, TwoAnswerUsed);
                            break;
                        }
                        else if (input == "3")
                        {
                            if (FiftyUsed)
                            {
                                Warning("50:50 joker is already used!");
                                continue;
                            }
                            FiftyUsed = true;
                            jokerIsUsed = true;
                            Joker.JokerCreate(ViewerUsed, TelephoneUsed, FiftyUsed, TwoAnswerUsed);
                            break;
                        }
                        else if (input == "4")
                        {
                            if (TwoAnswerUsed)
                            {
                                Warning("x2 joker is already used!");
                                continue;
                            }
                            TwoAnswerUsed = true;
                            jokerIsUsed = true;
                            Joker.JokerCreate(ViewerUsed, TelephoneUsed, FiftyUsed, TwoAnswerUsed);
                            break;
                        }
                        else if (walidAnswers.Contains(input))
                        {
                            //Console.WriteLine(quest.IsCorrect(input));
                            questionNumber++;
                            break;
                        }
                        else
                        {
                            Warning("Invalid choice!");
                        }
                    } while (true);
                    Console.Clear();
                    return input;
                }, token);
                // Timer task with cancellation support
                var timerTask = Task.Run(() =>
                {

                    Thread.Sleep(0);
                    int cursorColumn = 28;
                    int cursorRow = 17;
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.CursorVisible = false;
                    bool tick = true;
                    for (int i = 0; i < 10; i++)
                    {
                        if (token.IsCancellationRequested) break; // stop early
                        Console.SetCursorPosition(cursorColumn, cursorRow);
                        Console.Write("○");
                        Console.SetCursorPosition(13, 25);
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

                }, token);

                // Wait for whichever finishes first
                var finished = Task.WhenAny(inputTask, timerTask).Result;
                string answer = finished == inputTask ? inputTask.Result : null;

                // Cancel timer so it stops writing
                cts.Cancel();

                Console.ResetColor();
                Console.WriteLine();

                if(jokerIsUsed)
                {
                    jokerIsUsed = false;
                    continue;
                }
                if (answer == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("⏰ Time's up!");
                    Console.ResetColor();
                    break;
                }
                else if (quest.IsCorrect(answer))
                {
                    score++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("❌ WRONG!");
                    Console.ResetColor();
                    break;
                }

                //questionNumber++;
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

        private static void WriteQuestion(Question quest)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(quest.Text);
            Console.WriteLine($"\t◆ A:  {quest.Options[0]}\t\t\t\t       ◆ B:  {quest.Options[1]}\n");
            Console.WriteLine($"\t◆ C:  {quest.Options[2]}\t\t\t\t       ◆ D:  {quest.Options[3]}\r\n");
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
        }

        public static void TimeRemover()
        {
            Thread.Sleep(0);
            int cursorColumn = 28;
            int cursorRow = 17;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.CursorVisible = false;
            bool tick = true;
            for (int i = 0; i < 3; i++)
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
