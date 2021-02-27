using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Colors
    {
        public Colors(int currentPoints)
        {
            if (currentPoints <= 10)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }

            else if (currentPoints >= 11 && currentPoints <= 20)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }

            else if (currentPoints >= 21 && currentPoints <= 30)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            else if (currentPoints > 31)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
            }

           
        }
    }
}
