using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CGPA_Calculator
{
    internal class Animation
    {
        public static void DisplayLoadingAnimation(float durationInSeconds)
        {
            int counter = 0;
            Console.CursorVisible = false;
            while (counter < durationInSeconds * 10) // Display the animation for the specified duration
            {
                Console.Write("|");
                Thread.Sleep(50);
                Console.Write("\b/");
                Thread.Sleep(50);
                Console.Write("\b-");
                Thread.Sleep(50);
                Console.Write("\b\\");
                Thread.Sleep(50);
                Console.Write("\b|");
                Thread.Sleep(100);
                Console.Write("\b/");
                Thread.Sleep(50);
                Console.Write("\b-");
                Thread.Sleep(50);
                Console.Write("\b\\");
                Thread.Sleep(50);
                Console.Write("\b");
                counter++;
            }
            Console.CursorVisible = true;
        }

        public static void GenericLoadingAnimation(string input)
        {
            Console.Write($"{input} ");

            int count = 0;
            while (count < 7)
            {
                Console.Write(".");

                Thread.Sleep(500);

                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                Console.Write(" ");

                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);

                Console.Write(".");
                count++;

            }

            Console.Clear();
        }
    }
}