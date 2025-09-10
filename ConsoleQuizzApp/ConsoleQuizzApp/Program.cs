namespace ConsoleQuizzApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Question> questions = QuizData.Questions.ToList();

            int score = 0;
            int questionNumber = 1;
            string[] optionFormat = new string[] { "   a. ", "   b. ", "   c. ", "   d. " };
            string answer;
            foreach (var quest in questions)
            {
                Console.WriteLine($"{questionNumber}. {quest.Text}");
                for (int i = 0; i < quest.Options.Length; i++)
                {
                    Console.WriteLine(optionFormat[i] + quest.Options[i]);
                }

                Console.Write("Your Answer: ");
                answer = Console.ReadLine();
                if (quest.IsCorrect(answer))
                {
                    Console.WriteLine("Correct!");
                    score++;
                }
                else
                {
                    Console.WriteLine("WRONG!");
                    break;
                }
                questionNumber++;
            }
            if (score == questions.Count)
            {
                Console.WriteLine("YOU WON!!!");
            }
            else Console.WriteLine("GOOD BYE!");
        }
    }
}
