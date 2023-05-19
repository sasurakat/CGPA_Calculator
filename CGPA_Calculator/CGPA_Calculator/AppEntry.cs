using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CGPA_Calculator
{
    internal class AppEntry
    {
        private readonly string userNameMesssage = "Please Insert your Name";
        private readonly string courseCodeMessage = "Please Enter CourseCode, Example: MAT123";
        private readonly string courseUnitMessage = "Please Enter CourseUnit, Example: 1, 2, 3, 4, 5";
        private readonly string courseScoreMessage = "Please Enter CourseScore, Example 55 not greater than 100 or lesser than 0";
        private readonly string continueOrNot = "Please enter Yes or Y to add another course or any other key to print result";
        public void AppStart()
        {
            string userName;
            string courseCode;
            string courseUnit;
            string courseScore;
            string addMoreCoure;
            bool check;
            List<Course> courses = new List<Course>();
            Course course = new Course();
            int resultCourseUnit;
            int resultCourseScore;

            UI.DisplayCalHeader();
            Console.WriteLine("Welcome Please Insert your Name");

            while (true)
            {
                userName = Console.ReadLine().Trim();

                bool checkUserName = Validations.ValidateUserName(userName);
                if (!checkUserName)
                {
                    DisplayErrorMessage("Name Shouldn't contain digits or symbols", userNameMesssage);
                }
                else
                {
                    Console.Clear();
                    break;
                }
            }

            Console.WriteLine($"Welcome {userName}");

            do
            {
                Console.WriteLine(courseCodeMessage);
                while (true)
                {
                    courseCode = Console.ReadLine().Trim().ToUpper();
                    bool checkCourseCode = Validations.IsStringCourseCode(courseCode);
                    if (checkCourseCode == false)
                    {
                        DisplayErrorMessage("CourseCode Should follow this pattern: MAT123 \n you need 3 alphabets and 3 digits", courseCodeMessage);
                    }
                    else if (courses.Select(x => x.CourseName).Contains(courseCode))
                    {
                        DisplayErrorMessage("Course already Exist", "Please Enter new course code");
                    }

                    else
                    {
                        Console.Clear();
                        break;
                    }
                }

                Console.WriteLine(courseUnitMessage);
                while (true)
                {
                    courseUnit = Console.ReadLine().Trim();
                    bool checkCourseUnitIsNumber = Validations.TryParseInt(courseUnit, out resultCourseUnit);
                    bool checkIfCourseUnitIsInRange = Validations.CourseUnitValidation(resultCourseUnit);
                    if (!checkCourseUnitIsNumber || !checkIfCourseUnitIsInRange)
                    {
                        DisplayErrorMessage("CourseUnit Should only contains digits and \n must between the range of 1 -5"
                            , courseUnitMessage);
                    }
                    else
                    {
                        Console.Clear();
                        break;
                    }
                }
                Console.WriteLine(courseScoreMessage);

                while (true)
                {
                    courseScore = Console.ReadLine().Trim();
                    bool checkCourseScoreIsNumber = Validations.TryParseInt(courseScore, out resultCourseScore);
                    bool checkIfCourseScoreIsInRange = Validations.CourseScoreValidation(resultCourseScore);
                    if (!checkCourseScoreIsNumber || !checkIfCourseScoreIsInRange)
                    {
                        DisplayErrorMessage("CourseScore Should only contains digits and \n must between the range of 0 - 100"
                            , courseScoreMessage);
                    }
                    else
                    {
                        Console.Clear();
                        break;
                    }
                }

                Animation.GenericLoadingAnimation("Calculating");



                Course addCourse = course.GradeCourse(courseCode.ToUpper().Trim(), resultCourseUnit, resultCourseScore);

                courses.Add(addCourse);

                Console.WriteLine(continueOrNot);

                addMoreCoure = Console.ReadLine().ToLower().Trim();
                if (addMoreCoure == "y" || addMoreCoure == "yes")
                {
                    check = true;
                }
                else
                {
                    check = false;
                }

                Console.Clear();
            } while (check);

            Animation.GenericLoadingAnimation("Loading Table");
            UI.DisplayCalHeader();
            UI.PrintTable(courses);
        }

        private static void DisplayErrorMessage(string message, string retryMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: {message}");
            Console.ResetColor();
            Console.WriteLine(retryMessage);
        }


    }
}
