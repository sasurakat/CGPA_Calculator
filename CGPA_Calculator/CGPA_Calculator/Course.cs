using System;
using System.Collections.Generic;
using System.Text;

namespace CGPA_Calculator
{
    internal class Course
    {
        private int initial = 0;
        public int Id { get; set; }
        public string CourseName { get; set; }
        public int CourseUnit { get; set; }
        public string Grade { get; set; }
        public int GradeUnit { get; set; }
        public int WeightPoint { get; set; }
        public string Remark { get; set; }
        public bool IsPassed { get; set; }
        public int CourseScore { get; set; }

        private string[] remarks = new string[] { "Fail", "Pass", "Fair", "Good", "Very Good", "Excellent" };
        private string[] grades = new string[] { "F", "E", "D", "C", "B", "A" };




        public Course GradeCourse(string courseName, int courseUnit, int score)
        {
            int gradeUnit = GetGradeUnit(score);
            return new Course
            {
                Id = initial++,
                CourseName = courseName,
                CourseUnit = courseUnit,
                Grade = grades[gradeUnit],
                GradeUnit = gradeUnit,
                WeightPoint = courseUnit * gradeUnit,
                Remark = remarks[gradeUnit],
                IsPassed = gradeUnit > 0? true: false,
                CourseScore = score
            };
        }


        private int GetGradeUnit(int courseScore)
        {
            if (courseScore >= 70 && courseScore <= 100)
            {
                return 5;
            }
            else if (courseScore >= 60 && courseScore <= 69)
            {
                return 4;
            }
            else if (courseScore >= 50 && courseScore <= 59)
            {
                return 3;
            }
            else if (courseScore >= 45 && courseScore <= 49)
            {
                return 2;
            }
            else if (courseScore >= 40 && courseScore <= 44)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }


    }
}
