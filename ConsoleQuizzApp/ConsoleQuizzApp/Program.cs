namespace ConsoleQuizzApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Question> questions = new List<Question>
            {
                new Question
                {
                    Text = "This questions answer is A?",
                    Options = new string[] { "aaa", "bbb", "ccc", "ddd" },
                    CorrectIndex = 0
                },
                new Question
                {
                      Text = "This questions answer is C?",
                    Options = new string[] { "aaa", "bbb", "ccc", "ddd" },
                    CorrectIndex = 2
                }
            };

            foreach (var quest in questions)
            {
                string[] optionFormat = new string[] { "   a. ", "   b. ", "   c. ", "   d. "};
                int answer = 0;
                Console.WriteLine(quest.Text);
                for (int i = 0; i < quest.Options.Length; i++)
                {
                    Console.WriteLine(optionFormat[i] + quest.Options[i]);
                }
                answer = int.Parse(Console.ReadLine());
                if (quest.IsCorrect(answer))
                {
                    Console.WriteLine("Correct"!);
                }
                else
                {
                    Console.WriteLine("WRONG!");
                }
            }
        }
    }
}
