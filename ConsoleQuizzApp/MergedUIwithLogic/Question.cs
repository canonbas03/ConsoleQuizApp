using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleQuizzApp
{
    internal class Question
    {
        public string? Text { get; set; }
        public string[]? Options { get; set; }
        public char CorrectOption { get; set; }

        public bool IsCorrect(char answer)
        {
            answer = char.ToLower(answer);
            if (answer == CorrectOption)
            { return true; }
            else { return false; }
        }
    }
}
