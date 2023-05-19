using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CGPA_Calculator
{
    internal class Validations
    {
        public static bool IsInputCourseNameAndCourseCode(string input)
        {
            if (string.IsNullOrEmpty(input) || input.Length != 6)
            {
                return false;
            }

            for (int i = 0; i < 3; i++)
            {
                if (!char.IsLetter(input[i]))
                {
                    return false;
                }
            }

            for (int i = 3; i < 6; i++)
            {
                if (!char.IsDigit(input[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsStringCourseCode(string input)
        {
            Regex pattern = new Regex(@"^[A-Za-z]{3}\d{3}$");
            return pattern.IsMatch(input);
        }

        public static bool TryParseInt(string input, out int result)
        {
            if (int.TryParse(input, out result))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CourseUnitValidation(int input)
        {
            if (input >= 1 && input <= 5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CourseScoreValidation(int input)
        {
            if (input >= 0 && input <= 100)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool ValidateUserName(string input)
        {
            string pattern = @"^[a-zA-Z ]*$";

            if (Regex.IsMatch(input, pattern))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
