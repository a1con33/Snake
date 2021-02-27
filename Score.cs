using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{

    public class Score
    {
        Params settings = new Params();
        private static string pathToResultsFile;
        public int currentPoints;
        public string username = "";

        public Score()
        {

        }

        public Score(int currentPoints)
        {
            this.currentPoints = currentPoints;
        }

        public int GetCurrentPoints()
        {
            return currentPoints;
        }

        public Score(string _pathToResources)
        {
            
            pathToResultsFile = _pathToResources + "results.txt";
            WriteText("Score:", 84, 1);
            ShowCurrentPoints();

        }

        public void UpCurrentPoints()
        {
            currentPoints +=1;
        }

        public void DownCurrentPoints()
        {
            currentPoints -= 3;
        }

        public void UpCurrentPointsx3()
        {
            currentPoints += 2;
        }

        public void ShowCurrentPoints()
        {
            
            if (currentPoints == 0)
            {
                Console.SetCursorPosition(87, 3);
            }

            else if (currentPoints > 0)
            {
                Console.SetCursorPosition(87, 3);
                Console.WriteLine(" ");
                Console.SetCursorPosition(86,3);
            }

            Colors colors = new Colors(currentPoints);
            Console.WriteLine(currentPoints.ToString());
        }


        public void WriteGameOver()
        {
            Console.Clear();
            int xOffset = 30;
            int yOffset = 8;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(xOffset, yOffset++);
            WriteText("================================", xOffset, yOffset++);
            WriteText("G A M E             O V E R", xOffset + 3, yOffset++);
            WriteText("================================", xOffset, yOffset++);
            Console.SetCursorPosition(36, 15);
            Console.WriteLine("Enter a username: ");
            Console.SetCursorPosition(54, 15);
            username = Console.ReadLine();
        }

        public void WriteResult()
        {
            StreamWriter streamWriter = new StreamWriter(pathToResultsFile);
            streamWriter.Write(username + " - " + currentPoints);
            streamWriter.Close();
        }

        static void WriteText(String text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }

    }
}
