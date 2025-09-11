using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace BlankTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool ViewerUsed = false;
            bool TelephoneUsed = false;
            bool FiftyUsed = false;
            bool TwoAnswerUsed = false;
            Joker.JokerInitialCreate();
            Joker.JokerCreate(ViewerUsed,TelephoneUsed,FiftyUsed,TwoAnswerUsed);
            string input;
            do
            {
                input = Console.ReadLine();
                if(input == "1")
                {
                    ViewerUsed = true;
                    Joker.JokerCreate(ViewerUsed, TelephoneUsed, FiftyUsed, TwoAnswerUsed);
                }
                else if(input == "2")
                {
                    TelephoneUsed = true;
                    Joker.JokerCreate(ViewerUsed, TelephoneUsed, FiftyUsed, TwoAnswerUsed);
                }
            } while (input != "end");
        }

        

       
    }
}
