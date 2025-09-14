using ConsoleQuizzApp;
using BlankTest;
using System.Security.Cryptography.X509Certificates;

namespace QuizApp
{
    internal class UIwithLogic
    {
        static void Main(string[] args)
        {
            MainMenu.MainMenuShow();
            Console.CursorVisible = false;
            List<Question> questions = QuizData.Questions.ToList();
            bool ViewerUsed = false;
            bool TelephoneUsed = false;
            bool FiftyUsed = false;
            bool TwoAnswerUsed = false;
            bool jokerIsUsed = false;
            int balance = 0;
            int[] awards = new[] { 100, 200, 300, 500, 1000, 2000, 4000, 8000, 16_000, 32_000, 64_000, 125_000, 250_000, 500_000, 1_000_000 };
            int[] safetyNet = new int[] { 6,11 };
;            Joker.JokerInitialCreate();

            char input;
            //int score = 0;
            int questionNumber = 0;
            char[] walidAnswers = new[] { 'a', 'b', 'c', 'd', 'e' };

            foreach (var quest in questions)
            {
                questionNumber++;
                if(safetyNet.Contains(questionNumber))
                {
                    if(questionNumber == 6)
                    {
                        balance = awards[questionNumber-2];
                    }
                    else if (questionNumber == 11)
                    {
                        balance = awards[questionNumber - 2];
                    }
                }
                Console.Clear();

                Joker.JokerCreate(ViewerUsed, TelephoneUsed, FiftyUsed, TwoAnswerUsed);
                Progress.ProgressGraph(questionNumber);

                WriteQuestion(quest);
                if (questionNumber == 5)
                {
                    Question.PlayMusic("GOT");
                Joker.JokerCreate(ViewerUsed, TelephoneUsed, FiftyUsed, TwoAnswerUsed);
                Progress.ProgressGraph(questionNumber);
                WriteQuestion(quest);
                }

                Console.Write("\nYour Answer: ");


                var cts = new CancellationTokenSource();
                var token = cts.Token;

                // Input task
                var inputTask = Task.Run(() =>
                {
                    do
                    {
                        input = char.Parse(Console.ReadLine());
                        if (input == '1')
                        {
                            if (ViewerUsed)
                            {
                                Warning.WarningMessage("Viewer joker is already used!");
                                continue;
                            }
                            ViewerUsed = true;
                            jokerIsUsed = true;
                            Joker.JokerCreate(ViewerUsed, TelephoneUsed, FiftyUsed, TwoAnswerUsed);
                            Progress.CorrectAnswerShower(quest);
                            break;
                        }
                        else if (input == '2')
                        {
                            if (TelephoneUsed)
                            {
                                Warning.WarningMessage("Telephone joker is already used!");
                                continue;
                            }
                            TelephoneUsed = true;
                            jokerIsUsed = true;
                            Joker.JokerCreate(ViewerUsed, TelephoneUsed, FiftyUsed, TwoAnswerUsed);
                            Progress.CorrectAnswerShower(quest);
                            
                            break;
                        }
                        else if (input == '3')
                        {
                            if (FiftyUsed)
                            {
                                Warning.WarningMessage("50:50 joker is already used!");
                                continue;
                            }
                            FiftyUsed = true;
                            jokerIsUsed = true;
                            Joker.JokerCreate(ViewerUsed, TelephoneUsed, FiftyUsed, TwoAnswerUsed);
                            Progress.CorrectAnswerShower(quest);
                            break;
                        }
                        else if (input == '4')
                        {
                            if (TwoAnswerUsed)
                            {
                                Warning.WarningMessage("x2 joker is already used!");
                                continue;
                            }
                            TwoAnswerUsed = true;
                            jokerIsUsed = true;
                            Joker.JokerCreate(ViewerUsed, TelephoneUsed, FiftyUsed, TwoAnswerUsed);
                            Progress.CorrectAnswerShower(quest);
                            break;
                        }
                        else if (walidAnswers.Contains(input))
                        {
                            break;
                        }
                        else
                        {
                            Warning.WarningMessage("Invalid choice!");
                        }
                    } while (true);
                    return input;
                }, token);
                // Timer task with cancellation support
                var timerTask = Task.Run(() =>
                {
                    Progress.TimeRemover(token);
                }, token);

                // Wait for whichever finishes first
                var finished = Task.WhenAny(inputTask, timerTask).Result;
                char answer = finished == inputTask ? inputTask.Result : 'N';

                // Cancel tasks
                cts.Cancel();

                Console.ResetColor();

                if (jokerIsUsed)
                {
                    jokerIsUsed = false;
                    continue;
                }
                if (answer == 'N')
                {
                    break;
                }
                else if (quest.IsCorrect(answer))
                {
                    Progress.ResultMarker(answer, quest);
                    Progress.CorrectAnswerShower(quest);
                }
                else if (answer == 'e')
                {
                    if (questionNumber > 1)
                    {
                        EndScreen.ShowEndScreen(awards[questionNumber - 2]);
                    }
                    EndScreen.ShowEndScreen(0);
                    Thread.Sleep(5000);
                    break;
                }
                else
                {
                    Progress.ResultMarker(answer, quest);
                    Progress.CorrectAnswerShower(quest);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Clear();
                    Console.ResetColor();
                    break;
                }
                Thread.Sleep(5000);
            }


            Console.ResetColor();
            Console.WriteLine();
            if (questionNumber == questions.Count)
            {
                EndScreen.ShowEndScreen(1000000);
            }
            else
            {
                EndScreen.ShowEndScreen(balance);
            }

        }

        private static void WriteQuestion(Question quest)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(quest.Text);

            int left = 30; // X position for A/C
            int right = 63; // X position for B/D
            int top = Console.CursorTop + 1; // start a couple lines below the question

            // Place A and B
            Console.SetCursorPosition(left, top);
            Console.Write($"◆ A: {quest.Options[0]}");

            Console.SetCursorPosition(right, top);
            Console.Write($"◆ B: {quest.Options[1]}");

            // Place C and D (on the next line)
            Console.SetCursorPosition(left, top + 2);
            Console.Write($"◆ C: {quest.Options[2]}");

            Console.SetCursorPosition(right, top + 2);
            Console.Write($"◆ D: {quest.Options[3]}");

            Console.WriteLine();
        }
    }

}
