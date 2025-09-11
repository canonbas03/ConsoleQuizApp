using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleQuizzApp
{
    internal class QuizData
    {
        public static readonly Question[] Questions =
        {
            new Question
                {
                    Text = "\r\n\r\n—---------------------------------------{What is the capital of France?}—--------------------------------------------\r\n\t",
                    Options = new string[] { "Varna", "Burgas", "Paris", "Razgrad" },
                    CorrectOption = "c"
                },
            new Question
                {
                      Text = "This questions answer is C?",
                    Options = new string[] { "aaa", "bbb", "ccc", "ddd" },
                    CorrectOption = "c"
                }

        };
    }
}
