namespace ConsoleQuizzApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            List<Question> questions = QuizData.Questions.ToList();

            int score = 0;
            int questionNumber = 1;
            string[] optionFormat = new string[] { "   a. ", "   b. ", "   c. ", "   d. " };
            string answer;
            foreach (var quest in questions)
            {
                Console.WriteLine(quest.Text);
                Console.WriteLine($"\t⬩ A:  mama{quest.Options[0]}\t\t\t\t       ⬩ B:  {quest.Options[1]}\r\n\n\t⬩ C:  {quest.Options[2]}\t\t\t\t       ⬩ D:  {quest.Options[3]}\r\n");

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
