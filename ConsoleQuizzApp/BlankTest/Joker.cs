using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlankTest
{
    internal class Joker
    {
        public static string JokerModel(string name, bool isUsed)
        {
            string used = "╭──╮\r\n|❌|\r\n╰──╯";
            if (name == "Viewers" && !isUsed)
            {
                return "╭──╮\r\n|👥│\r\n╰──╯";
            }
            else if (name == "Telephone" && !isUsed)
            {
                return "╭──╮\r\n|📞│\r\n╰──╯";
            }
            else if (name == "Fifty" && !isUsed)
            {
                return "╭──╮\r\n|50│\r\n╰──╯";
            }
            else if (name == "TwoAnswer" && !isUsed)
            {
                return "╭──╮\r\n|x2|\r\n╰──╯";
            }

                return used;
            
              
        }
    }
}
