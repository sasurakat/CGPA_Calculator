using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CGPA_Calculator
{
    internal class UI
    {
        static readonly int tableWidth = 90;
        public static void DisplayCalHeader()
        {
            // Define the header text
            string headerText = "CGPA Calculator";

            // Calculate the center position of the header based on the console width
            int headerWidth = headerText.Length + 4;
            int centerPosition = (Console.WindowWidth / 2) - (headerWidth / 2);

            // Display the centered header
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(new string('=', 120));
            Console.WriteLine($"{new string(' ', centerPosition)}|  {headerText}  |");
            Console.WriteLine(new string('=', 120));
            Console.ResetColor();
        }


        public static void PrintTable(List<Course> courses)
        {
            double totalCourseUnit = 0;
            double totalUnitPass = 0;
            double totalWeightPoint = 0;

            Console.Clear();
            Console.WriteLine(CentreText("CGPA Calculator", tableWidth));
            PrintLine();
            PrintRow("COURSE & CODE", "COURSE UNIT", "GRADE", "GRADE-UNIT", "WEIGHT Pt", "REMARK");
            PrintLine();
            foreach (Course course in courses)
            {
                PrintRow(course.CourseName, course.CourseUnit.ToString(),
                    course.Grade, course.GradeUnit.ToString(), course.WeightPoint.ToString(),
                    course.Remark.ToString());


                totalCourseUnit += course.CourseUnit;
                totalUnitPass += course.IsPassed == true ? course.CourseUnit : 0;
                totalWeightPoint += course.WeightPoint;
            }
            PrintLine();
            Console.WriteLine("\n \n");

            //double totalCourseUnit = courses.Sum(x => x.CourseUnit);
            //double totalUnitPass = courses.Where(x => x.IsPassed == true).Select(y => y.CourseUnit).Sum();
            //double totalWeightPoint = courses.Sum(x => x.WeightPoint);

            double totalCGPA = Math.Round(Convert.ToDouble(totalWeightPoint / totalCourseUnit), 2);

            Console.WriteLine($"Total Course Unit Registered is {totalCourseUnit}" +
                $"\r\nThe total Course Unit Passed is {totalUnitPass}" +
                $"\r\nThe total Weight Point is {totalWeightPoint}");

            Console.WriteLine($"Your GPA is = {totalCGPA}");

        }

        static void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        static void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length + 1) / columns.Length;
            string row = "|";
            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }
            Console.WriteLine(row);
        }

        static string AlignCentre(string text, int width)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;
            return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
        }

        static string CentreText(string text, int width)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            int totalSpaces = width - text.Length;
            int leftSpaces = totalSpaces / 2;
            return new string(' ', leftSpaces) + text + new string(' ', totalSpaces - leftSpaces);
        }

    }
}
