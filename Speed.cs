using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    public class Speed
    {
        public Speed(int currentPoints)
        {
            if (currentPoints <= 10)
            {
                Thread.Sleep(100);
            }
            else if (currentPoints >= 11 && currentPoints <= 20)
            {
                Thread.Sleep(80);
            }
            else if (currentPoints >= 21 && currentPoints <= 30)
            {
                Thread.Sleep(60);
            }

            else if (currentPoints > 31)
            {
                Thread.Sleep(40);
            }
            
        }
    }
}
