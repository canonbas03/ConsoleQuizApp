using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleQuizzApp
{
    internal class QuizData
    {
        public static readonly Question[] Questions =
        {
              new Question
            {
                Text = FormatQuestion("What color is the sky on a clear day?"),
                Options = new string[] { "Green", "Blue", "Red", "Yellow" },
                CorrectOption = 'b'
            },
            new Question
            {
                Text = FormatQuestion("Which animal is known as \"man's best friend\"?"),
                Options = new string[] { "Dog", "Cat", "Horse", "Parrot" },
                CorrectOption = 'a'
            },
            new Question
            {
                Text = FormatQuestion("How many days are in a leap year?"),
                Options = new string[] { "364", "365", "366", "367" },
                CorrectOption = 'c'
            },
           
            new Question
            {
                Text = FormatQuestion("Which planet is closest to the Sun?"),
                Options = new string[] { "Mercury", "Venus", "Earth", "Mars" },
                CorrectOption = 'a'
            },
                new Question
            {
                Text = FormatQuestion("Which series soundtrack is this?"),
                Options = new string[] { "Game of Thrones", "Harry Potter", "Lord of the Rings", "Selena" },
                CorrectOption = 'a'
            },
            new Question
            {
                Text = FormatQuestion("Who painted the Mona Lisa?"),
                Options = new string[] { "Vincent van Gogh", "Pablo Picasso", "Leonardo da Vinci", "Michelangelo" },
                CorrectOption = 'c'
            },
            new Question
            {
                Text = FormatQuestion("Which metal has the chemical symbol \"Au\"?"),
                Options = new string[] { "Silver", "Copper", "Gold", "Iron" },
                CorrectOption = 'c'
            },
            new Question
            {
                Text = FormatQuestion("In computing, what does \"HTTP\" stand for?"),
                Options = new string[] { "HyperText Transfer Protocol", "High Tech Transport Process", "Hyperlink Transmission Path", "Home Terminal Text Program" },
                CorrectOption = 'a'
            },
            new Question
            {
                Text = FormatQuestion("Which Shakespeare play features Rosencrantz and Guildenstern?"),
                Options = new string[] { "Macbeth", "Hamlet", "Othello", "Romeo and Juliet" },
                CorrectOption = 'b'
            },
            new Question
            {
                Text = FormatQuestion("What is the square root of 144?"),
                Options = new string[] { "11", "12", "13", "14" },
                CorrectOption = 'b'
            },
            new Question
            {
                Text = FormatQuestion("Which scientist proposed the three laws of motion?"),
                Options = new string[] { "Albert Einstein", "Isaac Newton", "Galileo Galilei", "Nikola Tesla" },
                CorrectOption = 'b'
            },
            new Question
            {
                Text = FormatQuestion("What is the largest internal organ in the human body?"),
                Options = new string[] { "Heart", "Liver", "Lungs", "Kidneys" },
                CorrectOption = 'b'
            },
            new Question
            {
                Text = FormatQuestion("Which element is needed for nuclear fission in most power plants?"),
                Options = new string[] { "Uranium", "Plutonium", "Thorium", "Hydrogen" },
                CorrectOption = 'a'
            },
            new Question
            {
                Text = FormatQuestion("Which Greek philosopher taught Alexander the Great?"),
                Options = new string[] { "Socrates", "Aristotle", "Plato", "Pythagoras" },
                CorrectOption = 'b'
            },
            new Question
            {
                Text = FormatQuestion("What is the smallest prime number greater than 100?"),
                Options = new string[] { "101", "103", "107", "109" },
                CorrectOption = 'a'
            }
        };

        public static string FormatQuestion(string question, int totalWidth = 116)
        {
            int leftDashes = 30;
            int rightDashes = 31;

            string leftPart = new string('-', leftDashes);
            string rightPart = new string('-', rightDashes);

            // space available inside braces
            int insideWidth = totalWidth - leftDashes - rightDashes - 2; // minus { }

            if (question.Length > insideWidth)
                question = question.Substring(0, insideWidth);

            int leftSpaces = (insideWidth - question.Length) / 2;
            int rightSpaces = insideWidth - question.Length - leftSpaces;

            string inside = "{" + new string(' ', leftSpaces) + question + new string(' ', rightSpaces) + "}";

            return "\n\n" + leftPart + inside + rightPart + "\r\n";
        }





    }
}

