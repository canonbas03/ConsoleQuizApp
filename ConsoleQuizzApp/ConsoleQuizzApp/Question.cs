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
        public int CorrectIndex { get; set; }

        public bool IsCorrect(int answer)
        {
            if (answer == CorrectIndex)
            { return true; }
            else { return false; }
        }
    }
}
